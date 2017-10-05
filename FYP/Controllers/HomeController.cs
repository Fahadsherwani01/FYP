using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using FYP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace FYP.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public IHostingEnvironment _env = null;
        public userDetailContext db = null;

        public HomeController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IHostingEnvironment env,userDetailContext _db)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _env = env;
            db = _db;
        }


        public IActionResult Index()
         {
            if (_signInManager.IsSignedIn(User))
            {
                var name = _userManager.GetUserName(User);
                User mydata = db.User.Where(s => s.Email == name).Single();
                if (mydata.Admin=="yes")
                {
                    return View("/Admin/Index");
                }


                return RedirectToAction("/user/welcomeuser");
            }
            else
            {
                return View("noreply");
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult noreply()
        {
            return View();
        }
        public IActionResult DataTable()
        {
            return View();
        }

        public IActionResult Index2()
        {
            var name = _userManager.GetUserName(User);
            if (name != null)
            {
                User mydata = db.User.Where(s => s.Email == name).First();
                if (mydata.Admin == "yes")
                {
                    return Redirect("/Admin/Index");
                }
            }

            IEnumerable<feedback> obj = db.feedback.ToList();

            return View(obj);
        }

        public IActionResult firstPage()
        {
            return View();
        }

        public IActionResult registerUser()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult feedbackView()
        {
            return View();
        }

        [HttpPost]
        public IActionResult feedbackView(feedback msg)
        {

            db.feedback.Add(msg);
            db.SaveChanges();
            return View();
        }


        [HttpGet]
        public IActionResult userProfile()
        {
            string name = _userManager.GetUserName(User);

            

            User mydata = db.User.Where(s => s.Email == name).FirstOrDefault();

            if (mydata == null)
            {
                return View();
            }

            if (mydata.Admin=="yes")
            {
                return Redirect("/Admin/Index");
            }

           

         
            else
            {
                return Redirect("/user/MainPatientCategory");
            }

        }

        [HttpPost]
        public IActionResult userProfile(ICollection<IFormFile> abc,User data)
        {
            string rootPath = _env.WebRootPath;
            string folderpath = rootPath + "/profilePic/";

            string picName = Request.Form.Files["pic"].FileName;

            string fullPathPic = folderpath + picName;

            Request.Form.Files["pic"].CopyTo(new System.IO.FileStream(fullPathPic, System.IO.FileMode.Create));

            data.ProfilePic = fullPathPic;
            data.Email = _userManager.GetUserName(User);
            data.MdId = data.UserName + DateTime.Now;
            MedicalHistory md = new MedicalHistory();
            
            md.MdId = data.MdId;
            db.MedicalHistory.Add(md);

            db.User.Add(data);
            db.SaveChanges();


            return Redirect("/user/MainPatientCategory");
        }

        public IActionResult layout1()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return Redirect("/Account/Logout");


        }

        public IActionResult userProfileView()
        {
            string name = _userManager.GetUserName(User);
            User mydata = db.User.Where(s => s.Email == name).Single();
         
           
           //IQueryable<User> userData = from mydata in db.User
           //                 where mydata.Email == name
           //                 select mydata;
           // User dta = userData.First();

            return View(mydata);
        }

        public IActionResult email(string Name,string Email,string Phone_no,string Message)
        {
            MailMessage EmailObject = new MailMessage();
            EmailObject.From = new MailAddress(Email, Name);
            EmailObject.To.Add(new MailAddress("fahadsherwani01@gmail.com", "samba123"));
            EmailObject.Subject = "FeedBack";
            EmailObject.Body = Message+"          "+Phone_no;

            SmtpClient SC = new SmtpClient("smtp.gmail.com", 587);
            SC.Credentials = new System.Net.NetworkCredential("fahadsherwani01@gmail.com", "samba123");
            SC.EnableSsl = true;
            SC.Send(EmailObject);

            return View("thanksPage");
        }


        public async Task<ActionResult> apiConnect()
        {
            var req = WebRequest.Create(@"http://myweb123fahad.000webhostapp.com/singin2.php");
            var r = await req.GetResponseAsync().ConfigureAwait(false);

            var responseReader = new StreamReader(r.GetResponseStream());
            var responseData = await responseReader.ReadToEndAsync();
            
            var d = Newtonsoft.Json.JsonConvert.DeserializeObject<jsonData>(responseData);
            return View(d);
        }

    }
}
