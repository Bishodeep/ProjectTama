using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectTAMA.Models
{
    public class IntermediateRecommendation
    {
        [Key]
        public int id;

      // public List<RecommendationAnnapurna> recommendationAnna { get; set; }
      // public List<RecommendationEverest> recommendationEver { get; set; }
      //public  List<RecommendationPas> recommendationPasupat { get; set; }
        [Display(Name ="Places For You")]
        public string recommendedPlaces { get; set; }
    }
}