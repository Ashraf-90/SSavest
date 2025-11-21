using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Infrastructure.Persistence.Reposities;
using Microsoft.AspNetCore.Http;
using System.Numerics;

namespace Savest.Controllers.Dashboard
{
    public class MetaPagesController : Controller
    {
        private readonly IMetaPagesServices _metaPagesServices;

        public MetaPagesController(IMetaPagesServices metaPagesServices)
        {
            _metaPagesServices = metaPagesServices;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                if (HttpContext.Session.GetString("AdminID") != null)
                {
                    var MetaPages = await _metaPagesServices.GetAllMetaPages();
                    return View(MetaPages); // Passing to the view
                }
                else { return RedirectToAction("Index", "AdminLogIn"); }
            }
            catch
            {
                return RedirectToAction("Index", "AdminLogIn");
            }
           
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                if (HttpContext.Session.GetString("AdminID") != null)
                {
                    var metaPages = await _metaPagesServices.GetAllMetaPages();
                    var metaPage = metaPages.FirstOrDefault(b => b.Id == id);

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
        public async Task<IActionResult> Edit(MetaPagesDTo model)
        {
            if (ModelState.IsValid)
            {
                var MetaPages = await _metaPagesServices.GetAllMetaPages();
                var existingMetaPages = MetaPages.FirstOrDefault(b => b.Id == model.Id);

                if (existingMetaPages == null)
                    return NotFound();

                var result = await _metaPagesServices.UpdateMetaPages(model);
                if (result)
                    return RedirectToAction("Index");

                ModelState.AddModelError("", "Unable to update MetaPages.");
            }

            return View(model);
        }
    }
}
