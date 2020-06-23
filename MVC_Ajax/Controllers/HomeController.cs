using MVC_Ajax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC_Ajax.Controllers
{
    public class HomeController : Controller
    {
        private NorthwindEntities context = new NorthwindEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Localizar(string criterio)
        {
            IList<Product> produtos = new List<Product>();

            if (!String.IsNullOrEmpty(criterio))
            {
                using (var ctx = new NorthwindEntities())
                {
                    produtos = ctx.Products.Where(x => x.ProductName.Contains(criterio)).AsParallel().ToList();
                }
            }

            return PartialView("Produtos", produtos);
        }

        public PartialViewResult Brazil()
        {
            using (var ctx = new NorthwindEntities())
            {
                var resultado = from r in context.Customers
                                where r.Country == "Brazil"
                                select r;

                return PartialView("Pais", resultado);

            }
        }

        public PartialViewResult Argentina()
        {
            var resultado = from r in context.Customers
                            where r.Country == "Argentina"
                            select r;

            //resultado = context.Customers.Where(x => x.Country.Equals("Argentina"));

            return PartialView("Pais", resultado);
        }
    }
}