using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using ProjectTAMA.Models;

namespace ProjectTAMA.Controllers
{
    public class HomeController : Controller
    {
        PlacesInfoDatabaseEntities1 _db = new PlacesInfoDatabaseEntities1();

        HotelInfoDatabaseEntities1 HotelDb = new HotelInfoDatabaseEntities1();

        UserInfoDatabaseEntities Db = new UserInfoDatabaseEntities();

        PlacesInfoDatabaseEntities2 RecomDb =new PlacesInfoDatabaseEntities2();


        public ActionResult Index()
        {
            //List<PlaceDescriptionViewModel> placeDesViewMdl = new List<PlaceDescriptionViewModel>();
            //List<PlaceDescriptionTable> placeDesTbl = _db.PlaceDescriptionTables.ToList();
            //foreach(var item in placeDesTbl)
            //{
            //    PlaceDescriptionViewModel placeDes = new PlaceDescriptionViewModel();
            //    placeDes.ID = item.ID;
            //    placeDes.PlaceName = item.PlaceName;
            //    placeDes.PlaceDescription = item.PlaceDescription;
            //    placeDes.Difficulty = item.Difficulty;
            //    placeDes.TimeOfVisit = item.TimeOfVisit;
            //    placeDes.HotelsAvailable = item.HotelsAvailable;

            //    placeDesViewMdl.Add(placeDes);

            //}

            //return View(placeDesViewMdl);
            return View();
        }

       

            public ActionResult Admin()
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
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PlaceDescriptionViewModel item)
        {
            HttpPostedFileBase fileUpload = Request.Files["TimeOfVisit"];
            string fileName = Path.GetFileName(fileUpload.FileName);

            PlaceDescriptionTable placeTbl = new PlaceDescriptionTable();

            placeTbl.ID = item.ID;
            placeTbl.PlaceName = item.PlaceName;
            placeTbl.PlaceDescription = item.PlaceDescription;
            placeTbl.Difficulty = item.Difficulty;
            placeTbl.TimeOfVisit = fileName;
            placeTbl.HotelsAvailable = item.HotelsAvailable;


            fileUpload.SaveAs(Server.MapPath("~/PlaceImages" + fileName));
            //var path = Path.Combine(Server.MapPath("~/PlaceImages/"), fileName);
            //fileUpload.SaveAs(path);
            _db.PlaceDescriptionTables.Add(placeTbl);
            _db.SaveChanges();

            return RedirectToAction("Admin");
        }
        //edit section
        public ActionResult Edit(int? id)
        {
            //List<PlaceDescriptionViewModel> placeDesViewMdl = new List<PlaceDescriptionViewModel>();
            //List<PlaceDescriptionTable> placeDesTbl = _db.PlaceDescriptionTables.ToList();

            PlaceDescriptionTable placeDescriptionTable = _db.PlaceDescriptionTables.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (placeDescriptionTable == null)
            {
                return HttpNotFound();
            }

            return View(placeDescriptionTable);

            //return View();
        }
        //Edit post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*[Bind(Include = "ID,PlaceName,PlaceDEscription,Difficulty,TimeOfVisit,HotelsAvailable")]*/ PlaceDescriptionTable placeDescriptionTable)
        {
            HttpPostedFileBase file = Request.Files["TimeOfVisit"];
            if (file != null) { 
            string fileName = Path.GetFileName(file.FileName);
                if (ModelState.IsValid)
                {
                    _db.Entry(placeDescriptionTable).State = EntityState.Modified;


                    PlaceDescriptionTable placeTbl = new PlaceDescriptionTable();

                    placeTbl.ID = placeDescriptionTable.ID;
                    placeTbl.PlaceName = placeDescriptionTable.PlaceName;
                    placeTbl.PlaceDescription = placeDescriptionTable.PlaceDescription;
                    placeTbl.Difficulty = placeDescriptionTable.Difficulty;
                    placeTbl.TimeOfVisit = fileName;
                    placeTbl.TimeOfVisit = placeDescriptionTable.TimeOfVisit;
                    placeTbl.HotelsAvailable = placeDescriptionTable.HotelsAvailable;

                    _db.Entry(placeTbl).State = EntityState.Modified;
                    //_db.PlaceDescriptionTables.Add(placeTbl);
                    _db.SaveChanges();

                    //_db.SaveChanges();

                    ViewBag.ErrorMessage = "Edited";
                    return RedirectToAction("Admin");
                }
                else
                    ViewBag.ErrorMessage = "Choose valid file.";
            }
        



            return View(placeDescriptionTable);
        }

        // GET: PlaceTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlaceDescriptionTable placeDesTable = _db.PlaceDescriptionTables.Find(id);
            if (placeDesTable == null)
            {
                return HttpNotFound();
            }
            return View(placeDesTable);
        }

        // POST: PlaceTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlaceDescriptionTable placeTable = _db.PlaceDescriptionTables.Find(id);
            _db.PlaceDescriptionTables.Remove(placeTable);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Places()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Hotels()
        {
            List<HotelDesViewModel> hotelInfo = new List<HotelDesViewModel>();
            List<HotelTable> hotelDes = HotelDb.HotelTables.ToList();
            CommonHotelModel commonHotelModel = new CommonHotelModel();

            foreach (var item in hotelDes)
            {
                HotelDesViewModel hotelTable = new HotelDesViewModel();

                hotelTable.Id = item.Id;
                hotelTable.HotelName = item.HotelName;
                hotelTable.HotelDescription = item.HotelDescription;
                hotelTable.HotelPlace = item.HotelPlace;
                hotelTable.HotelRating = item.HotelRating;
                hotelTable.Standard = item.Standard;

                hotelTable.HotelImage = item.HotelImage;
                hotelTable.BedImage = item.BedImage;
                hotelTable.BedImage1 = item.BedImage1;
                hotelTable.BedImage2 = item.BedImage2;

                hotelInfo.Add(hotelTable);

               
                commonHotelModel.hotelDesViewModel.Add(hotelTable);
            }

            return View(hotelInfo);

        }

        //Registration and login Controller

        public ActionResult Register()
        {
            return View();



        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegistrationTable registrationTable)
        {
            if (ModelState.IsValid)
            {
                Db.RegistrationTables.Add(registrationTable);
                Db.SaveChanges();




                return RedirectToAction("Index");



            }
            return View(registrationTable);

        }
        //    List<RegistrationViewModel> registrationTab= new List<RegistrationViewModel>();
        //    List<RegistrationTable> register = Db.RegistrationTables.ToList();

        //    foreach(var item in register)
        //    {
        //        RegistrationViewModel reg = new RegistrationViewModel();

        //        reg.County = item.County;
        //        registrationTab.Add(reg);

        //    }
        //    ViewBag.CountryList = registrationTab;
        //    Db.RegistrationTables.Add(registrationTable);
        //    Db.SaveChanges();
        //    return View(registrationTable);



        //}
        //Log out

        public ActionResult LogOff()

        {
            Session["UserName"] = null;
            Session["admin"] = null;
            Session.Abandon();

            return RedirectToAction("Index");
        }


        //Login Controller
        public ActionResult Login()
        {
            return View();
        }

        public static string userCountry = "";
       
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(RegistrationTable registrationTable)
        {

           
            if (ModelState.IsValid)
            {
                var details = (from userlist in Db.RegistrationTables
                               where userlist.UserName == registrationTable.UserName && userlist.Password == registrationTable.Password
                               select new { userlist.UserID,
                               userlist.UserName,userlist.County}).ToList();
                if (details.FirstOrDefault() != null)
                {
                    Session["UserId"] = details.FirstOrDefault().UserID;
                    
                    if (details.FirstOrDefault().UserName == "admin")
                    {
                        Session["admin"] = details.FirstOrDefault().UserName;
                    }
                    else
                    {
                        Session["UserName"] = details.FirstOrDefault().UserName;
                    }
                    Session["UserCountry"] = details.FirstOrDefault().County;
                    //if (Session["UserName"] == null)
                    //{
                    //    Session["UserName"] = "user";
                        
                    //}
                    userCountry = Session["UserCountry"].ToString();
                    //Session["UserName"] = details.FirstOrDefault().UserName;
                    //Session["County"] = details.FirstOrDefault().County;
                    return RedirectToAction("Index");
                }
               
            }

            
            else
            {
                ModelState.AddModelError("", "Invalid Credentials");
            }
           

            return View(registrationTable);
        }



        //Hotel Description part

        //Hotel Create


        public ActionResult HotelCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HotelCreate(HotelTable item)
        {
            HttpPostedFileBase HotelImage = Request.Files["HotelImage"];
            string fileName = Path.GetFileName(HotelImage.FileName);

            //HttpPostedFileBase BedImage = Request.Files["BedImage"];
            //string fileName1 = Path.GetFileName(BedImage.FileName);

            //HttpPostedFileBase BedImage1 = Request.Files["BedImage1"];
            //string fileName2 = Path.GetFileName(BedImage1.FileName);

            //HttpPostedFileBase BedImage2 = Request.Files["BedImage2"];
            //string fileName3 = Path.GetFileName(BedImage2.FileName);

            HotelTable hotelTable = new HotelTable();

            hotelTable.Id = item.Id;
            hotelTable.HotelName = item.HotelName;
            hotelTable.HotelDescription = item.HotelDescription;
            hotelTable.HotelPlace = item.HotelPlace;
            hotelTable.HotelRating = item.HotelRating;
            //hotelTable.Standard = item.Standard;

            hotelTable.HotelImage = fileName;
            //hotelTable.BedImage = fileName1;
            //hotelTable.BedImage1 = fileName2;
            //hotelTable.BedImage2 = fileName3;
           




            HotelImage.SaveAs(Server.MapPath("~/HotelImages" + fileName));

            //BedImage.SaveAs(Server.MapPath("~/HotelImages" + fileName1));

            //BedImage1.SaveAs(Server.MapPath("~/HotelImages" + fileName2));

            //BedImage2.SaveAs(Server.MapPath("~/HotelImages" + fileName3));
            //var path = Path.Combine(Server.MapPath("~/PlaceImages/"), fileName);
            //fileUpload.SaveAs(path);
            HotelDb.HotelTables.Add(hotelTable);
            HotelDb.SaveChanges();


            return RedirectToAction("Admin");
        }

        public ActionResult HotelAdmin()
        {
            List<HotelDesViewModel> hotelInfo = new List<HotelDesViewModel>();
            List<HotelTable> hotelDes = HotelDb.HotelTables.ToList();

            foreach (var item in hotelDes)
            {
                HotelDesViewModel hotelTable = new HotelDesViewModel();

                hotelTable.Id = item.Id;
                hotelTable.HotelName = item.HotelName;
                hotelTable.HotelDescription = item.HotelDescription;
                hotelTable.HotelPlace = item.HotelPlace;
                hotelTable.HotelRating = item.HotelRating;
                hotelTable.Standard = item.Standard;

                hotelTable.HotelImage = item.HotelImage;
                hotelTable.BedImage = item.BedImage;
                hotelTable.BedImage1 = item.BedImage1;
                hotelTable.BedImage2 = item.BedImage2;

                hotelInfo.Add(hotelTable);
            }

            return View(hotelInfo);
        }


        public ActionResult ReviewPost()
        {
            return View();
        }

        public ActionResult ReviewPost(HotelDesViewModel hotelDesView)
        {
            return View();
        }


        //Recommendations

        public ActionResult Recommendations()
        {
            List<IntermediateRecommendation> intermediateRecommendation = new List<IntermediateRecommendation>();

            List<RecommendationPas> recommendationPas = new List<RecommendationPas>();
            List<Pashupatinath_Tbl> pashupati = RecomDb.Pashupatinath_Tbl.ToList();

            List<RecommendationAnnapurna> recommendationAnnapurna = new List<RecommendationAnnapurna>();
            List<Annapurna_Tbl> annapurna = RecomDb.Annapurna_Tbl.ToList();

            List<RecommendationEverest> recommendationEverest = new List<RecommendationEverest>();
            List<Everest_Tbl> everest = RecomDb.Everest_Tbl.ToList();

            //pashupati
            foreach (var item in pashupati) {

                RecommendationPas reco = new RecommendationPas();
                reco.Id = item.Id;
                if (item.PercentageVisitors >= 0.20m)
                {
                    reco.Country = item.Country;
                    reco.Place_Name = item.Place_Name;
                }
               
               
                recommendationPas.Add(reco);

                foreach (var place in pashupati)
                {
                    IntermediateRecommendation interPlace = new IntermediateRecommendation();
                    if (userCountry == place.Country)
                    {
                        interPlace.recommendedPlaces = place.Place_Name;
                        intermediateRecommendation.Add(interPlace);
                    }
                }


            }
            //everest
            foreach (var item in everest)
            {

                RecommendationEverest recoeve = new RecommendationEverest();
                recoeve.Id = item.Id;
                if (item.PercentageVisitors >= 0.20m)
                {
                    recoeve.Country = item.Country;
                    recoeve.Place_Name = item.Place_Name;
                }

                recommendationEverest.Add(recoeve);

                foreach (var place in everest)
                {
                    IntermediateRecommendation interPlace = new IntermediateRecommendation();
                    if (userCountry == place.Country)
                    {
                        interPlace.recommendedPlaces = place.Place_Name;
                        intermediateRecommendation.Add(interPlace);
                    }
                }


            }


            //annapurna
            foreach (var item in annapurna)
            {

                RecommendationAnnapurna recoanna = new RecommendationAnnapurna();
                recoanna.Id = item.Id;
                if (item.PercentageVisitors >= 0.20m)
                {
                    recoanna.Country = item.Country;
                    recoanna.Place_Name = item.Place_Name;
                }

                recommendationAnnapurna.Add(recoanna);

                foreach(var place in recommendationAnnapurna)
                {
                    IntermediateRecommendation interPlace = new IntermediateRecommendation();
                    if (userCountry == place.Country)
                    {
                        interPlace.recommendedPlaces = place.Place_Name;
                        intermediateRecommendation.Add(interPlace);
                    }
                }


          }



            return View(intermediateRecommendation /*{*/
                //recommendationAnna = recommendationAnnapurna,
                //recommendationPasupat = recommendationPas,
                //recommendationEver=recommendationEverest
           

            /*}*/);
        }



    }
}





