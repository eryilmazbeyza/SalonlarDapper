using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using System.Data.SqlClient;
using static Dapper.SqlMapper;
using salonlardapper.Models;

namespace salonlardapper.Controllers
{
    public class GorevliController : Controller
    {
        // GET: Gorevli
        public ActionResult Index()
        {
            return View(DP.Listeleme<Gorevliclass>("GorevliViewAll"));
        }
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return View();

            }
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@GorevliNo", id);
                return View(DP.Listeleme<Gorevliclass>("GorevliViewByNo", param).FirstOrDefault<Gorevliclass>());
            }
        }
        [HttpPost]
        public ActionResult Edit(Gorevliclass gorevli)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@GorevliNo", gorevli.GorevliNo);
            param.Add("@AdSoyad", gorevli.AdSoyad);
            param.Add("@Yas", gorevli.Yas);
            param.Add("@Telefon", gorevli.Telefon);
            param.Add("@MesaiDurumu", gorevli.MesaiDurumu);
            param.Add("@Maas", gorevli.Maas);
            param.Add("@Prim", gorevli.Prim);
            DP.ExecuteReturn("GorevliEdit", param);
            return RedirectToAction("Index");

        }
        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("GorevliNo", id);
            DP.ExecuteReturn("GorevliDel", param);
            return RedirectToAction("Index");

        }
    }
}