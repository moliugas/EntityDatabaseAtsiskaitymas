
using EntityDB;
using EntityDB.Context;
using EntityDB.Entity;
using Microsoft.EntityFrameworkCore;


//var book = context.Students.All(x => x.Id == null);

//foreach (var student in book)
//{
//    context.Students.Remove(student);
//}
new Menu();
class Menu
{
    public Menu() 
    {
        var context = new RegistryContext();
        var mockData = new DataGen();
        var random = new Random();

        mockData.GenerateAll();

        var depts = mockData.Departments;
        var lesns = mockData.Lessons;
        var studs = mockData.Students;

        Department? department = context.Departments.FirstOrDefault();

        ServiceDepartment service = new ServiceDepartment(depts[3]);

        foreach(var student in studs)
        {
            foreach(var lesson in lesns)
            {
                if (random.Next(100) > 70) { continue; }

                student.Lessons.Add(lesson);
            }
        }

        service.AddLessons(lesns);
        service.AddStudents(studs);

        context.Departments.Add(service.Department);

        context.SaveChanges();
    }

}