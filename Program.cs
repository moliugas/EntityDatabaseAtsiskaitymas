
using EntityDB.Context;
using EntityDB.Entity;
using EntityDB.Repository;
using Microsoft.EntityFrameworkCore;

var rnd = new Random();
var db = new RegistryContext();

//db.Database.EnsureDeleted();


//db.Lessons.AddRange(new EntityDB.Service.DataGen().GenerateLessons().Lessons);
//db.SaveChanges();


//    "Server=localhost;Database=Ef_Core;Trusted_Connection=True;TrustServerCertificate=True"

//Add-Migration InitialCreate

//Update-Database

//        1.Sukurti departamentą ir į jį pridėti studentus, paskaitas(papildomi points jei pridedamos
//paskaitos jau egzistuojančios duomenų bazėje).

Department GetMockDepartment(bool createNew = false, string? name = null)
{
    Department department = createNew ? RepositoryDepartment.GetNewDepartment(name) : db.Departments.SingleOrDefault(x => x.Name == "Departamementas6xxx9") ?? RepositoryDepartment.GetNewDepartment();
    RepositoryDepartment.Department = department;

    List<Student> students = new List<Student>() {
        new Student("Petras"),
        new Student("Marytea")
        };

    List<Lesson> lessons = db.Lessons.Where(x => !x.Departments.Contains(department)).ToList();

    department.Students.AddRange(students);
    department.Lessons.AddRange(lessons);

    return department;
}

//2.Pridėti studentus / paskaitas į jau egzistuojantį departamentą.
void AddStudentsLessonsToDeparment(List<Student> students, List<Lesson> lessons, Guid departmentId)
{
    Department department = db.Departments.Single(x => x.Id == departmentId);

    department.Students.AddRange(students);
    department.Lessons.AddRange(lessons);

    db.UpdateRange(department);
    db.SaveChanges();
}

//3. Sukurti paskaitą ir ją priskirti prie departamento.

void CreateLessonAddToDepartment(Guid departmentId)
{
    Lesson lesson = new("Pamoka");

    AddStudentsLessonsToDeparment(new List<Student>(), new List<Lesson>() { lesson }, departmentId);
}


//4. Sukurti studentą, jį pridėti prie egzistuojančio departamento ir priskirti jam egzistuojančias
//paskaitas.

void CreateStudentAddExistingLessonsAddToExistingDepartment(Guid id)
{
    Student student = new("Kaka");
    student.Lessons.AddRange(db.Lessons.ToList());
    AddStudentsLessonsToDeparment(new List<Student>() { student }, new List<Lesson>(), id);
}

//5. Perkelti studentą į kitą departamentą(bonus points jei pakeičiamos ir jo paskaitos).

void ChangeStudentDepartment(Student student, Department department)
{
    student.DepartmentId = department.Id;
    student.Lessons.Where(x => x.Departments.Contains(department));
    department.Students.Add(student);

    db.UpdateRange(department);
    db.SaveChanges();
}

//6.Atvaizduoti visus departamento studentus.
 void PrintAllStudentsByDepartmentId(Guid departmentId)
{
    var department = db.Departments.Where(x => x.Id == departmentId).Include(c => c.Students).First();

    int num = 0;
    foreach (var item in department.Students)
    {
        Console.WriteLine($"#{++num} {item.Name} {item.Id}");
    }
}

//7. Atvaizduoti visas departamento paskaitas.
void PrintAllLessonsByDepartmentId(Guid departmentId)
{
    var department = db.Departments.Where(x => x.Id == departmentId).Include(c => c.Lessons).First();

    int num = 0;
    foreach (var item in department.Lessons)
    {
        Console.WriteLine($"#{++num} {item.Name} {item.Id}");
    }
}

//8. Atvaizduoti visas paskaitas pagal studentą

void PrintAllLessonsByStudentIdAndDepartmentId(Guid studentId, Guid departmentId)
{
    var department = db.Departments.Where(x => x.Id == departmentId).Include(c => c.Lessons).First();

    int num = 0;
    foreach (var item in department.Lessons.Where(x => x.Students.Contains(studentId)))
    {
        Console.WriteLine($"#{++num} {item.Name} {item.Id}");
    }
}

//db.UpdateRange(GetMockDepartment());
//db.SaveChanges();

Guid deptId = db.Departments.First().Id;
Guid studId = db.Students.First().Id;

//AddStudentsLessonsToDeparment(new List<Student>() { new("Gagis") }, new List<Lesson>() { new("Gagio pamoka") }, deptId);

//CreateLessonAddToDepartment(deptId);

//CreateStudentAddExistingLessonsAddToExistingDepartment(deptId);

//Student stud = db.Students.Single(x => x.Name == "Kaka");

//var dept = GetMockDepartment(true, "Antras");

//ChangeStudentDepartment(stud, dept);

//PrintAllStudentsByDepartmentId(deptId);

//PrintAllLessonsByDepartmentId(deptId);

PrintAllLessonsByStudentIdAndDepartmentId(studId, deptId);
