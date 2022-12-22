
using EntityDB;
using EntityDB.Context;
using EntityDB.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

var rnd = new Random();
var context = new RegistryContext();


//        1.Sukurti departamentą ir į jį pridėti studentus, paskaitas(papildomi points jei pridedamos
//paskaitos jau egzistuojančios duomenų bazėje).

Department GetMockDepartment()
{
    Department department = new("Departamementas6xxx9");


    List<Student> students = new List<Student>() {
        new Student("Petras"),
        new Student("Marytea")
        };

    List<Lesson> lessons = context.Lessons.Where(x => !x.Departments.Contains(department)).ToList();
    lessons.ForEach(x => x.Departments.Add(department));

    department.Students = students;
    department.Lessons = lessons;

    return department;
}

//2.Pridėti studentus / paskaitas į jau egzistuojantį departamentą.
void AddStudentsLessonsToDeparment(Student student, Lesson lesson, Guid departmentId)
{
    Department result = context.Departments.SingleOrDefault(x => x.Id == departmentId);

    result.Students.Add(student);
    result.Lessons.Add(lesson);

    context.Departments.Update(result);
    context.SaveChanges();
}

//3. Sukurti paskaitą ir ją priskirti prie departamento.

void CreateLessonAddToDepartmentSave()
{
    Lesson lesson = new Lesson("Pamoka");

    Department department = context.Departments.Single(x => x.Name == "Departamementas6xxx9");

    AddLessonToDepartment(lesson, department);
}

void AddLessonToDepartment(Lesson lesson, Department department)
{
    lesson.Departments.Add(department);
    department.Lessons.Add(lesson);

    context.Update(department);
    context.SaveChanges();


}


//4. Sukurti studentą, jį pridėti prie egzistuojančio departamento ir priskirti jam egzistuojančias
//paskaitas.
//5. Perkelti studentą į kitą departamentą(bonus points jei pakeičiamos ir jo paskaitos).
CreateLessonAddToDepartmentSave();
//context.Departments.Add(GetMockDepartment());
//context.SaveChanges();


//students.ForEach(student => student.Lessons.AddRange(context.Lessons.OrderBy(x => x.Id).Take(rnd.Next(20))));

//context.Departments.Add(service.Department);


