using RocketQ.Data.Models;
using RocketQ.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RocketQ.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly InMemoryRoomData dbr;
        private readonly InMemoryQuestionData dbq;
        public HomeController()
        {
            dbr = new InMemoryRoomData();
            dbq = new InMemoryQuestionData();
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Room(Room room)
        {
            int roomid = room.Id;
            var model = dbq.GetAll(roomid);
            if (model != null)
                return View(model);
            return RedirectToAction("Error!");
        }
        /*public IActionResult Room(int questionId, string action, string password)
        {
            var question = dbq.Get(questionId);
            var confirm = dbr.ConfirmRoom(dbr.Get(question.RoomId), password);
            if (confirm == 1 && action == "delete")
                dbq.Delete(questionId);
            if (confirm == 1 && action == "readed")
                dbq.Update(questionId);
            return RedirectToAction("Index, ", question.RoomId);
        }*/
        public ActionResult CreatePass()
        {
            return View();
        }
        public void Delete(int id, string password)
        {
            var model = dbq.Get(id);
            var confirm = dbr.ConfirmRoom(dbr.Get(model.RoomId), password);
            if (confirm == 1)
                dbq.Delete(model.Id);
            else
                TempData["Message"] = "You have saved the restaurant!";
        }
        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}