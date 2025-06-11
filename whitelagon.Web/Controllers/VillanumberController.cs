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
        private readonly ApplicationDbcontext _db;

        public VillanumberController(ApplicationDbcontext db)
        {
            _db = db;
        }

       public IActionResult Index()
        {
            var villas = _db.Villanumbers.Include(v => v.Villa).ToList();
            return View(villas);
        }

        public IActionResult Create()
        {
            PopulateVillaDropdown();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Villanumber villaNumber)
        {
            if (ModelState.IsValid)
            {
                _db.Villanumbers.Add(villaNumber);
                _db.SaveChanges();
                TempData["Success"] = "Villa Number created successfully.";
                return RedirectToAction(nameof(Index));
            }
            PopulateVillaDropdown();
            return View(villaNumber);
        }

        public IActionResult Update(int id)
        {
            var villaNumber = _db.Villanumbers.FirstOrDefault(v => v.Villa_Number == id);
            if (villaNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }
            PopulateVillaDropdown();
            return View(villaNumber);
        }

        [HttpPost]
        public IActionResult Update(Villanumber villaNumber)
        {
            if (ModelState.IsValid)
            {
                _db.Villanumbers.Update(villaNumber);
                _db.SaveChanges();
                TempData["Success"] = "Villa Number updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            PopulateVillaDropdown();
            return View(villaNumber);
        }

        public IActionResult Delete(int id)
        {
            var villaNumber = _db.Villanumbers.Include(v => v.Villa).FirstOrDefault(v => v.Villa_Number == id);
            if (villaNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villaNumber);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var villaNumber = _db.Villanumbers.FirstOrDefault(v => v.Villa_Number == id);
            if (villaNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }
            _db.Villanumbers.Remove(villaNumber);
            _db.SaveChanges();
            TempData["Success"] = "Villa Number deleted successfully.";
            return RedirectToAction(nameof(Index));
        }

        private void PopulateVillaDropdown()
        {
            var villaList = _db.Villas.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            }).ToList();
            ViewData["SelectList"] = villaList;
        }
    }
}
