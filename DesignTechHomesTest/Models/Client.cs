using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignTechHomesTest.Models
{
    public class Client : BaseModel
    {
        #region Properties

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{LastName}, {FirstName}";



        // Client could have multiple addresses, and we might want to break these Address properties out as a separate table/object, but we'll keep it simple here.

        public string? AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? PostalCode { get; set; }



        /// <summary>
        /// This could be broken out into a separate table as well for a one-to-many relationship, but we'll keep it simple for now.
        /// </summary>
        public string? EmailAddress { get; set; }

        /// <summary>
        /// This could be broken out into a separate table as well for a one-to-many relationship, but we'll keep it simple for now.
        /// </summary>
        public string? PhoneNumber { get; set; }

        #endregion

        #region Navigation Properties

        public IList<Project> Projects { get; set; } = new List<Project>();

        #endregion
    }
}
