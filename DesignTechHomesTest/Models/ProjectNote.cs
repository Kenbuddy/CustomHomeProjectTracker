using System.ComponentModel.DataAnnotations;

namespace DesignTechHomesTest.Models
{
    public class ProjectNote
    {
        #region Properties

        public int Id { get; set; }

        public int ProjectId { get; set; }

        public DateTime Timestamp { get; set; }

        [Required]
        public string Note { get; set; }

        #endregion

        #region Navigation Properties

        public Project? Project { get; set; }

        #endregion
    }
}
