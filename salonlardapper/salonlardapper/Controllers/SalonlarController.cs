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
    public class SalonlarController : Controller
    {
        // GET: Salonlar
        public ActionResult Index()
        {
            return View(DP.Listeleme<Salonlarclass>("SalonlarViewAll"));
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
                param.Add("@SalonNo", id);
                return View(DP.Listeleme<Salonlarclass>("SalonlarViewByNo", param).FirstOrDefault<Salonlarclass>());
            }
        }
        [HttpPost]
        public ActionResult Edit(Salonlarclass salon)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@SalonNo", salon.SalonNo);
            param.Add("@SalonAdi", salon.SalonAdi);
            param.Add("@SalonKapiNo", salon.SalonKapiNo);
            param.Add("@YapilanIslem", salon.YapilanIslem);
            param.Add("@IslemSayisi", salon.IslemSayisi);
            DP.ExecuteReturn("SalonlarEdit", param);
            return RedirectToAction("Index");

        }
        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("SalonNo", id);
            DP.ExecuteReturn("SalonlarDel", param);
            return RedirectToAction("Index");

        }

    }
}