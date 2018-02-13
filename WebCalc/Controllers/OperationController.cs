using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCalc.Models;

namespace WebCalc.Controllers
{
    public class OperationController : Controller
    {
        public ActionResult Summary()
        {
            return View();
        }

        public ActionResult Division(double x, double y)
        {
            return View();
        }

        public ActionResult Multiplication(double x, double y)
        {
            return View();
        }

        public ActionResult Substraction(double x, double y)
        {
            return View();
        }
    }
}