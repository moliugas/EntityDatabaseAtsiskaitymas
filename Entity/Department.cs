namespace EntityDB.Entity
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public List<Lesson> Lessons { get; set; }

        public Department(string name) {
            Name = name;
        }
    }
}