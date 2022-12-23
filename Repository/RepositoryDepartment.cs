using EntityDB.Entity;

namespace EntityDB.Repository
{
    public static class RepositoryDepartment
    {
        public static Department Department { get; set; }

        public static Department GetNewDepartment(string? name = null)
        {
            return new(name ?? "Departamementas6xxx9");
        }

        public static void AddStudent(Student student)
        {
            if (student == null) { throw new Exception("Student cannot be null"); }

            if (student.Lessons.FirstOrDefault() == null)
            {
                student.Lessons.Add(Department.Lessons.First());
            }
            Department.Students.Add(student);
        }

        public static void AddStudents(List<Student> students)
        {
            if (students == null) { throw new Exception("Students  cannot be null"); }

            students.ForEach(student => AddStudent(student));

        }
        public static void AddLesson(Lesson lesson)
        {
            if (lesson == null) { throw new Exception("Lesson cannot be null"); }

            if (lesson.Departments.SingleOrDefault(x => x.Id == Department.Id) == null)
            {
                lesson.Departments.Add(Department);
            }
            Department.Lessons.Add(lesson);
        }

        public static void AddLessons(List<Lesson> lessons)
        {
            if (lessons == null) { throw new Exception("Lessons cannot be null"); }

            foreach (var lesson in lessons)
            {
                AddLesson(lesson);
            }
        }

    }
}
