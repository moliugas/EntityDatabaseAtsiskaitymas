
using EntityDB;
using EntityDB.Context;
using EntityDB.Entity;

new Menu();
class Menu
{
    public Menu() 
    {
        var rnd = new Random();
        var context = new RegistryContext();


        Department department = new("Departamementas6xxx9");

        ServiceDepartment service = new(department);

        List<Student> students = new() {
        new Student("Petras"),
        new Student("Marytea")
        };
               

        students.ForEach(student => student.Lessons.AddRange(context.Lessons.OrderBy(x => x.Id).Take(rnd.Next(20))));

        context.Departments.Add(service.Department);

        context.SaveChanges();


    }

}