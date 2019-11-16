using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoIt.DataAccess;
using ToDoIt.Models;

namespace ToDoIt.Controllers
{
    public class CommentsController : Controller
    {
        private readonly CommentsRepository commentsRepository;

        public CommentsController()
        {
            commentsRepository = new CommentsRepository();
        }

        // GET: Comments
        public ActionResult Index(int noteId)
        {
            var comments = commentsRepository.GetAll().Where(c => c.NoteId == noteId).ToList();

            ViewBag.NoteId = noteId;

            return View(comments);
        }

        public ActionResult Create(int noteId)
        {
            var newComment = new Comment();
            newComment.NoteId = noteId;

            return View(newComment);
        }

        [HttpPost]
        public ActionResult Create(Comment model)
        {
            TryUpdateModel(model);

            if (ModelState.IsValid)
            {
                model.Id = 0;
                var now = DateTime.Now;
                model.CreatedDate = now;
                model.LastEditedDate = now;

                commentsRepository.Save(model);

                return RedirectToAction("Index", new { noteId = model.NoteId });
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            Comment modelToEdit = commentsRepository.Get(id);

            return View(modelToEdit);
        }

        [HttpPost]
        public ActionResult Edit(Comment model)
        {
            TryUpdateModel(model);

            if (ModelState.IsValid)
            {
                model.LastEditedDate = DateTime.Now;

                commentsRepository.Save(model);

                return RedirectToAction("Index", new { noteId = model.NoteId });
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            Comment model = commentsRepository.Get(id);

            commentsRepository.Delete(id);

            return RedirectToAction("Index", new { noteId = model.NoteId });
        }
    }
}