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

using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Content;
using System;
using System.Web.Caching;

namespace PBAmindSite.Dnn.PBAdminModul.Models
{
    [TableName("Currency")]
    //setup the primary key for table
    [PrimaryKey("id", AutoIncrement = true)]
    //configure caching using PetaPoco
    [Cacheable("Items", CacheItemPriority.Default, 20)]
    //scope the objects to the ModuleId of a module on a page (or copy of a module on a page)
    [Scope("ModuleId")]
    public class Item
    {
        public int Id { get; set; }
        public string CurrencyName { get; set; }
        public string LongCurrencyName { get; set; }
        public double CurrencyValue { get; set; }
        public bool IsActive { get; set; }
    }
}
