using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            var context = new BookModelContext();
            return View(context.Book.ToList());
        }
        public ActionResult GetBookByCategory(int id) 
        {
            var context = new BookModelContext();
            return View("Index", context.Book.Where(p => p.CategoryId == id).ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            var context = new BookModelContext();
            ViewBag.ListCategory = context.Category.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book newBook) 
        {
            var context = new BookModelContext();
            if (ModelState.IsValid)
            {
                context.Book.Add(newBook);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Create");
            }
        }
        public ActionResult Details(int id) 
        {
            var context = new BookModelContext();
            var firstBook = context.Book.FirstOrDefault(p => p.Id == id);
            if (firstBook == null) 
            {
                return HttpNotFound("khong tim thay ma sach nay!");
            }
            return View(firstBook);
        }
        [HttpPost]
        public ActionResult Delete(Book deleteBook) 
        {
            var context = new BookModelContext();
            var firstBook = context.Book.FirstOrDefault(p => p.Id == deleteBook.Id);
            if (firstBook == null) 
                return HttpNotFound("Khong tim thay ma sach nay!");
            else
            {
                context.Book.Remove(firstBook);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult GetCategory()
        {
            var context = new BookModelContext();
            var ListCategory = context.Category.ToList();
            return PartialView(ListCategory);
        }
    }
}