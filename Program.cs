
using EntityDB.Context;
using EntityDB.Entity;
using EntityDB.Repository;

var rnd = new Random();
var context = new RegistryContext();

context.Database.EnsureDeleted();


//context.Lessons.AddRange(new EntityDB.Service.DataGen().GenerateLessons().Lessons);
//context.SaveChanges();


//    "Server=localhost;Database=Ef_Core;Trusted_Connection=True;TrustServerCertificate=True"
    
//Add-Migration InitialCreate
    
//Update-Database

//        1.Sukurti departamentą ir į jį pridėti studentus, paskaitas(papildomi points jei pridedamos
//paskaitos jau egzistuojančios duomenų bazėje).

Department GetMockDepartment()
{
    Department department = context.Departments.Single(x => x.Name == "Departamementas6xxx9");
    RepositoryDepartment.Department = department;

    List <Student> students = new List<Student>() {
        new Student("Petras"),
        new Student("Marytea")
        };

    List<Lesson> lessons = context.Lessons.Where(x => !x.Departments.Contains(department)).ToList();

    department.Students.AddRange(students);
    department.Lessons.AddRange(lessons);

    return department;
}
//GetMockDepartment();
//2.Pridėti studentus / paskaitas į jau egzistuojantį departamentą.
void AddStudentsLessonsToDeparment(List<Student> students, List<Lesson> lessons, Guid departmentId)
{
    Department department = context.Departments.Single(x => x.Id == departmentId);

    //department.Students.AddRange(students);

    department.Lessons.AddRange(lessons);
    //lessons.ForEach(x => x.Departments.Add(department));
    //department.Lessons.AddRange(lessons);

    context.Add(department);
    context.SaveChanges();
}

//3. Sukurti paskaitą ir ją priskirti prie departamento.

void CreateLessonAddToDepartmentSave()
{
    Lesson lesson = new Lesson("Pamoka");

    Department department = context.Departments.Single(x => x.Name == "Departamementas6xxx9");

    lesson.Departments.Add(department);
    context.Lessons.Add(lesson);
    department.Lessons.Add(lesson);
    context.SaveChanges();


}


//4. Sukurti studentą, jį pridėti prie egzistuojančio departamento ir priskirti jam egzistuojančias
//paskaitas.
//5. Perkelti studentą į kitą departamentą(bonus points jei pakeičiamos ir jo paskaitos).



//context.UpdateRange(GetMockDepartment());
//context.SaveChanges();

//AddStudentsLessonsToDeparment(new List<Student>() { new("Gagis") }, new List<Lesson>() { new("Gagio pamoka") }, new Guid("E28EC477-E92D-4340-0A23-08DAE4706C11"));

//CreateLessonAddToDepartmentSave();

Console.WriteLine('o');

//students.ForEach(student => student.Lessons.AddRange(context.Lessons.OrderBy(x => x.Id).Take(rnd.Next(20))));

//context.Departments.Add(service.Department);


