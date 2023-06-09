﻿/*
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

using DotNetNuke.Data;
using DotNetNuke.Framework;
using PBAmindSite.Dnn.PBAdminModul.Models;
using System.Collections.Generic;

namespace PBAmindSite.Dnn.PBAdminModul.Components
{
    internal interface IItemManager
    {
        void CreateItem(Item t);
        void DeleteItem(int id);
        void DeleteItem(Item t);
        IEnumerable<Item> GetItems();
        Item GetItem(int id);
        void UpdateItem(Item t);
    }

    internal class ItemManager : ServiceLocator<IItemManager, ItemManager>, IItemManager
    {
        public void CreateItem(Item t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Item>();
                rep.Insert(t);
            }
        }

        public void DeleteItem(int id)
        {
            var t = GetItem(id);
            DeleteItem(t);
        }

        public void DeleteItem(Item t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Item>();
                rep.Delete(t);
            }
        }

        public IEnumerable<Item> GetItems()
        {
            IEnumerable<Item> t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Item>();
                t = rep.Get();
            }
            return t;
        }

        public Item GetItem(int id)
        {
            Item t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Item>();
                t = rep.GetById(id);
            }
            return t;
        }

        public void UpdateItem(Item t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Item>();
                rep.Update(t);
            }
        }

        protected override System.Func<IItemManager> GetFactory()
        {
            return () => new ItemManager();
        }
    }
}
