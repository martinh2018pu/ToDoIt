using System.Web.Mvc;
using ToDoIt.DataAccess;
using ToDoIt.Models;

namespace ToDoIt.Controllers
{
    public class NotesController : Controller
    {
        private readonly NotesRepository notesRepository;

        public NotesController()
        {
            notesRepository = new NotesRepository();
        }

        // GET: Notes
        public ActionResult Index()
        {
            var notes = notesRepository.GetAll();
            return View(notes);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Note model)
        {
            TryUpdateModel(model);

            if (ModelState.IsValid)
            {
                notesRepository.Save(model);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = notesRepository.Get(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Note model)
        {
            TryUpdateModel(model);

            if (ModelState.IsValid)
            {
                notesRepository.Save(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            notesRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
