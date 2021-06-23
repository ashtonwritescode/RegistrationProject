using System;
using System.ComponentModel.DataAnnotations;

namespace RegistrationProject.Models
{
    public class CustomerModel
    {
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "Entry for field exceeds allowable character length")]
        [Required(ErrorMessage = "A first name is required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "Entry for field exceeds allowable character length")]
        [Required(ErrorMessage = "A last name is required")]
        public string LastName { get; set; }

        [Display(Name = "Address Line 1")]
        [StringLength(50, ErrorMessage = "Entry for field exceeds allowable character length")]
        [Required(ErrorMessage = "An address is required")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2 (Optional)")]
        [StringLength(50, ErrorMessage = "Entry for field exceeds allowable character length")]
        public string AddressLine2 { get; set; }

        [Display(Name = "City")]
        [StringLength(35, ErrorMessage = "Entry for field exceeds allowable character length")]
        [Required(ErrorMessage = "A city is required")]
        public string City { get; set; }

        [Display(Name = "State")]
        [RegularExpression(@"^((?!NA).)*$", ErrorMessage = "A state is required")]
        [Required(ErrorMessage = "A state is required")]
        public string State { get; set; }

        [Display(Name = "ZIP Code")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "ZIP code is invalid")]
        [Required(ErrorMessage = "A zip code is required")]
        public string Zipcode { get; set; }

        [Display(Name = "Country")]
        [StringLength(30, ErrorMessage = "Entry for field exceeds allowable character length")]
        [Required(ErrorMessage = "A country is required")]
        public string Country { get; set; }

        [Display(Name = "Registration Date")]
        public DateTime RegistrationDate { get; set; }
    }
}