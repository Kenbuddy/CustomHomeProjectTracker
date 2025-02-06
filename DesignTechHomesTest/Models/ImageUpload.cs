using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignTechHomesTest.Models
{
   
    public class ImageUpload
    {
        #region Properties

        public int Id { get; set; }

        public int ProjectId { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public byte[] ImageData { get; set; }

        #endregion

        #region Navigation Properties

        public Project? Project { get; set; }

        #endregion
    }

}
