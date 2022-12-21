using EntityDB.Entity;
using static Azure.Core.HttpHeader;

namespace EntityDB
{
    public class DataGen
    {
        public List<Student> Students { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<Department> Departments { get; set; }

        private Random Random { get; set; }

        private readonly string[] GirlNames = new[] { "Sofija", "Emilija", "Luknė", "Amelija", "Kamilė", "Lėja", "Gabija", "Patricija", "Elija", "Liepa" };
        private readonly string[] BoyNames = new[] { "Markas", "Benas", "Jokūbas", "Dominykas", "Herkus", "Adomas", "Lukas", "Jonas", "Matas", "Kajus" };
        private readonly string[] LessonNames = new[] { "Math", "Chemistry", "Physics", "Calculus", "Biology", "Physical Education", "Arts", "English", "Flat Geo" };
        private readonly string[] DepartmentNames = new[] { "Department 1", "D2", "D3", "D7" };

        public DataGen()
        {
            Random = new Random();
            Students = new List<Student>();
            Lessons = new List<Lesson>();   
            Departments = new List<Department>();
        }
        public void GenerateAll()
        {
            GenerateLessons();
            GenerateStudents();
            GenerateDepartments();
        }
        private void GenerateStudents() 
        {
            for (int i = 0; i < 200; i++)
            {
                Students.Add(new Student(Random.Next() % 2 == 2 ? GirlNames[Random.Next(GirlNames.Length)] : BoyNames[Random.Next(BoyNames.Length)]));
            }
        }

        private void GenerateLessons()
        {
            for (int i = 0; i < 20; i++)
            {
                Lessons.Add(new Lesson(LessonNames[Random.Next(LessonNames.Length)]));
            }
        }
        private void GenerateDepartments()
        {
            for (int i = 0; i < 4; i++)
            {
                Departments.Add(new Department(DepartmentNames[i]));
            }
        }


    }
}
