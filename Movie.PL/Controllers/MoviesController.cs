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
                model.Poster = FileUploader.UploadFile("Images", model.File);
                if (ModelState.IsValid)
                {
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
        #endregion
    }
}
