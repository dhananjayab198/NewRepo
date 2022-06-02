using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shopApplicationapi.Data;
using shopApplicationapi.Models;

namespace shopApplicationapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopItemController : Controller
    {
        //List<ShopItem> ShopItems= new List<ShopItem>
        //    {
        //        new ShopItem
        //        {
        //            ShopItemID = 1,
        //            ShopItemName = "Hi",
        //            ShopItemDescription = "hello",
        //            ShopItemModifiedBy = "Vijay",
        //            ShopItemModifiedDate = DateTime.Now,
        //            ShopItemPrice = 120
        //        }
        //    };

        private readonly DataContext _db;
        public ShopItemController(DataContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("GetAllItems")]
        public async Task<IActionResult> Get()
        {
            //return Ok(ShopItems);
            
            try
            { 
                Console.WriteLine("Found All Items!");
                return Ok(await _db.ShopItemDT.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet("id")]
        //public async Task<IActionResult> Get(int itemid)
        //{
        //    ShopItem shopItem = ShopItems.Find(i => i.ShopItemID == itemid);
        //    if (shopItem == null)
        //        return BadRequest("ShopItem Not found!");
        //    return Ok(shopItem);
        //}

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddShopItem(ShopItem item)
        {
            try
            {
                _db.ShopItemDT.Add(item);
                Console.WriteLine("Added SuccessFully!");
                _db.SaveChanges();
                return Ok(await _db.ShopItemDT.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateShopItem(ShopItem item)
        {
            try
            {
                if (item != null)
                {
                    ShopItem shopItem = await _db.ShopItemDT.FindAsync(item.ShopItemID);

                    if (shopItem == null)
                        return BadRequest("ShopItem Not found!");


                    shopItem.ShopItemID = item.ShopItemID;
                    shopItem.ShopItemName = item.ShopItemName;
                    shopItem.ShopItemDescription = item.ShopItemDescription;
                    shopItem.ShopItemPrice = item.ShopItemPrice;
                    shopItem.ShopItemModifiedBy = item.ShopItemModifiedBy;
                    shopItem.ShopItemModifiedDate = DateTime.Now;
                    shopItem.ShopItemStatus = "A";
                      
                    _db.SaveChanges();

                    Console.WriteLine("Updated SuccessFully!");
                    return Ok(_db.ShopItemDT);
                }
                else
                {
                    return BadRequest("Please Give Proper Item!");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            } 
            
        }

        [HttpGet]
        [Route("Delete/id")]
        public async Task<IActionResult> Delete(int itemid)
        {
            ShopItem shopItem = await _db.ShopItemDT.FindAsync(itemid);
            if (shopItem == null)
                return BadRequest("ShopItem Not found!");

            _db.ShopItemDT.Remove(shopItem);
            _db.SaveChanges();
            Console.WriteLine("Item Removed");
            return Ok(_db.ShopItemDT);
        }
    }
}
