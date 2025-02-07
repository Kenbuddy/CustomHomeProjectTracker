using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace DesignTechHomesTest.Models
{
    public class BaseModel
    {
        #region Audit Properties

        [BindNever]
        public DateTime CreatedOn { get; set; }

        [BindNever]
        [MaxLength(450)]
        public string CreatedBy { get; set; }



        [BindNever]
        public DateTime ModifiedOn { get; set; }

        [BindNever]
        [MaxLength(450)]
        public string ModifiedBy { get; set; }

        #endregion
    }
}
