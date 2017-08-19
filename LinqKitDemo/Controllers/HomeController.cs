using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinqKitDemo.Models;
using LinqKit;

namespace LinqKitDemo.Controllers
{

    public class HomeController : Controller
    {            
        public ActionResult Index(int? id)
        {
            MyTestEntities db = new MyTestEntities();
            var pred = PredicateBuilder.New<LinqTest>();
            pred.And(o => o.Flag == "Y"); //fixed

            if (id.HasValue == true)      //dynamic
            {
                pred.And(o => o.id == id);
            }
            IQueryable<LinqTest> query = (from d in db.LinqTest
                                          where 1 == 1
                                          select d).Where(pred);
            return View(query.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}