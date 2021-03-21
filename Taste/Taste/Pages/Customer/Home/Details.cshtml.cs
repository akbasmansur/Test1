using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Security.Claims;
using Taste.DataAccess.Data.Repository.IRepository;
using Taste.Models;
using Taste.Utility;

namespace Taste.Pages.Customer.Home {
    [Authorize]
    public class DetailsModel : PageModel {
        private readonly IUnitOfWork _unitOfWork;
        public DetailsModel(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public ShoppingCart ShoppingCartObj { get; set; }
        public void OnGet(int id) {
            ShoppingCartObj = new ShoppingCart {
                MenuItem = _unitOfWork.MenuItem.GetFirstOrDefault(c => c.Id == id,"Category,FoodType"),
                MenuItemId = id
            };
        }
        public IActionResult OnPost() {

            if(ModelState.IsValid) {
                
                var claimsIdentity = (ClaimsIdentity)this.User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

                ShoppingCartObj.ApplicationUserId = claim.Value;
                ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.GetFirstOrDefault(c => c.ApplicationUserId ==ShoppingCartObj.ApplicationUserId && 
                                            c.MenuItemId == ShoppingCartObj.MenuItemId);
                if(cartFromDb == null) {
                    _unitOfWork.ShoppingCart.Add(ShoppingCartObj);
                }
                else {
                    _unitOfWork.ShoppingCart.IncrementCount(cartFromDb, ShoppingCartObj.Count);
                }
                _unitOfWork.Save();
                var count = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == ShoppingCartObj.ApplicationUserId).ToList().Count;
                HttpContext.Session.SetInt32(SD.ShoppingCart, count);
                return RedirectToPage("Index");
            }
            else {
                //Eger satir 48 eklenmeseydi count degerini 0 girdigimizde hata aliyorduk. Details.cshtml sayfasina section Scriptsi ekleyince bunada gerek kalmadi.
                //Client side dogrulama yapmis olduk.
                ShoppingCartObj.MenuItem = _unitOfWork.MenuItem.GetFirstOrDefault(c => c.Id == ShoppingCartObj.MenuItemId, "Category,FoodType");
                return Page();
            }
        }
    }
}
