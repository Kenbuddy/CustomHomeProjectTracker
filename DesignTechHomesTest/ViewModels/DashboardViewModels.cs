using DesignTechHomesTest.Models;

namespace DesignTechHomesTest.ViewModels
{
    public class ProjectGridViewModel
    {
        public DateTime? StartDateFrom { get; set; }
        public DateTime? StartDateTo { get; set; }
        public IEnumerable<StatusGroupViewModel> GroupedProjects { get; set; }
    }

    public class StatusGroupViewModel
    {
        public string Status { get; set; }
        public IEnumerable<Project> Projects { get; set; }
    }

}
