using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTAMA.Models
{
    public class PlaceInfoModelView
    {
        public int PlaceID { get; set; }
        public string PlaceName { get; set; }
        public string PlaceDescription { get; set; }
        public byte[] PlaceImage { get; set; }
    }
}