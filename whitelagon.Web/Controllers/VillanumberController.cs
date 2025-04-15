using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using whitelagon.Web.ViewModel;
using Whitelagon.admin.Entities;
using Whitelagon.Infrastructure.Data;

namespace whitelagon.Web.Controllers
{
    public class VillanumberController : Controller
    {
        private ApplicationDbcontext db;

        public VillanumberController(ApplicationDbcontext _Db)
        {
            db = _Db;
        }
        public IActionResult Index()
        {
            var villas = db.Villanumbers.Include(v => v.Villa).ToList();

            return View(villas);
        }
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> List = db.Villas.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            ViewData["SelectList"] = List;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Villanumber villa)
        {
         if (ModelState.IsValid)
            {
                db.Villanumbers.Add(villa);                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(villa);
        }
        public IActionResult Update(int id)
        {
            VillaNumberVm villaNumberVM = new VillaNumberVm()
            {
                Villanumber = new Villanumber(),
                List = db.Villas.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            ViewData["SelectList"] = villaNumberVM.List;
            var villaNum = db.Villanumbers.FirstOrDefault(v => v.Villa_Number== id);
            if (villaNum == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villaNum);
        }
        [HttpPost]
       public IActionResult Update(Villanumber villa)
        {
         
            if (ModelState.IsValid)
            {
                db.Villanumbers.Update(villa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(villa);
        }
        public IActionResult Delete(int id)
        {
            VillaNumberVm villaNumberVM = new VillaNumberVm()
            {
                Villanumber = new Villanumber(),
                List = db.Villas.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            ViewData["SelectList"] = villaNumberVM.List;
            var villa = db.Villanumbers.FirstOrDefault(v => v.Villa_Number == id);
            if (villa == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villa);
        }

        [HttpPost]
        public IActionResult Delete(Villanumber villa)
        {
            if (villa == null)
            {
                return RedirectToAction("Error", "Home");
            }
            db.Villanumbers.Remove(villa);
            db.SaveChanges();
            TempData["Success"] = "The villa has been deleted Successfuly";
            return RedirectToAction("Index");

        }
    }
}
