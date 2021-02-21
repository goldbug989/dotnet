using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCApp.Models.ViewModels
{
    public class Person
    {
        public int PersonID { get; set; }

        [Display(Name="First Name")]
        [StringLength(50)]
        [Required(ErrorMessage ="Please Enter First Name")]
        public string FirstName { get; set; }

        [Display(Name ="Last Name")]
        [Required(ErrorMessage = "Please enter Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }


    }
}
