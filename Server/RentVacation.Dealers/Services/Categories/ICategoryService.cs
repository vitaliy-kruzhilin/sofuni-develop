using System.Collections.Generic;
using System.Threading.Tasks;
using RentVacation.Dealers.Data.Models;
using RentVacation.Dealers.Models.Categories;

namespace RentVacation.Dealers.Services.Categories
{
    public interface ICategoryService
    {
        Task<Category> Find(int categoryId);

        Task<IEnumerable<CategoryOutputModel>> GetAll();
    }
}
