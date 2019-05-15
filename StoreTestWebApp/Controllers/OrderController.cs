using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreTestWebApp.Models.Dao;
using StoreTestWebApp.Models;

namespace StoreTestWebApp.Controllers
{
    public class OrderController : Controller
    {
        private ClientDaoImpl cl = new ClientDaoImpl();
        private  ProductDaoImpl pr = new ProductDaoImpl();
        private OrderDaoImpl ord = new OrderDaoImpl();
        public ActionResult Index()
        {
            return View(ord.FindList(""));
        }

        public JsonResult FindProduct(string name)
        {
            return Json(pr.FindList(name));
        }
        public JsonResult FindClient(string name)
        {
            return Json(cl.FindList(name));
        }

        public ActionResult Registrar()
        {
            return View(new OrderViewModel());
        }

        [HttpPost]
        public ActionResult Registrar(OrderViewModel model, string action)
        {
            if (action == "generar")
            {
                if (!string.IsNullOrEmpty(model.ClientId.ToString()))
                {
                    if (ord.Create(model.ToModel()))
                    {
                        return Redirect("~/");
                    }
                }
                else
                {
                    ModelState.AddModelError("cliente", "Debe agregar un cliente");
                }
            }
            else if (action == "agregar_producto")
            {
                // Si no ha pasado nuestra validación, mostramos el mensaje personalizado de error
                if (!model.IsValidProduct())
                {
                    ModelState.AddModelError("producto_agregar", "Solo puede agregar un producto válido al detalle");
                }
                else if (model.ExistInDetail(model.ProductIdSel))
                {
                    ModelState.AddModelError("producto_agregar", "El producto elegido ya existe en el detalle");
                }
                else
                {
                    model.AddDetailItem();
                }
            }
            else if (action == "retirar_producto")
            {
                model.RemoveDetailItem();
            }
            else
            {
                throw new Exception("Acción no definida ..");
            }

            return View(model);
        }

        public ActionResult Detalle(int id)
        {
            return View(ord.FindObject(id.ToString()));
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