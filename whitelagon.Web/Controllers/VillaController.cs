using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Whitelagon.admin.Entities;
using Whitelagon.Application.Common;
using Whitelagon.Application.Common.Utility;
using Whitelagon.Infrastructure.Data;
using Whitelagon.Infrastructure.Repository;

namespace whitelagon.Web.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class VillaController : Controller
    {
        private readonly Iunitofwork _unitOfWork;

        public VillaController(Iunitofwork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var villas = _unitOfWork.Villa.GetAll(null, null);
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
                _unitOfWork.Villa.Add(villa);
                _unitOfWork.Save();
                TempData["Success"] = "Villa created successfully.";
                return RedirectToAction(nameof(Index));
            }

            return View(villa);
        }

        public IActionResult Update(int id)
        {
            var villa = _unitOfWork.Villa.Get(v => v.Id == id);
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
                _unitOfWork.Villa.Update(villa);
                _unitOfWork.Save();
                TempData["Success"] = "Villa updated successfully.";
                return RedirectToAction(nameof(Index));
            }

            return View(villa);
        }

        public IActionResult Delete(int id)
        {
            var villa = _unitOfWork.Villa.Get(v => v.Id == id);
            if (villa == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villa);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var villa = _unitOfWork.Villa.Get(v => v.Id == id);
            if (villa == null)
            {
                return RedirectToAction("Error", "Home");
            }

            _unitOfWork.Villa.Remove(villa);
            _unitOfWork.Save();
            TempData["Success"] = "Villa deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
    }
}
