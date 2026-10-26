using System.Text.RegularExpressions;

namespace vasilevamariakt_42_23_pp.models
{
    public class Specialty
    {
        public int SpecialtyId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;

        public List<Group> Groups { get; set; } = new();
    }
}
