using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Notebook.Models;
using Notebook.ViewModels;

namespace Notebook.Controllers
{
    public class NotesController : Controller
    {
        // GET: Notes
        public ActionResult Index()
        {
            using (var db = new NotebookContext())
            {
                List<Note> allNotes = db.Notes.OrderByDescending(x => x.NoteID).ToList();
                return View(allNotes);
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new NotebookContext())
            {
                Note note = db.Notes.Find(id);
                return View(note);
            }
        }

        public ActionResult Edit(int id)
        {
            using (var db = new NotebookContext())
            {
                Note note = db.Notes.Find(id);
                NoteCreationViewModel editNote = new NoteCreationViewModel
                {
                    NoteTitle = note.NoteTitle,
                    NoteContent = note.NoteContent
                };
                return View(editNote);
            }
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPost(int id, NoteCreationViewModel note)
        {
            if (ModelState.IsValid)
            {
                using (var db = new NotebookContext())
                {
                    Note editNote = db.Notes.Find(id);

                    editNote.NoteTitle = note.NoteTitle;
                    editNote.NoteContent = note.NoteContent;
                    editNote.EditedAt = DateTime.Now;

                    db.SaveChanges();

                    return View("EditPost");
                }
            }
            else
            {
                return View("Edit", note);
            }
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreatePost(NoteCreationViewModel note)
        {
            if (ModelState.IsValid)
            {
                using (var db = new NotebookContext())
                {
                    Note newNote = new Note
                    {
                        NoteTitle = note.NoteTitle,
                        NoteContent = note.NoteContent,
                        CreatedAt = DateTime.Now,
                        EditedAt = DateTime.Now
                    };
                    db.Notes.Add(newNote);
                    db.SaveChanges();
                    return View("CreatePost");
                }
            } else
            {
                return View("Create", note);
            }
        }

        public ActionResult Delete(int id)
        {
            using (var db = new NotebookContext())
            {
                Note note = db.Notes.Find(id);
                return View(note);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            using (var db = new NotebookContext())
            {
                Note deleteNote = db.Notes.Find(id);

                db.Notes.Remove(deleteNote);

                db.SaveChanges();

                return View("DeletePost");
            }
        }
    }
}