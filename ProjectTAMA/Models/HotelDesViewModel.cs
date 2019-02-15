using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectTAMA.Models
{
    public class HotelDesViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Hotel")]
        public string HotelName { get; set; }

        [Display(Name = "Hotel Description")]
        public string HotelDescription { get; set; }

        [Display(Name = "Place of hotel")]
        public string HotelPlace { get; set; }

        [Display(Name = "rating")]
        public Nullable<int> HotelRating { get; set; }

        [Display(Name = "Hotel image")]
        public string HotelImage { get; set; }

        [Display(Name = "Room1")]
        public string BedImage { get; set; }

        [Display(Name = "Room2")]
        public string BedImage1 { get; set; }

        [Display(Name = "Room3")]
        public string BedImage2 { get; set; }

        [Display(Name = "Standard")]
        public string Standard { get; set; }
    }
}