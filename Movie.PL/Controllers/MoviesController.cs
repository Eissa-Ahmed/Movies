using Microsoft.AspNetCore.Mvc;
using Movie.BL.Helper;
using Movie.BL.Interfaces;
using Movie.BL.Model;

namespace Movie.PL.Controllers
{
    public class MoviesController : Controller
    {
        #region Properties
        private readonly IMovies MoviesServices;
        private readonly IGeners GenersServices;
        #endregion

        #region Ctor
        public MoviesController(IMovies MoviesServices , IGeners GenersServices)
        {
            this.MoviesServices = MoviesServices;
            this.GenersServices = GenersServices;
        }
        #endregion

        #region Action

        public async Task<IActionResult> Index()
        {
            var data = await MoviesServices.GetMovies();
            return View(data);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.ListGeners = await GenersServices.GetGeners();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MoviesVM model)
        {
            ViewBag.ListGeners = await GenersServices.GetGeners();
            try
            {
                //Check Extension File
                if (!ValidateFile.CheckExtensionFile(model.File))
                {
                    ModelState.AddModelError("Poster", "Only .png , .jpg Imaged Are Allowed");
                    return View(model);
                }
                //Check Size File
                if (ValidateFile.CheckSizeFile(model.File))
                {
                    ModelState.AddModelError("Poster", "Only Size Allowed is 1MB");
                    return View(model);
                }
                //Check model is valid
                if (ModelState.IsValid)
                {
                    model.Poster = FileUploader.UploadFile("Images", model.File);
                    await MoviesServices.CreateMovies(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMovies"] = ex.Message;
                return View(model);
            }
            
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            var item = await MoviesServices.GetMoviesById(id);
            await MoviesServices.DeleteMovies(id);
            FileUploader.RemoveFile("Images", item.Poster);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            ViewBag.ListGeners = await GenersServices.GetGeners();
            var data = await MoviesServices.GetMoviesById(id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Update(MoviesVM model)
        {
            ViewBag.ListGeners = await GenersServices.GetGeners();
            try
            {
                //Check Extension File
                if (!ValidateFile.CheckExtensionFile(model.File))
                {
                    ModelState.AddModelError("Poster", "Only .png , .jpg Imaged Are Allowed");
                    return View(model);
                }
                //Check Size File
                if (ValidateFile.CheckSizeFile(model.File))
                {
                    ModelState.AddModelError("Poster", "Only Size Allowed is 1MB");
                    return View(model);
                }
                //Check model is valid
                if (ModelState.IsValid)
                {
                    model.Poster = FileUploader.UploadFile("Images", model.File);
                    await MoviesServices.UpdateMovies(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMovies"] = ex.Message;
                return View(model);
            }
        }
        #endregion
    }
}
