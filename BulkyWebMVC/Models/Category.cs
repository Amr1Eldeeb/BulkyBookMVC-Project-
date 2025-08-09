using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWebMVC.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        [DisplayName("Name Of Category")]
        public string? Name { get; set; }
        [DisplayName("DisplayOrder Of Category")]//server sside validations for modelstate
        [Required]
        [Range(1,10,ErrorMessage ="Amr Eldeeb") ]
        public int DisplayOrder { get; set; }



    }
}
