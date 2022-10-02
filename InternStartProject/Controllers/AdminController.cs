using BusinessLayer.Concrete;
using DataAccessLayer.EntittFramework;
using EntityLayer;
using InternStartProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Timers;

namespace InternStartProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        PingManager pingManager = new PingManager(new EfPingDal());
        LogManager logManager = new LogManager(new EfLogDal());



        public AdminController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.name = values.Name;
            userEditViewModel.surname = values.Surname;
            userEditViewModel.phonenumber = values.PhoneNumber;
            userEditViewModel.mail = values.Email;
            userEditViewModel.userName = values.UserName;
            return View(userEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            user.Name = p.name;
            user.Surname = p.surname;
            user.Email = p.mail;
            user.PhoneNumber = p.phonenumber;
            user.UserName = p.userName;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.password);
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }
            return View();
        }

        [HttpGet]
        public IActionResult UrlEkle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UrlEkle(Ping ping)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var pingUrl = ping.PingUrl.ToString();

            try
            {
                HttpWebRequest httreq = (HttpWebRequest)WebRequest.Create(pingUrl);
                httreq.AllowAutoRedirect = false;

                HttpWebResponse httpResponse = (HttpWebResponse)httreq.GetResponse();


                var pingStatusCode = (int)httpResponse.StatusCode;
                ping.PingStatusCode = pingStatusCode.ToString();

                var pingDescription = httpResponse.StatusDescription;
                ping.PingDescription = pingDescription;
                ping.AddedDate = DateTime.Now;
                ping.UserId = user.Id;


                pingManager.TAdd(ping);
                httpResponse.Close();
            }
            //catch (WebException e)
            //{
            //    var pingStatusCode = (int)e.Status;
            //    ping.PingStatusCode = pingStatusCode.ToString();
            //    var pingDescription = e.Status;
            //    ping.PingDescription = pingDescription.ToString();
            //    pingManager.TAdd(ping);

            //}
            catch (Exception e)
            {
                var pingDescription = e.Message;
                ping.PingDescription = pingDescription.ToString();
                pingManager.TAdd(ping);


            }


            return View("Profile");
        }


        [HttpGet]
        public async Task<IActionResult> UrlView()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var values = pingManager.GetByFilter(x => x.UserId == user.Id);
            return View(values);
        }
        public IActionResult DeleteURL(int id)
        {
            var values = pingManager.TGetByID(id);
            pingManager.TDelete(values);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Logging()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logging(Log log)
        {


            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(LoggingTime);
            aTimer.Interval = 120000;
            aTimer.Enabled = true;


            return RedirectToAction("Profile");
        }
        public static void LoggingTime(object source, ElapsedEventArgs e)
        {

            Loggings();

        }

        public static void Loggings()
        {
            

            PingManager pingManager = new PingManager(new EfPingDal());
            LogManager logManager = new LogManager(new EfLogDal());

            Log log;


            var values = pingManager.TGetList();

            foreach (var item in values)
            {
                try
                {

                    HttpWebRequest httreq = (HttpWebRequest)WebRequest.Create(item.PingUrl);
                    httreq.AllowAutoRedirect = false;

                    HttpWebResponse httpResponse = (HttpWebResponse)httreq.GetResponse();

                    var logStatusCode = (int)httpResponse.StatusCode;
                    var logDescription = httpResponse.StatusDescription;
                    log = new Log();
                    log.PingId = item.PingId;
                    log.LogStatus = logStatusCode.ToString();
                    log.LogDescirption = logDescription;
                    log.AddedDate = DateTime.Now;
                    log.UserId = item.UserId;
                    httpResponse.Close();


                    logManager.TAdd(log);

                }

                catch (Exception e)
                {






                }

            }
        }


        [HttpGet]
        public async Task<IActionResult> LoggingView()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var values = logManager.GetByFilter(x => x.UserId == user.Id);
            return View(values);
        }
    }
}


