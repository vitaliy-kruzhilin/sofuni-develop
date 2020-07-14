using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using RentVacation.Dealers.Data;
using RentVacation.Dealers.Data.Models;
using Microsoft.EntityFrameworkCore;
using RentVacation.Dealers.Models.Categories;

namespace RentVacation.Dealers.Services.Categories
{
    public class CategoryService : DataService<Category>, ICategoryService
    {
        private readonly IMapper mapper;

        public CategoryService(DealersDbContext db, IMapper mapper) 
            : base(db) 
            => this.mapper = mapper;

        public async Task<Category> Find(int categoryId)
            => await this.Data.Categories.FindAsync(categoryId);

        public async Task<IEnumerable<CategoryOutputModel>> GetAll()
            => await this.mapper
                .ProjectTo<CategoryOutputModel>(this
                    .Data.Categories)
                .ToListAsync();
    }
}
