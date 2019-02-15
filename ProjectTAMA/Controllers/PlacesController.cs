using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectTAMA.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Net;

namespace ProjectTAMA.Controllers
{
    public class PlacesController : Controller
    {
        PlacesInfoDatabaseEntities1 _db = new PlacesInfoDatabaseEntities1();
        // GET: Places
        public ActionResult Index()
        {

            List<PlaceDescriptionViewModel> placeDesViewMdl = new List<PlaceDescriptionViewModel>();
            List<PlaceDescriptionTable> placeDesTbl = _db.PlaceDescriptionTables.ToList();
            foreach (var item in placeDesTbl)
            {
                PlaceDescriptionViewModel placeDes = new PlaceDescriptionViewModel();
                placeDes.ID = item.ID;
                placeDes.PlaceName = item.PlaceName;
                placeDes.PlaceDescription = item.PlaceDescription;
                placeDes.Difficulty = item.Difficulty;
                placeDes.TimeOfVisit = item.TimeOfVisit;
                placeDes.HotelsAvailable = item.HotelsAvailable;

                placeDesViewMdl.Add(placeDes);


            }
            return View(placeDesViewMdl);

            //return View();
        }


        //placeDetail Info

        public ActionResult PlaceDetail(int? id)
        {
            List<PlaceDescriptionViewModel> placeDesViewMdl = new List<PlaceDescriptionViewModel>();
            List<PlaceDescriptionTable> placeDesTbl = _db.PlaceDescriptionTables.ToList();

            PlaceDescriptionTable placeDescriptionTable = _db.PlaceDescriptionTables.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (placeDescriptionTable == null)
            {
                return HttpNotFound();
            }

           
                PlaceDescriptionViewModel placeDes = new PlaceDescriptionViewModel();
                placeDes.ID = placeDescriptionTable.ID;
                placeDes.PlaceName = placeDescriptionTable.PlaceName;
                placeDes.PlaceDescription = placeDescriptionTable.PlaceDescription;
                placeDes.Difficulty = placeDescriptionTable.Difficulty;
                placeDes.TimeOfVisit = placeDescriptionTable.TimeOfVisit;
                placeDes.HotelsAvailable = placeDescriptionTable.HotelsAvailable;

                //placeDesViewMdl.Add(placeDes);


           
            return View(placeDes);
            //return View();
        }

        public ActionResult Create()
        {
            return View();
        }

      
    }
}