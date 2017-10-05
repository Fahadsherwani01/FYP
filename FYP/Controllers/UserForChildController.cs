using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FYP.Models;
using Microsoft.AspNetCore.Identity;

namespace FYP.Controllers
{
    public class UserForChildController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        private userDetailContext mycon = null;
        public UserForChildController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, userDetailContext con)
        {

            _signInManager = signInManager;
            _userManager = userManager;
            mycon = con;
        }


        public IActionResult WelcomeUser()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return View();
            }
            else
            {
                return Redirect("/home/noreply");
            }

        }

        public IActionResult MainPatientCategory()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return View();
            }
            else
            {
                return Redirect("/home/noreply");
            }

            
        }
        public IActionResult FamilyMan()
        {
            if (_signInManager.IsSignedIn(User))
            {
                 return View();
            }
            else
            {
               return Redirect("/home/noreply");
              
            }

           
        }
        public IActionResult FamilyWomen()
        {
            if (_signInManager.IsSignedIn(User))
            {
                 return View();
            }
            else
            {
                return Redirect("/home/noreply");
            }

           
        }
        public IActionResult FamilyChild()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return View();
            }
            else
            {
                return Redirect("/home/noreply");
            }

          
        }

      

        public IActionResult diseaseSelector(string key)
        {
            if (_signInManager.IsSignedIn(User))
            {
                return View("diseaseSelector");
            }
            else
            {
                return Redirect("/home/noreply");
            }

            
        }


        public IActionResult Selector(string key, string img)
        {
            ViewBag.imgURL = "/images/pics/children/child-" + img + ".jpg";
            if (_signInManager.IsSignedIn(User))
            {
                 IEnumerable<string> subCategory = (from p in mycon.tableForChild
                                               where p.Bodypart == key
                                               select p.Disease).Distinct();
                  return View("diseaseSelector",subCategory);
            }
            else
            {
                return Redirect("/home/noreply");
            }

           



        
        }

        public IActionResult GSymptomsSelector(string key)
        {
            if (_signInManager.IsSignedIn(User))
            {
                return View("GSymptomsSelector");
            }
            else
            {
                return Redirect("/home/noreply");
            }

           
        }


        public IActionResult GSSelector(string key, string img)
        {
            ViewBag.url = img;
            if (_signInManager.IsSignedIn(User))
            {

            IEnumerable<string> subCategory = from p in mycon.tableForChild
                                              where  p.Disease == key
                                              select p.Generalsymptoms;
            foreach(string r in subCategory)
            {
                string name = r;
            }


            

            return View("GSymptomsSelector", subCategory);
            }
            else
            {
                return Redirect("/home/noreply");
            }

        }

        public IActionResult MedicineSelector(string key)
        {
            if (_signInManager.IsSignedIn(User))
            {
                return View("MedicineSelector");
            }
            else
            {
                return Redirect("/home/noreply");
            }


        }


        public IActionResult MSelector(string key)
        {

            if (_signInManager.IsSignedIn(User))
            {
                PrescriptionDetail preObject = new PrescriptionDetail();
                MedicalHistory medObject = new MedicalHistory();

                var subCategory = (from p in mycon.tableForChild
                                              where p.Generalsymptoms == key
                                              select new
                                              {
                                                  med = p.Medicine,
                                                  dos = p.Dosage,
                                                  prec = p.Precautions,
                                                  diet=p.Diet

                                              }).ToList();

            
            foreach (var r in subCategory)
            {
                    string abc = DateTime.Now+"asffasd";
                    preObject.PrescriptionId = abc;
                    medObject.PrescriptionId = abc;

                    preObject._1medicinePerDay = r.med;
                    medObject.Diet = r.diet+","+r.dos;
                    medObject.Disease = key;
                    string name = _userManager.GetUserName(User);
                    User obj= mycon.User.Where(s => s.Email == name).Single();
                    medObject.MdId = obj.MdId;

                    mycon.MedicalHistory.Add(medObject);
                    mycon.PrescriptionDetail.Add(preObject);

                    mycon.SaveChanges();

                    var data = Tuple.Create(r.diet, r.dos, r.med, r.prec);
                    return View("MedicineSelector", data);
            }
                    return View();



            }
            else
            {
                return Redirect("/home/noreply");
            }

    

          
        }

        public IActionResult userMedicalDetail()
        {
            IList<PrescriptionDetail> pre = new List<PrescriptionDetail>();
            string name = _userManager.GetUserName(User);
            User obj = mycon.User.Where(s => s.Email == name).Single();
            medicalDetail medDetail = new medicalDetail();
            IList<MedicalHistory> med = mycon.MedicalHistory.Where(s => s.MdId == obj.MdId).ToList();

            foreach (var r in med)
            {


                pre = mycon.PrescriptionDetail.Where(s => s.PrescriptionId == r.PrescriptionId).ToList();

                string[] r_name = r.Diet.Split(',');
                medDetail.Disease = r.Disease;
                medDetail.dose = r_name[1];
                medDetail.Diet = r_name[0];
                break;
            }


            foreach (var r in pre)
            {
                medDetail.medicine = r._1medicinePerDay;



                var data = Tuple.Create(medDetail.Diet, medDetail.dose, medDetail.Disease, medDetail.medicine);

                return View(data);
            }
            return View("WelcomeUser");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
