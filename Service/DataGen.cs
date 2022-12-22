using EntityDB.Entity;

namespace EntityDB.Service
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
        public void GenerateStudents(int amount = 200)
        {
            for (int i = 0; i < amount; i++)
            {
                Students.Add(new Student(Random.Next() % 2 == 2 ? GirlNames[Random.Next(GirlNames.Length)] : BoyNames[Random.Next(BoyNames.Length)]));
            }
        }

        public void GenerateLessons(int amount = 20)
        {
            for (int i = 0; i < amount; i++)
            {
                Lessons.Add(new Lesson(LessonNames[Random.Next(LessonNames.Length)]));
            }
        }
        public void GenerateDepartments(int amount = 2)
        {
            for (int i = 0; i < amount; i++)
            {
                Departments.Add(new Department(DepartmentNames[i]));
            }
        }


    }
}
