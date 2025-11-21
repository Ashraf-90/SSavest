using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Infrastructure.Persistence.Reposities;
using Microsoft.AspNetCore.Http;
using System.Numerics;

namespace Savest.Controllers.Dashboard
{
    public class HeroBannerController : Controller
    {
        private readonly IHeroBannerServices _HeroBannerServices;

        public HeroBannerController(IHeroBannerServices HeroBannerServices)
        {
            _HeroBannerServices = HeroBannerServices;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                if (HttpContext.Session.GetString("AdminID") != null)
                {
                    var HeroBanner = await _HeroBannerServices.GetAllHeroBanner();
                    return View(HeroBanner); // Passing to the view
                }
                else { return RedirectToAction("Index", "AdminLogIn"); }
            }
            catch
            {
                return RedirectToAction("Index", "AdminLogIn");
            }

        }


        public IActionResult Create()
        {
            try
            {
                if (HttpContext.Session.GetString("AdminID") != null)
                {
                    return View();
                }
                else { return RedirectToAction("Index", "AdminLogIn"); }
            }
            catch
            {
                return RedirectToAction("Index", "AdminLogIn");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HeroBannerDTo model)
        {
            if (ModelState.IsValid)
            {
                var result = await _HeroBannerServices.AddNewHeroBanner(model);
                if (result)
                {
                    TempData["SuccessMessage"] = "KeyWord created successfully!";
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Unable to create KeyWord. Please try again.");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                if (HttpContext.Session.GetString("AdminID") != null)
                {
                    var HeroBanner = await _HeroBannerServices.GetAllHeroBanner();
                    var metaPage = HeroBanner.FirstOrDefault(b => b.Id == id);

                    if (metaPage == null)
                        return NotFound();

                    return View(metaPage);
                }
                else { return RedirectToAction("Index", "AdminLogIn"); }
            }
            catch
            {
                return RedirectToAction("Index", "AdminLogIn");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(HeroBannerDTo model)
        {
            if (ModelState.IsValid)
            {
                var HeroBanner = await _HeroBannerServices.GetAllHeroBanner();
                var existingHeroBanner = HeroBanner.FirstOrDefault(b => b.Id == model.Id);

                if (existingHeroBanner == null)
                    return NotFound();

                var result = await _HeroBannerServices.UpdateHeroBanner(model);
                if (result)
                    return RedirectToAction("Index");

                ModelState.AddModelError("", "Unable to update HeroBanner.");
            }

            return View(model);
        }
    }
}
