using EntityDB.Context;
using EntityDB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDB
{
    public class ServiceDepartment
    {
        public Department Department { get; private set; }
        public ServiceDepartment(Department? department = null)
        {
            Department = department ?? new Department("NoName");
        }

        public void AddStudent(Student student)
        {
            if (student == null) { throw new Exception("Student cannot be null"); }

            if (student.Lessons.FirstOrDefault() == null)
            {
                student.Lessons.Add(Department.Lessons.FirstOrDefault());
            }
            Department.Students.Add(student);
        }

        public void AddStudents(List<Student> students)
        {
            if (students == null) { throw new Exception("Students  cannot be null"); }

            students.ForEach(student => AddStudent(student));

        }
        public void AddLesson(Lesson lesson)
        {
            if (lesson == null) { throw new Exception("Lesson cannot be null"); }

            if (lesson.Departments.SingleOrDefault(x => x.Id == Department.Id) == null)
            {
                lesson.Departments.Add(Department);
            }
            Department.Lessons.Add(lesson);
        }

        public void AddLessons(List<Lesson> lessons)
        {
            if (lessons == null) { throw new Exception("Lessons cannot be null"); }

            foreach (var lesson in lessons)
            {
                AddLesson(lesson);
            }
        }

    }
}
