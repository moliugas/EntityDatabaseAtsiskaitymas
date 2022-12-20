using EntityDB.Entity;

namespace EntityDB
{
    public class DataGen
    {
        public List<Student> Students { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<Department> Departments { get; set; }

        private Random Random = new Random();

        private readonly string[] GirlNames = new[] { "Sofija", "Emilija", "Luknė", "Amelija", "Kamilė", "Lėja", "Gabija", "Patricija", "Elija", "Liepa" };
        private readonly string[] BoyNames = new[] { "Markas", "Benas", "Jokūbas", "Dominykas", "Herkus", "Adomas", "Lukas", "Jonas", "Matas", "Kajus" };
        private readonly string[] LessonNames = new[] { "Math", "Chemistry", "Physics", "Calculus", "Biology", "Physical Education", "Arts", "English", "Flat Geo" };

        DataGen()
        {
        }
        public void GenerateAll()
        {
            GenericGenerate(Students);
            GenericGenerate(Lessons, 10);
            GenericGenerate(Departments);
        }
        private void GenericGenerate<T>(List<T> list, int amount = 150) where T : class
        {
            Console.WriteLine(typeof(T));

            for (int i = 0; i < amount; i++)
            {
                //list.Add(new T());
            }
        }

        private List<String> GetNamesByClass(string type)
        {
            switch (type)
            {
                case "EntityDB.Entity.Student":
                    return Random.Next % 2 == 2 ? GirlNames[Random.Next(GirlNames.Length)] : GirlNames[Random.Next(GirlNames.Length)];
                case "EntityDB.Entity.Lesson"
                case "EntityDB.Entity.Department"
            }

            return new();
        }

    }
}
