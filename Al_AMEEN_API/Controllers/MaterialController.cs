using Al_AMEEN_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Al_AMEEN_API.Controllers
{
    public class MaterialController : ApiController
    {
        public Material Get(string barcode)
        {
            using (AmnDb001Entities2 db = new AmnDb001Entities2())
            {
                var material = new Material();
                var result =  db.mt000.SingleOrDefault(m => m.BarCode == barcode);
                
                if (result != null){ material.SearchedKind = 1;}

                if (result == null)
                {
                    result = db.mt000.SingleOrDefault(m => m.BarCode2 == barcode);
                    if (result != null) { material.SearchedKind = 2; }
                }

                if (result == null)
                {
                    result = db.mt000.SingleOrDefault(m => m.BarCode3 == barcode);
                    if (result != null) { material.SearchedKind = 3; }
                }

                if (result == null)
                {
                    var result2 = db.MatExBarcode000.SingleOrDefault(m => m.Barcode == barcode);
                    result = db.mt000.SingleOrDefault(b => b.GUID ==result2.MatGuid);
                    if (result != null) { material.SearchedKind = result2.MatUnit.Value; }
                }


                if (result != null)
                {
                    // Name
                    material.Name = result.Name;

                    // Group Name
                    var groupGuid = db.gr000.SingleOrDefault(g=>g.GUID == result.GroupGUID);
                    material.Group_Name = groupGuid.Name;


                    // Currency
                    var currency = db.my000.SingleOrDefault(c => c.GUID == result.CurrencyGUID);
                    material.Currency = currency.Name;

                    //The Name Of Unit ex => حبة،شدة،كرتون
                    material.Unity = result.Unity;
                    material.Unit2 = result.Unit2;
                    material.Unit3 = result.Unit3;

                    //The Price Of Each Unit
                    material.Price1 = result.EndUser.Value;
                    material.Price2 = result.EndUser2.Value;
                    material.Price3 = result.EndUser3.Value;

                    //Quantity of each unit
                    material.Unit2Fact = result.Unit2Fact.Value;
                    material.Unit3Fact = result.Unit3Fact.Value;


                    //For The Picture
                    
                    var pictureGuid = db.bm000.SingleOrDefault(p => p.GUID == result.PictureGUID);
                    // For if there's a picture or not
                    if (pictureGuid != null)
                    {
                        material.Picture = pictureGuid.Name.ToString();
                    }
                    else
                    {
                        material.Picture = null;
                    }
                  
                    

                    
                }

                return material;

            }
        }
    }
}
