using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StuWare.Data.Migrations;
using StuWare.Data.Repository;
using StuWare.Helpers;
using StuWare.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StuWare.Controllers
{
    public class HomeController : StuwareController
    {

        private IPanelRepository _panelRepository;

        public HomeController(IPanelRepository panelRepository)
        {
            _panelRepository = panelRepository;
        }

        public IActionResult Index()
        {
            return View(_panelRepository.Panels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Panel entity, IFormFile file)
        {

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            entity.Image = file.FileName;

            if (ModelState.IsValid)
            {
                _panelRepository.CreatePanel(entity);
                return RedirectToAction("Index");
            }
            else
            {
                return View(entity);
            }
        }

        public IActionResult Delete(int id)
        {
            _panelRepository.DeletePanel(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_panelRepository.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Details(Panel entity, IFormFile file)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            entity.Image = file.FileName;

            if (ModelState.IsValid)
            {
                _panelRepository.UptadePanel(entity);

                return RedirectToAction("Index");
            }
            else
            {
                return View(entity);
            }
        }


    }
}
