using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

        /// <summary>
        /// Обрабатывает новый лид с формы обратной связи
        /// </summary>
        /// <param name="name">Имя пользователя</param>
        /// <param name="phone">телефон</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Lead(string name, string phone)
        {
            // Получаем email куда отправлять
            var targetEmail = System.Configuration.ConfigurationManager.AppSettings["feedbackEmail"];

            // Подгатавливаем клиент и сообщение к отправке
            var client = new SmtpClient()
            {
                EnableSsl = true,
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential("tracker@trust-media.ru", "NetTracker"),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            var message = new MailMessage(new MailAddress("tracker@trust-media.ru","Сайт Двери-ДВ"), new MailAddress(targetEmail))
            {
                IsBodyHtml = true,
                Subject = "Получен новый лид на сайте Двери-ДВ",
                Body = String.Format("Получен новый лид на сайте Двери-ДВ. Имя: {0}, телефон {1}",name,phone)
            };

            try
            {
                client.Send(message);
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return Json(new
                {
                    success = false,
                    msg = e.Message
                });
            }

            return Json(new
            {
                success = true
            });
        }

        /// <summary>
        /// Обрабатывает новый лид с формы обратной связи
        /// </summary>
        /// <param name="name">Имя пользователя</param>
        /// <param name="phone">телефон</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Callback(string name, string phone, string time)
        {
            // Получаем email куда отправлять
            var targetEmail = System.Configuration.ConfigurationManager.AppSettings["feedbackEmail"];

            // Подгатавливаем клиент и сообщение к отправке
            var client = new SmtpClient()
            {
                EnableSsl = true,
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential("tracker@trust-media.ru", "NetTracker"),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            var message = new MailMessage(new MailAddress("tracker@trust-media.ru","Сайт Двери-ДВ"), new MailAddress(targetEmail))
            {
                IsBodyHtml = true,
                Subject = "Получен новый лид на сайте Двери-ДВ",
                Body = String.Format("Получен новый лид - заказ звонка на сайте Двери-ДВ. Имя: {0}, телефон {1}, время для звонка: {2}.",name,phone,time)
            };

            try
            {
                client.Send(message);
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return Json(new
                {
                    success = false,
                    msg = e.Message
                });
            }

            return Json(new
            {
                success = true
            });
        }

        /// <summary>
        /// Отображает вход в админскую страницу
        /// </summary>
        /// <returns></returns>
        public ActionResult Admin()
        {
            return View();
        }

        /// <summary>
        /// Помечает пользователя как админка если он ввел правильный пароль
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Validate(string pass)
        {
            var validPass = ConfigurationManager.AppSettings["adminPassword"];
            if (pass == validPass)
            {
                Session["admin"] = "true";
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Admin");
            }
        }

        /// <summary>
        /// Схраняет изменение значения документа
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="newValue">Значение</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveContent(string key, string newValue)
        {
            if (Session["Admin"] != "true")
            {
                return Json(new
                    {
                        success = false
                    });
            }
            var octopus = new OctopusStorage();
            octopus.KeyValues[key] = newValue;
            octopus.SaveData();
            return Json(new
                {
                    success = true
                });
        }
    }
}
