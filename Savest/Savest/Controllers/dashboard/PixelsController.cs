using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Infrastructure.Persistence.Reposities;
using Microsoft.AspNetCore.Http;
using System.Numerics;

namespace Savest.Controllers.Dashboard
{
    public class PixelsController : Controller
    {
        private readonly IPixelsServices _PixelsServices;

        public PixelsController(IPixelsServices PixelsServices)
        {
            _PixelsServices = PixelsServices;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                if (HttpContext.Session.GetString("AdminID") != null)
                {
                    var Pixels = await _PixelsServices.GetAllPixels();
                    return View(Pixels); // Passing to the view
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
        public async Task<IActionResult> Create(PixelsDTo model)
        {
            if (ModelState.IsValid)
            {
                var result = await _PixelsServices.AddNewPixels(model);
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
                    var Pixels = await _PixelsServices.GetAllPixels();
                    var metaPage = Pixels.FirstOrDefault(b => b.Id == id);

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
        public async Task<IActionResult> Edit(PixelsDTo model)
        {
            if (ModelState.IsValid)
            {
                var Pixels = await _PixelsServices.GetAllPixels();
                var existingPixels = Pixels.FirstOrDefault(b => b.Id == model.Id);

                if (existingPixels == null)
                    return NotFound();

                var result = await _PixelsServices.UpdatePixels(model);
                if (result)
                    return RedirectToAction("Index");

                ModelState.AddModelError("", "Unable to update Pixels.");
            }

            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _PixelsServices.DeletePixelsAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
