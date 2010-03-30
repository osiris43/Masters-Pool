using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MastersPool.Services.Interfaces;

namespace MastersPool.Controllers
{
    public class GolferController : Controller
    {
        public GolferController(IGolferService gs)
        {
            this.golferService = gs;
        }
        //
        // GET: /Golfer/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Golfer/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Golfer/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Golfer/Create

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

        //
        // GET: /Golfer/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Golfer/Edit/5

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

        private IGolferService golferService = null;
    }
}
