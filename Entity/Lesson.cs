namespace EntityDB.Entity
{
    public class Lesson
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Department> Departments { get; set; }

        public Lesson(string name)
        {
            Name = name;
        }
    }
}