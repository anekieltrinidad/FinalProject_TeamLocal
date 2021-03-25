using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TeamLocal.Models
{
    public class Business
    {
        [Key]
        public int BusinessID { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [Display(Name = "Business Name")]
        public string BusinessName { get; set; }

        [Display(Name = "Business Address")]
        public string BusinessAddress { get; set; }

        [Display(Name = "Contact Information")]
        public string ContactInfo { get; set; }

        [DataType(DataType.MultilineText)]
        public string Overview { get; set; }

        [Display(Name = "Social Media Link")]
        public string SocialMedia { get; set; }

        public float Rating { get; set; }

        public BusinessType Category { get; set; }
    }

    public enum BusinessType
    {
        Food = 1,
        Clothing = 2,
        [Display(Name = "Car Services")]CarServices = 3,
        [Display(Name = "Health and Wellness")]Health = 4,
        [Display(Name = "Cleaning Services")] CleaningServices = 5,
        [Display(Name = "Home Improvement")] HomeImprovement = 6,
        Technology = 7,
        Other = 8

    }


}
