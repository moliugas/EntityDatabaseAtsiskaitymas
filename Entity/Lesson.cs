using System.ComponentModel.DataAnnotations.Schema;

namespace EntityDB.Entity
{
    [Table(nameof(Lesson))]
    public class Lesson
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Department> Departments { get; set; }

        public Lesson(string name)
        {
            Name = name;
            Departments = new List<Department>();
        }
    }
}