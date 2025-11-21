using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Infrastructure.Persistence.Reposities;
using Microsoft.AspNetCore.Http;
using System.Numerics;

namespace Savest.Controllers.Dashboard
{
    public class KeyWordsController : Controller
    {
        private readonly IKeyWordsServices _KeyWordsServices;

        public KeyWordsController(IKeyWordsServices KeyWordsServices)
        {
            _KeyWordsServices = KeyWordsServices;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                if (HttpContext.Session.GetString("AdminID") != null)
                {
                    var KeyWords = await _KeyWordsServices.GetAllKeyWords();
                    return View(KeyWords); // Passing to the view
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
        public async Task<IActionResult> Create(KeyWordsDTo model)
        {
            if (ModelState.IsValid)
            {
                var result = await _KeyWordsServices.AddNewKeyWords(model);
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
                    var KeyWords = await _KeyWordsServices.GetAllKeyWords();
                    var metaPage = KeyWords.FirstOrDefault(b => b.Id == id);

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
        public async Task<IActionResult> Edit(KeyWordsDTo model)
        {
            if (ModelState.IsValid)
            {
                var KeyWords = await _KeyWordsServices.GetAllKeyWords();
                var existingKeyWords = KeyWords.FirstOrDefault(b => b.Id == model.Id);

                if (existingKeyWords == null)
                    return NotFound();

                var result = await _KeyWordsServices.UpdateKeyWords(model);
                if (result)
                    return RedirectToAction("Index");

                ModelState.AddModelError("", "Unable to update KeyWords.");
            }

            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _KeyWordsServices.DeleteKeyWordsAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
