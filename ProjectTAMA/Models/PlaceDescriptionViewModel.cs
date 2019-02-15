using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectTAMA.Models
{
    public class PlaceDescriptionViewModel
    {
        [Key]
        public int ID { get; set; }
        [Display(Name="Place Name")]
        public string PlaceName { get; set; }
        [Display(Name = "Place Description")]

        public string PlaceDescription { get; set; }
        [Display (Name = "Difficulty Level")]
        public Nullable<int> Difficulty { get; set; }
        [Display(Name = "Photo of Place")]
        public string TimeOfVisit { get; set; }
        [Display(Name = "Hotels Available")]
        public Nullable<int> HotelsAvailable { get; set; }
    }
}