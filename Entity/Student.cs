using System.ComponentModel.DataAnnotations.Schema;

namespace EntityDB.Entity
{
    public class Student
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
        public Department Department { get; set; }

        public Student(string name)
        {
            Name = name;
        }

    }
}