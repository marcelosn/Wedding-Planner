﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Google.Maps;
using Google.Maps.StaticMaps;
using Google.Maps.Geocoding;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {

        private MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Session") == null)
            {
                return View("Index");
            }
            else
            {
                return RedirectToAction("Dashboard");
            }
        }

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpPost("register")]
        public IActionResult register(User user)
        {
            if (ModelState.IsValid)
            {
                if (dbContext.Users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Password = Hasher.HashPassword(user, user.Password);
                dbContext.Add(user);
                dbContext.SaveChanges();
                HttpContext.Session.SetInt32("UserID", user.UserId);
                HttpContext.Session.SetString("Session", "True");
                return RedirectToAction("Dashboard");
            }
            return View("Index");
            // other code
        }

        [HttpPost("login")]
        public IActionResult Login(LoginUser userSubmission)
        {
            if (ModelState.IsValid)
            {
                var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == userSubmission.LoginEmail);
                if (userInDb == null)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
                    return View("Index");
                }

                var hasher = new PasswordHasher<LoginUser>();

                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.LoginPassword);

                if (result == 0)
                {
                    ModelState.AddModelError("LoginPassword", "Invalid Password");
                    return View("Index");
                }
                HttpContext.Session.SetInt32("UserID", userInDb.UserId);
                HttpContext.Session.SetString("Session", "True");
                return RedirectToAction("Dashboard");
            }
            return View("Index");
        }

        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("Session") == null)
            {
                return RedirectToAction("Index");
            }
            else
            {


                ViewBag.Userid = HttpContext.Session.GetInt32("UserID");
                ViewBag.AllWed = dbContext.Weddings
                .Include(c => c.WedtoUser)
                .ToList();
                return View();
            }
        }

        [Route("newwedding")]
        [HttpGet]
        public IActionResult NewWedding()
        {
            if (HttpContext.Session.GetString("Session") == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Userid = HttpContext.Session.GetInt32("UserID");
                return View();
            }
        }

        [Route("btAddWed")]
        [HttpPost]
        public IActionResult btAddWed(Wedding newWed)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(newWed);
                dbContext.SaveChanges();
                return RedirectToAction("DetailWed", new { id = newWed.WeddingId });
            }
            else
            {
                return View("NewWedding");
            }
        }

        [Route("detail/{id}")]
        [HttpGet]
        public IActionResult DetailWed(int id)
        {
            Wedding a = dbContext.Weddings.FirstOrDefault(pro => pro.WeddingId == id);
            ViewBag.Wedinfo = a;
            var ListGuest = dbContext.Weddings
            .Include(per => per.WedtoUser)
            .ThenInclude(x => x.User)
            .FirstOrDefault(y => y.WeddingId == id);

            ViewBag.ListGuest = ListGuest;


            GoogleSigned.AssignAllServices(new GoogleSigned("PersonalGoogleAPIRemovedForSecurityPurposes"));

            var request = new GeocodingRequest();
            request.Address = a.WedAddress;
            var response = new GeocodingService().GetResponse(request);

            if (response.Status == ServiceResponseStatus.Ok && response.Results.Count() > 0)
            {
                var result = response.Results.First();
                Console.WriteLine("Full Address: " + result.FormattedAddress);
                Console.WriteLine("Latitude: " + result.Geometry.Location.Latitude);
                Console.WriteLine("Longitude: " + result.Geometry.Location.Longitude);
                Console.WriteLine();
                ViewBag.Lati = result.Geometry.Location.Latitude;
                ViewBag.Long = result.Geometry.Location.Longitude;
            }
            else
            {
                Console.WriteLine("Unable to geocode.  Status={0} and ErrorMessage={1}", response.Status, response.ErrorMessage);
            }

            return View();
        }

        [Route("addrsvp/{wedid}/{userid}")]
        [HttpGet]
        public IActionResult addrsvp(int wedid, int userid)
        {
            Wedding newWed = dbContext.Weddings.Include(c => c.WedtoUser).ThenInclude(b => b.User).FirstOrDefault(wed => wed.WeddingId == wedid);
            User newUser = dbContext.Users.Include(c => c.UsertoWed).ThenInclude(b => b.Wedding).FirstOrDefault(us => us.UserId == userid);
            foreach (var thiswed in newUser.UsertoWed)
            {
                if (thiswed.Wedding.WedDate.Date == newWed.WedDate.Date)
                {
                    ModelState.AddModelError("WedDate", "You have plan to go to another wedding on that day already!!!");
                    ViewBag.samedayrs = "You have plan to go to another wedding on that day already!!!";
                    return RedirectToAction("Dashboard");
                }
            }


            WedConnect a = new WedConnect();
            a.WeddingId = wedid;
            a.UserId = userid;
            dbContext.Add(a);
            dbContext.SaveChanges();
            return RedirectToAction("DetailWed", new { id = wedid });
        }

        [Route("unrsvp/{id}")]
        [HttpGet]
        public IActionResult unrsvp(int id)
        {
            WedConnect a = dbContext.WedConnects.FirstOrDefault(web => web.WedConnectId == id);
            dbContext.Remove(a);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [Route("delete/{wedid}")]
        [HttpGet]
        public IActionResult delete(int wedid)
        {
            Wedding a = dbContext.Weddings.FirstOrDefault(web => web.WeddingId == wedid);

            dbContext.Remove(a);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }
    }
}