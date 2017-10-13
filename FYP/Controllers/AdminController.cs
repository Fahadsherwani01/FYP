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

        public IActionResult addCondition(string id, string name)
        {

           


            int msgId = Int32.Parse(id);
            Email read = db.Email.Where(e => e.Id == msgId).Single();
            read.Read = "readed";

            db.Entry(read).State = EntityState.Modified;
            db.SaveChanges();
            Tbladminmedicationrecord data = new Tbladminmedicationrecord();

            ViewBag.to = read.To;
            ViewBag.from = read.From;
            


            string[] message = read.Message.Split(',');

            
            string[] Gender = message[0].Split(':');
            string[] Bodypart = message[1].Split(':');
            string[] Diseace = message[2].Split(':');
            string[] General = message[3].Split(':');

            data.Gender = Gender[1];
            data.Disease = Diseace[1];
            data.Generalsymptoms = General[1];
            data.Bodypart = Bodypart[1];
            


            return View(data);
        }


        public IActionResult addToTable(Tbladminmedicationrecord obj,string bp,string temp,string hb)
        {
            obj.Bloodpresure = bp;
            obj.Temprature = temp;
            obj.Heartbeat = hb;
            string gender = obj.Gender;
            
                if(gender=="Man")
                    {
                        db.Tbladminmedicationrecord.Add(obj);
                        db.SaveChanges();
                       
                    }
                else if(gender=="Female")
                    {
                        tableForWomen obj2 = new tableForWomen();
                        obj2.Bloodpresure = obj.Bloodpresure;
                        obj2.Bodypart = obj.Bodypart;
                        obj2.Diet = obj.Diet;
                        obj2.Disease = obj.Disease;
                        obj2.Dosage = obj.Dosage;
                        obj2.Gender = obj.Gender;
                        obj2.Generalsymptoms = obj.Generalsymptoms;
                        obj2.Heartbeat = obj.Heartbeat;
                        obj2.Medicine = obj.Medicine;
                        obj2.Precautions = obj.Precautions;
                        obj2.Temprature = obj.Temprature;
                       

                        db.tableForWomen.Add(obj2);
                        db.SaveChanges();
                       
                    }
                else if(gender== "Child")
                    {
                        tableForChild obj2 = new tableForChild();
                        obj2.Bloodpresure = obj.Bloodpresure;
                        obj2.Bodypart = obj.Bodypart;
                        obj2.Diet = obj.Diet;
                        obj2.Disease = obj.Disease;
                        obj2.Dosage = obj.Dosage;
                        obj2.Gender = obj.Gender;
                        obj2.Generalsymptoms = obj.Generalsymptoms;
                        obj2.Heartbeat = obj.Heartbeat;
                        obj2.Medicine = obj.Medicine;
                        obj2.Precautions = obj.Precautions;
                        obj2.Temprature = obj.Temprature;
                        db.tableForChild.Add(obj2);
                        db.SaveChanges();
                        
                    }
            
            return View("");
        }


    }
}
