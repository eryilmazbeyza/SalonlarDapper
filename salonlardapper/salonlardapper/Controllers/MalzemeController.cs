using Dapper;
using salonlardapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace salonlardapper.Controllers
{
    public class MalzemeController : Controller
    {
        // GET: Malzeme
        public ActionResult Index()
        {
            return View((DP.Listeleme<Malzemeclass>("MalzemeViewAll")));
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
                param.Add("@MalzemeNo", id);
                return View(DP.Listeleme<Malzemeclass>("MalzemeViewByNo", param).FirstOrDefault<Malzemeclass>());
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
    }
}