using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Whitelagon.admin.Entities;
using Whitelagon.Application.Common;
using Whitelagon.Application.Common.Utility;
using Whitelagon.Infrastructure.Data;
using Whitelagon.Infrastructure.Repository;

namespace whitelagon.Web.Controllers
{
    [Authorize(Roles =SD.Role_Admin)]
    public class VillaController : Controller
    {
        private Iunitofwork Unit;
        private readonly IWebHostEnvironment webHost;

        public VillaController(Iunitofwork _Unit,IWebHostEnvironment _webHost )
        {
            Unit = _Unit;
            webHost = _webHost;
        }
     
        public IActionResult Index()
        {
            IEnumerable<Villa> villas = Unit.Villa.GetAll(null,null);
                return View(villas);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Villa villa)
        {
            if (villa.Name == villa.Description)
            {
                ModelState.AddModelError("Name", "The Name and Description cannot be the same.");
            }
            if (ModelState.IsValid)
            {
                if (villa.Image != null)
                {
                                    
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(villa.Image.FileName);

                    string folderPath = Path.Combine(webHost.WebRootPath, "Images", "VillaImage");
                    string filePath = Path.Combine(folderPath, filename);


                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        villa.Image.CopyTo(fileStream);
                    }
                    villa.ImageUrl = filename;
                }else
                {
                    villa.ImageUrl = villa.ImageUrl;
                }
                Unit.Villa.Add(villa);
                Unit.Villa.Save();
                return RedirectToAction("Index");
            }
            return View(villa);
        }


        public IActionResult Update(int id)
        {
            var villa = Unit.Villa.Get(v => v.Id == id);
            if (villa == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villa);
        }
        [HttpPost]
        public IActionResult Update(Villa villa)
        {
            if (villa.Name == villa.Description)
            {
                ModelState.AddModelError("Name", "The Name and Description cannot be the same.");
            }
            if (ModelState.IsValid)
            {
               if(!string.IsNullOrEmpty(villa.ImageUrl))
                {
                    var oldImagePath = Path.Combine(webHost.WebRootPath, "Images", "VillaImage", villa.ImageUrl);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                if (villa.Image != null)
                {

                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(villa.Image.FileName);

                    string folderPath = Path.Combine(webHost.WebRootPath, "Images", "VillaImage");
                    string filePath = Path.Combine(folderPath, filename);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    { 
                        villa.Image.CopyTo(fileStream);
                    }
                    villa.ImageUrl = filename;
                }
                else
                {
                    villa.ImageUrl = villa.ImageUrl;
                }
                Unit.Villa.Update(villa);
                Unit.Save();
                return RedirectToAction("Index");
            }
            return View(villa);
        }
        public IActionResult Delete(int id)
        {
           
            
            var villa = Unit.Villa.Get(v => v.Id == id);
            if (villa == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villa);
        }

        [HttpPost]
        public IActionResult Delete(Villa villa)
        {
            if (villa == null)
            {
                return RedirectToAction("Error", "Home");
            }
            Unit.Villa.Remove(villa);
            Unit.Villa.Save();
            TempData["Success"] = "The villa has been deleted Successfuly";
            return RedirectToAction("Index");

        }
    }
}
