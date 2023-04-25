using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace To_Do_List.Models
{

    public class To_Do
    {
        public int Id { get; set; }

        // Setting requirements for attributes as shown below:

        [StringLength(60, MinimumLength=3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Title must begin with a capital letter and be a minimum 3 characters long with a maximum of 60 characters.")] // Requires first letter to be a capital letter, allows other text to be written afterwards, \s matches any whitespace characters
        [Required] // Indicates property must have a value
        public string? Title { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Completed?")]
        public bool checkbox { get; set; }

    }
}
