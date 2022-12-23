using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityDB.Entity
{
    [Table(nameof(Student))]
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<Lesson> Lessons { get; set; } = new List<Lesson>();

        [ForeignKey(nameof(Department))]
        public Guid DepartmentId { get; set; }

        public Student(string name)
        {
            Name = name;
        }

    }
}