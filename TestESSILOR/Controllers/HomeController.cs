using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestESSILOR.Models;

namespace TestESSILOR.Controllers
{
    public class HomeController : Controller
    { 
        AllMD md = new AllMD();

        [Route("FizzBuzz")]
        public ActionResult Index()
        {

            List<ReturnDT> rdt = new List<ReturnDT>();
            for (int cc = 1; cc <= 100; cc++)
            {
                ReturnDT mn = new ReturnDT();
                if (cc % 5 == 0 && cc % 3 == 0)
                {
                    mn.TAG = cc.ToString();
                    mn.MSG = "FiZZBuzz"; rdt.Add(mn);
                }
                else if (cc%5 == 0 && cc % 3 != 0)
                {
                    mn.TAG = cc.ToString();
                    mn.MSG = "Buzz"; rdt.Add(mn);
                }
                else if(cc % 3 == 0)
                {
                    mn.TAG = cc.ToString();
                    mn.MSG = "FiZZ"; rdt.Add(mn);
                }
               
            }

            ViewData["RDT"] = rdt;
            return View();
        }
     
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Route("WebRespense")]
        public ActionResult WebRes()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}