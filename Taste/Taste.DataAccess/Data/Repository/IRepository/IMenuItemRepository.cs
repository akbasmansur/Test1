using Taste.Models;

namespace Taste.DataAccess.Data.Repository.IRepository {
    public interface IMenuItemRepository : IRepository<MenuItem> {
        void Update(MenuItem menuItem);
    }
}
