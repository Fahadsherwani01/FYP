using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using FYP.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FYP.Controllers
{
    
    public class guestController : Controller
    {

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        private userDetailContext mycon = null;
        public guestController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, userDetailContext con)
        {

            _signInManager = signInManager;
            _userManager = userManager;
            mycon = con;
        }


        // GET: api/values
        public IActionResult MainPatientCategory()
        {
                return View();
            
        }

        public IActionResult FamilyMan()
        {
            
                return View();
            
        }

        public IActionResult FamilyWomen()
        {
              return View();
        

        }
        public IActionResult FamilyChild()
        {
              return View();
            


        }


        public IActionResult diseaseSelector(string key)
        {
           
                return View("diseaseSelector");
            

        }


        public IActionResult Selector(string key, string img)
        {
            ViewBag.imgURL = "/images/pics/male/male-" + img + ".jpg";
            
                IEnumerable<string> subCategory = (from p in mycon.Tbladminmedicationrecord
                                                   where p.Bodypart == key
                                                   select p.Disease).Distinct();
                return View("diseaseSelector", subCategory);
           
            

        }


        public IActionResult GSymptomsSelector(string key)
        {
           
                return View("GSymptomsSelector");
          

        }


        public IActionResult GSSelector(string key, string img)
        {
            ViewBag.url = img;
           

                IEnumerable<string> subCategory = from p in mycon.Tbladminmedicationrecord
                                                  where p.Disease == key
                                                  select p.Generalsymptoms;
              




                return View("GSymptomsSelector", subCategory);
          

        }


        public IActionResult MedicineSelector(string key)
        {
           
                return View("MedicineSelector");
            


        }


        public IActionResult MSelector(string key)
        {

            
                PrescriptionDetail preObject = new PrescriptionDetail();
                MedicalHistory medObject = new MedicalHistory();

                var subCategory = (from p in mycon.Tbladminmedicationrecord
                                   where p.Generalsymptoms == key
                                   select new
                                   {
                                       med = p.Medicine,
                                       dos = p.Dosage,
                                       prec = p.Precautions,
                                       diet = p.Diet

                                   }).ToList();


                foreach (var r in subCategory)
                {
                    string abc = DateTime.Now + "asffasd";
                    preObject.PrescriptionId = abc;
                    medObject.PrescriptionId = abc;

                    preObject._1medicinePerDay = r.med;
                    medObject.Diet = r.diet + "," + r.dos;
                    medObject.Disease = key;
                   
                

                  

                    var data = Tuple.Create(r.diet, r.dos, r.med, r.prec);
                    return View("MedicineSelector", data);
                }
                return View();



            




        }

    }
}
