using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Driving License")]
        public string DrivingLicense { get; set; }
    }
}