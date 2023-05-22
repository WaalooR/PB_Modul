/*
' Copyright (c) 2023 Piros Biros
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using DotNetNuke.Entities.Users;
using DotNetNuke.Framework.JavaScriptLibraries;
using DotNetNuke.Services.Installer.Log;
using DotNetNuke.Services.Social.Messaging.Internal.Views;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using PBAmindSite.Dnn.PBAdminModul.Components;
using PBAmindSite.Dnn.PBAdminModul.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;

namespace PBAmindSite.Dnn.PBAdminModul.Controllers
{
    [DnnHandleError]
    [ModuleAction(ControlKey = "Edit", TitleKey = "AddItem")]
    public class ItemController : DnnController
    {
        [HttpPost]
        public void Edit(Item item)
        {
            var existingItem = ItemManager.Instance.GetItem(item.Id);
            existingItem.CurrencyValue = item.CurrencyValue;
            existingItem.CurrencyName = item.CurrencyName;
            existingItem.LongCurrencyName = item.LongCurrencyName;
            existingItem.IsActive = item.IsActive;

            ItemManager.Instance.UpdateItem(existingItem);
        }

        public ActionResult Index()
        {
            var items = ItemManager.Instance.GetItems();
            return View(items);
        }
    }
}
