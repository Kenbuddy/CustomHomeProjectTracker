using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DesignTechHomesTest.Models
{
    public class BaseModel
    {
        #region Audit Properties

        public DateTime CreatedOn { get; set; }

        [Required]
        [MaxLength(450)]
        public string CreatedBy { get; set; }

        [Required]
        public IdentityUser? CreatedByUser { get; set; }

        
        
        public DateTime ModifiedOn { get; set; }

        [Required]
        [MaxLength(450)]
        public string ModifiedBy { get; set; }

        public IdentityUser? ModifiedByUser { get; set; }

        #endregion
    }
}
