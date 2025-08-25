using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Models.Models
{
    public  class Product
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Title Of Category")]
        public string? Title { get; set; }

        public string Description { get; set; }
        public string ISBN { get; set; }
        public string  Author { get; set; }
        [Display(Name ="List Of Price")]
        [Range(1,100)]
        public Double ListPrice { get; set; }

        [Display(Name = "Price for 1-50")]
        [Range(1, 100)]
        public Double Price { get; set; }
        [Display(Name = "Price for 50+")]
        [Range(1, 100)]
        public Double Price50 { get; set; }

        [Display(Name = "Price for 100+")]
        [Range(1, 100)]
        public Double Price100 { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
        [ValidateNever]
        public string? ImageUrl { get; set; } 
    }
}
