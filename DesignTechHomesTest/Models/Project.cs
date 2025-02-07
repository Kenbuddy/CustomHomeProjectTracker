using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DesignTechHomesTest.Models
{
    public enum ProjectStatus
    {
        [Description("Not Started")]
        NotStarted,

        [Description("In Progress")]
        InProgress,

        [Description("Complete")]
        Complete
    }

    public class Project : BaseModel
    {
        #region Properties

        public int Id { get; set; }

        [Required]
        public string Name { get; set; } 

        public int ClientId { get; set; }



        // Again, breaking these Address properties out as a separate table/object might be a good idea.
        public string? AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? PostalCode { get; set; } = string.Empty;
      

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EstimatedCompletionDate { get; set; }

        public ProjectStatus Status { get; set; } = ProjectStatus.NotStarted;

        public decimal Budget { get; set; }

        #endregion

        #region Navigation Properties

        public Client? Client { get; set; }

        public IList<ImageUpload> ImageUploads { get; set; } = new List<ImageUpload>();

        public IList<ProjectNote> ProjectNotes { get; set; } = new List<ProjectNote>();

        #endregion
    }
}
