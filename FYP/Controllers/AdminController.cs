using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using FYP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FYP.Controllers
{
    public class AdminController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public IHostingEnvironment _env = null;
        public userDetailContext db = null;

        public AdminController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IHostingEnvironment env, userDetailContext _db)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _env = env;
            db = _db;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult userList()
        {
            IList<User> user = db.User.Where(s => s.Admin == "no").ToList();

            return View(user);
        }

        public IActionResult adminList()
        {
            IList<User> user = db.User.Where(s => s.Admin == "yes").ToList();

            return View(user);
        }

        public string addAdmin(string email)
        {
            User admin = db.User.Where(s => s.Email == email).Single();

            admin.Admin = "yes";

            db.Entry(admin).State = EntityState.Modified;
            db.SaveChanges();
            return "yes";
        }

        public string removeAdmin(string email)
        {
            User admin = db.User.Where(s => s.Email == email).Single();

            admin.Admin = "no";

            db.Entry(admin).State = EntityState.Modified;
            db.SaveChanges();
            return "yes";
        }

        public IActionResult userDetail()
        {
            IList<User> userList = db.User.ToList();
            return View(userList);
        }

        public IActionResult userProfile(string email)
        {
            
            User profile = db.User.Where(s => s.Email == email).Single();

            return View(profile);
        }

        public IActionResult userCheckupHsitory(string email)
        {
            PrescriptionDetail pre = new PrescriptionDetail();
            
            User obj = db.User.Where(s => s.Email == email).Single();
            medicalDetail medDetail = new medicalDetail();
            List<medicalDetail> listMedicalDetail = new List<medicalDetail>();
            IList<MedicalHistory> med = db.MedicalHistory.Where(s => s.MdId == obj.MdId).ToList();

            foreach (var r in med)
            {


                pre = db.PrescriptionDetail.Where(s => s.PrescriptionId == r.PrescriptionId).Single();


                medDetail.medicine = pre._1medicinePerDay;
                string[] r_name = r.Diet.Split(',');




                listMedicalDetail.Add(new medicalDetail() { Disease = r.Disease, dose = r_name[1], Diet = r_name[0], medicine = pre._1medicinePerDay });



            }


            return View(listMedicalDetail);

            
        }

        [HttpGet]
        public IActionResult medicalConditionEntry()
        {
            return View();
        }

        [HttpPost]
        public IActionResult medicalConditionEntry(Tbladminmedicationrecord record, string bloodpressure, string part, string age, string heartbeat, string temperature)
        {


                record.Bloodpresure = bloodpressure;
                record.Bodypart = part;
                record.Temprature = temperature;
                record.Heartbeat = heartbeat;
                record.Gender = age;

               if(age=="Male")
                {
                    db.Tbladminmedicationrecord.Add(record);
                    db.SaveChanges();
                }

               else if(age=="Female")
                {
                    tableForWomen recordFor = new tableForWomen();
                recordFor.Bloodpresure = bloodpressure;
                recordFor.Bodypart = part;
                recordFor.Heartbeat = heartbeat;
                recordFor.Bloodpresure = bloodpressure;
                recordFor.Gender = age;
                record.Diet = record.Diet;
                recordFor.Disease = record.Disease;
                recordFor.Dosage = record.Dosage;
                recordFor.Generalsymptoms = record.Generalsymptoms;
                recordFor.Medicine = record.Medicine;
                recordFor.Precautions = record.Precautions;
                    
                    db.tableForWomen.Add(recordFor);
                    db.SaveChanges();
                }
               else if(age== "Child")
                {
                    tableForChild recordFor = new tableForChild();
                    recordFor.Bloodpresure = bloodpressure;
                recordFor.Bodypart = part;
                recordFor.Heartbeat = heartbeat;
                recordFor.Bloodpresure = bloodpressure;
                recordFor.Gender = age;
                record.Diet = record.Diet;
                recordFor.Disease = record.Disease;
                recordFor.Dosage = record.Dosage;
                recordFor.Generalsymptoms = record.Generalsymptoms;
                recordFor.Medicine = record.Medicine;
                recordFor.Precautions = record.Precautions;
                db.tableForChild.Add(recordFor);
                    db.SaveChanges();

                return Redirect("/Admin/medicalConditionEntry");
                }


            

            return View();
        }


        public int messages()
        {
         

            IList<Email> unreaded = db.Email.Where(e => e.To == "Admin" && e.Read == "unreaded").ToList();

            int total = unreaded.Count();


            return total;
        }


    }
}
