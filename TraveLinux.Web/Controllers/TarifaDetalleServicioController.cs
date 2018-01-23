﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TraveLinux.Data.Entidades;
using TraveLinux.Web.Attributes;

namespace TraveLinux.Web.Controllers
{
    public class TarifaDetalleServicioController : BaseController
    {
        [Autorizar(Perfil.Administrador)]
        // GET: TarifaDetalleServicio
        public ActionResult Index(int Proveedor, string Tarifa)
        {
            ViewBag.Proveedor = Proveedor;
            ViewBag.Tarifa = Tarifa;
            return View();
        }

        public ActionResult Obtener_tarifa_Detalle_servicio(int Proveedor, string Tarifa)
        {
            var vCliente = Fachada.ObtenerTarifProvDetalle(Proveedor, Tarifa);
            return Json(vCliente);
        }
    }
}