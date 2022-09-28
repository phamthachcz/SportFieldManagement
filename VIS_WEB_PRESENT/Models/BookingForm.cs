using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VIS_WEB_PRESENT.Models
{
    public class BookingForm
    {
        [Required]
        public int FacilityID { get; set; }

        [Required]
        public string TimeBook { get; set; }

        [Required]
        public int Payment { get; set; }
    }
}