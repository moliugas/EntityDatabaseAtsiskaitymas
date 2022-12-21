namespace EntityDB.Entity
{
    public class Lesson
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public List<Department> Departments { get; set; }

        public Lesson(string name)
        {
            Name = name;
            Departments = new List<Department>();
        }
    }
}