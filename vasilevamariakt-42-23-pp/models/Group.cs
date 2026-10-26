namespace vasilevamariakt_42_23_pp.models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Course { get; set; }
        public bool IsDeleted { get; set; }

        public int SpecialtyId { get; set; }
        public Specialty Specialty { get; set; } = null!;

        public List<Student> Students { get; set; } = new();
    }
}
