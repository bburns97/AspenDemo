using System.Collections.Generic;
using System.Web.Mvc;
using Aspen.Domain;
using Aspen.Domain.PotionManager;
using Newtonsoft.Json;

namespace TestDemo.Controllers.API
{
    public class PotionsController : Controller
    {
        // GET: Potions
        public ActionResult Index(int? id)
        {
            if (id < 0 || id == null)
                return View(new Potions
            {
                Name = "No Recipie found",
                Description = "No Recipie found with the id of " + id,
                navColor = new Color { Description = string.Empty },
                navEffect = new Effect { Description = string.Empty }
            });
            PotionManager pManager = new PotionManager();
            var potion = pManager.GetPotion(n => n.PotionID == id) ?? new Potions
            {
                Name = "No Recipie found",
                Description = "No Recipie found with the id of " + id,
                navColor = new Color { Description = string.Empty },
                navEffect = new Effect { Description = string.Empty }
            };
            List<Potions> plist = new List<Potions>();
            plist.Add(potion);


            return View(potion);
        }

        public ActionResult Next(int? id)
        {
            if (id < 0 || id == null)
                return Json(new Potions
                {
                    Name = "No Recipie found",
                    Description = "No Recipie found with the id of " + id,
                    navColor = new Color { Description = string.Empty },
                    navEffect = new Effect { Description = string.Empty }
                });
            PotionManager pManager = new PotionManager();
            var potion = pManager.GetPotion(n => n.PotionID == id) ?? new Potions
            {
                Name = "No Recipie found",
                Description = "No Recipie found with the id of " + id,
                navColor = new Color { Description = string.Empty },
                navEffect = new Effect { Description = string.Empty }
            };
            List<Potions> plist = new List<Potions>();
            plist.Add(potion);

            string json = JsonConvert.SerializeObject(potion, Formatting.Indented);
 
            return Json(json);
        }

        // GET: Potions/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Potions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Potions/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Potions/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Potions/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Potions/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Potions/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
