using AssignmentCityTech.Models;
using AssignmentCityTech.Utility;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentCityTech.Controllers
{
    public class VendorMasterController : Controller
    {
        DataAccessLayer dal = new DataAccessLayer();
        public IActionResult Index()
        {
            List<VendorModel> vendors = dal.GetAllVendor();
            return View(vendors);
        }

        [HttpPost]
        public ActionResult Index(VendorModel vendor)
        {
            var msg = false;
            try
            {
                ReturnModel returnModel = dal.AddStudent(vendor);
                return Json(returnModel);
            }
            catch (InvalidCastException ex)
            {
                TempData["ERROR"] = ex.ToString();
                return RedirectToAction("Index", "ERROR");
            }
        }


    }
}
