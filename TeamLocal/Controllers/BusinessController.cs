using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using TeamLocal.Data;
using TeamLocal.Models;
using Microsoft.AspNetCore.Authorization;

namespace TeamLocal.Controllers
{
    [Authorize(Roles = "BusinessOwner")]
    public class BusinessController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BusinessController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.Businesses.Include(b => b.CategoryBusiness).ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Business record)
        {
            var business = new Business();
            business.BusinessName = record.BusinessName;
            business.BusinessAddress = record.BusinessAddress;
            business.ContactInfo = record.ContactInfo;
            business.Overview = record.Overview;
            business.SocialMedia = record.SocialMedia;
            business.Category = record.Category;

            _context.Businesses.Add(business);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var business = _context.Businesses.Where(b => b.BusinessID == id).SingleOrDefault();
            if (business == null)
            {
                return RedirectToAction("Index");
            }

            return View(business);
        }

        [HttpPost]
        public IActionResult Edit(int? id, Business record)
        {
            var business = _context.Businesses.Where(b => b.BusinessID == id).SingleOrDefault();
            business.BusinessName = record.BusinessName;
            business.BusinessAddress = record.BusinessAddress;
            business.ContactInfo = record.ContactInfo;
            business.Overview = record.Overview;
            business.SocialMedia = record.SocialMedia;
            business.Category = record.Category;

            _context.Businesses.Update(business);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var business = _context.Businesses.Where(b => b.BusinessID == id).SingleOrDefault();
            if (business == null)
            {
                return RedirectToAction("Index");
            }

            _context.Businesses.Remove(business);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }



    }
}
