using salonlardapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace salonlardapper.Controllers
{
    public class HizmetController : Controller
    {
        // GET: Hizmet
        public ActionResult Index()
        {
            return View((DP.Listeleme<Hizmetclass>("HizmetViewAll")));
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
                param.Add("@HizmetNo", id);
                return View(DP.Listeleme<Hizmetclass>("HizmetViewByNo", param).FirstOrDefault<Hizmetclass>());
            }
        }

        public ActionResult Edit(Hizmetclass hizmet)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@HizmetNo", hizmet.HizmetNo);
            param.Add("@HizmetAdi", hizmet.HizmetAdi);
            param.Add("@HizmetAmaci", hizmet.HizmetAmaci);
            param.Add("@HizmetTutar", hizmet.HizmetTutar);
            param.Add("@OdemeTuru", hizmet.OdemeTuru);
            DP.ExecuteReturn("HizmetEdit", param);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("HizmetNo", id);
            DP.ExecuteReturn("HizmetDel", param);
            return RedirectToAction("Index");

        }

    }
}