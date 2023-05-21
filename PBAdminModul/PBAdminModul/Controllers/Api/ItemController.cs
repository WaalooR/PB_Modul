using DotNetNuke.Data;
using DotNetNuke.Services.Installer.Log;
using PBAmindSite.Dnn.PBAdminModul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PBAmindSite.Dnn.PBAdminModul.Controllers.Api
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void Update(Item item)
        {
            try
            {
                var newItem = new Item();
                using (var ctx = DataContext.Instance())
                {
                    var r = ctx.GetRepository<Item>();
                    var oldItem = r.GetById(item.Id);
                    newItem.CurrencyName = oldItem.CurrencyName;
                    newItem.LongCurrencyName = oldItem?.LongCurrencyName;
                    newItem.CurrencyValue = oldItem.CurrencyValue;
                    newItem.Id = item.Id;
                    newItem.IsActive = !item.IsActive;


                    r.Update(newItem);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}