using ShopManagement.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopManagement.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var db = new MyShopEntities();
            var product = db.Products.ToList();
            return View(product);
            
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Product book)
        {

            //add book to db
            var db = new MyShopEntities();
            db.Products.Add(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new MyShopEntities();
            var book = (from b in db.Products
                        where b.Id == id
                        select b).SingleOrDefault();
            return View(book);
        }
        [HttpPost]
        public ActionResult Edit(Product book)
        {
            var db = new MyShopEntities();
            //
            //db.Books.Find(book.Id);
            var ext = (from b in db.Products
                       where b.Id == book.Id
                       select b).SingleOrDefault();
            //ext.Author = book.Author;
            //ext.Name = book.Name;
            //ext.Price = book.Price;
            //ext.Edition = book.Edition;

            db.Entry(ext).CurrentValues.SetValues(book);

            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id) {
             var db = new MyShopEntities();
            var book = (from b in db.Products
                        where b.Id == id
                        select b).SingleOrDefault();
             db.Products.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}