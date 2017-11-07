using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestauranteApp.Models;
using X.PagedList;

namespace RestauranteApp.Controllers
{
    public class PratosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pratos
        public async Task<ActionResult> Index(int? page)
        {
            var pratos = db.Pratos.Include(x=>x.Restaurante).AsEnumerable().OrderBy(x => x.Nome);


            if (Request.Form["Nome"] != null)
            {
                pratos = pratos.Where(x => x.Nome.Contains(Request.Form["Nome"].ToString())).OrderBy(x => x.Nome);
            }

            var paginaNumero = page ?? 1;
            var paginaDePratos = await pratos.ToPagedListAsync(paginaNumero, 5);

            ViewBag.PaginaDePratos = paginaDePratos;

            return View();
        }

        // GET: Pratos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prato prato = await db.Pratos.FindAsync(id);
            if (prato == null)
            {
                return HttpNotFound();
            }
            return View(prato);
        }

        // GET: Pratos/Create
        public ActionResult Create()
        {
            ViewBag.RestauranteId = new SelectList(db.Restaurantes, "RestauranteId", "Nome");
            return View();
        }

        // POST: Pratos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PratoId,RestauranteId,Nome,Preco")] Prato prato)
        {
            if (ModelState.IsValid)
            {
                db.Pratos.Add(prato);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RestauranteId = new SelectList(db.Restaurantes, "RestauranteId", "Nome", prato.RestauranteId);
            return View(prato);
        }

        // GET: Pratos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prato prato = await db.Pratos.FindAsync(id);
            if (prato == null)
            {
                return HttpNotFound();
            }
            ViewBag.RestauranteId = new SelectList(db.Restaurantes, "RestauranteId", "Nome", prato.RestauranteId);
            return View(prato);
        }

        // POST: Pratos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PratoId,RestauranteId,Nome,Preco")] Prato prato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prato).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RestauranteId = new SelectList(db.Restaurantes, "RestauranteId", "Nome", prato.RestauranteId);
            return View(prato);
        }

        // GET: Pratos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prato prato = await db.Pratos.FindAsync(id);
            if (prato == null)
            {
                return HttpNotFound();
            }
            return View(prato);
        }

        // POST: Pratos/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Prato prato = await db.Pratos.FindAsync(id);
            db.Pratos.Remove(prato);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
