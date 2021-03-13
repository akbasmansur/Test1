using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Taste.Models;

namespace Taste.DataAccess.Data.Repository.IRepository {
    public interface IFoodTypeRepository : IRepository<FoodType> {
        IEnumerable<SelectListItem> GetCategoryListForDropDown();
        void Update(FoodType category);
    }
}
