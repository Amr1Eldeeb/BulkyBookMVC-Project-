using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Models.Models
{
    public  class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]

        [DisplayName("Title Of Category")]
        public string? Title { get; set; }
        [Required]

        public string Description { get; set; }
        [Required]

        public string ISBN { get; set; }
        [Required]
        public string  Author { get; set; }
        [Required]
        [Display(Name ="List Of Price")]
        [Range(1,100)]
        public Double ListPrice { get; set; }

        [Required]
        [Display(Name = "Price for 1-50")]
        [Range(1, 100)]
        public Double Price { get; set; }
        [Required]
        [Display(Name = "Price for 50+")]
        [Range(1, 100)]
        public Double Price50 { get; set; }

        [Required]
        [Display(Name = "Price for 100+")]
        [Range(1, 100)]
        public Double Price100 { get; set; }
    }
}
