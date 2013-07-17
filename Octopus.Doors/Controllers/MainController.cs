using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Octopus.Doors.Controllers
{
    public class MainController : Controller
    {
        //
        // GET: /Main/

        /// <summary>
        /// Главная страница
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Отображает фрагмент главной страницы
        /// </summary>
        /// <returns></returns>
        public ActionResult IndexPart()
        {
            return PartialView();
        }

        /// <summary>
        /// Отображает стандартную страницу с дверью
        /// </summary>
        /// <returns></returns>
        public ActionResult Standart()
        {
            return View();
        }

        /// <summary>
        /// Отображает фрагмент стандартной двери
        /// </summary>
        /// <returns></returns>
        public ActionResult StandartPart()
        {
            return PartialView();
        }

        /// <summary>
        /// Отображает стандартную страницу с дверью
        /// </summary>
        /// <returns></returns>
        public ActionResult Premium()
        {
            return View();
        }

        /// <summary>
        /// Отображает фрагмент премиум страницы
        /// </summary>
        /// <returns></returns>
        public ActionResult PremiumPart()
        {
            return PartialView();
        }

        /// <summary>
        /// Отображает стандартную страницу с дверью
        /// </summary>
        /// <returns></returns>
        public ActionResult FireProof()
        {
            return View();
        }

        /// <summary>
        /// Отображает фрагмент страницы с противопожарными дверями
        /// </summary>
        /// <returns></returns>
        public ActionResult FireProofPart()
        {
            return PartialView();
        }

        /// <summary>
        /// Отображает стандартную страницу с дверью
        /// </summary>
        /// <returns></returns>
        public ActionResult Articles()
        {
            return View();
        }

        /// <summary>
        /// Отображает фрагмент страницы  со статьями
        /// </summary>
        /// <returns></returns>
        public ActionResult ArticlesPart()
        {
            return PartialView();
        }

        /// <summary>
        /// Отображает стандартную страницу с дверью
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            return View();
        }

        public ActionResult AboutPart()
        {
            return PartialView();
        }

        /// <summary>
        /// Отображает страницу для оптовиков
        /// </summary>
        /// <returns></returns>
        public ActionResult Whosale()
        {
            return View();
        }
    }
}
