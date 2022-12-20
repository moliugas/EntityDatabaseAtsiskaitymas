namespace EntityDB.Entity
{
    public class Lesson
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Department> Departments { get; set; }

        Lesson(string name)
        {
            Name = name;
        }
    }
}