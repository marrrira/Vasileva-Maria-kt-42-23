namespace vasilevamariakt_42_23_pp.models;

public class Discipline
{
    public int DisciplineId { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }

    public List<Grade> Grades { get; set; } = new();
}