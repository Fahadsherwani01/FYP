using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using FYP.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FYP.Controllers
{
    public class emailController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public IHostingEnvironment _env = null;
        public userDetailContext db = null;

        public emailController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IHostingEnvironment env, userDetailContext _db)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _env = env;
            db = _db;
        }

        public int messages()
        {
            string name=_userManager.GetUserName(User);
            
            IList<Email> unreaded = db.Email.Where(e => e.To == name && e.Read=="unreaded").ToList();

            int total=unreaded.Count();


            return total;
        }


        public IActionResult AdminMail(string gander, string bodypart, string diseace)
        {
            ViewBag.gander = gander;
            ViewBag.bodypart = bodypart;
            ViewBag.diseace = diseace;



            return View();
        }


        [HttpPost]
        public IActionResult AdminMail(string gander, string bodypart, string diseace, string gsSymptoms)
        {

            string msg = "Gander : " + gander + ", Bodypart : " + bodypart + ", Diseace : " + diseace + ", General Symptoms : " + gsSymptoms;

            Email mail = new Email();
            mail.To = "Admin";
            mail.From = _userManager.GetUserName(User);
            mail.Message = msg;
            mail.Read = "unreaded";
            mail.Date = DateTime.Now.Date.ToString();

            db.Email.Add(mail);
            db.SaveChanges();

            return View("ThanksPage");
        }

        public IActionResult readMessages(string to)
        {
            IList<Email> unreadedMails = db.Email.Where(e => e.To == to).ToList();
            
            if(unreadedMails!=null)
            {
                if (to == "Admin")
                {
                    return View(unreadedMails);
                }
                else
                {
                    return View("readMessagesForUser",unreadedMails);
                }
            }
            return View();
        }

        public IActionResult read(string id,string name)
        {
            int msgId = Int32.Parse(id);
            Email read = db.Email.Where(e => e.Id == msgId).Single();
            read.Read = "readed";

            db.Entry(read).State = EntityState.Modified;
            db.SaveChanges();

            if(name!="Admin")
            {
                return View("readForUser", read);
            }

            return View(read);
        }

        public IActionResult replyToUser(string to,string reply,string from1)
        {
            Email obj = new Email();
           
            obj.To = to;
            obj.From = from1;
            obj.Read = "unreaded";
            obj.Message = reply;
            obj.Date = DateTime.Now.Date.ToString();
            db.Email.Add(obj);
            db.SaveChanges();
            return View("replyThanks");
        }

    }
}
