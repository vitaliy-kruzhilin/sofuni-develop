using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RentVacation.Dealers.Data;
using RentVacation.Dealers.Data.Models;
using Microsoft.EntityFrameworkCore;
using RentVacation.Dealers.Models.Apartaments;

namespace RentVacation.Dealers.Services.Apartaments
{
    public class ApartamentService : DataService<Apartament>, IApartamentService
    {
        private const int ApartamentsPerPage = 10;

        private readonly IMapper mapper;

        public ApartamentService(DealersDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<Apartament> Find(int id)
            => await this
                .All()
                .FirstOrDefaultAsync(c => c.Id == id);

        public async Task<bool> Delete(int id)
        {
            var apartament = await this.Data.Apartaments.FindAsync(id);

            if (apartament == null)
            {
                return false;
            }

            this.Data.Apartaments.Remove(apartament);

            await this.Data.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ApartamentOutputModel>> GetListings(ApartamentsQuery query)
            => (await this.mapper
                .ProjectTo<ApartamentOutputModel>(this
                    .GetApartamentsQuery(query))
                .ToListAsync())
                .Skip((query.Page - 1) * ApartamentsPerPage)
                .Take(ApartamentsPerPage); // EF Core bug forces me to execute paging on the client.

        public async Task<IEnumerable<MineApartamentOutputModel>> Mine(int dealerId, ApartamentsQuery query)
            => (await this.mapper
                .ProjectTo<MineApartamentOutputModel>(this
                    .GetApartamentsQuery(query, dealerId))
                .ToListAsync())
                .Skip((query.Page - 1) * ApartamentsPerPage)
                .Take(ApartamentsPerPage); // EF Core bug forces me to execute paging on the client.

        public async Task<ApartamentDetailsOutputModel> GetDetails(int id)
            => await this.mapper
                .ProjectTo<ApartamentDetailsOutputModel>(this
                    .AllAvailable()
                    .Where(c => c.Id == id))
                .FirstOrDefaultAsync();

        public async Task<int> Total(ApartamentsQuery query)
            => await this
                .GetApartamentsQuery(query)
                .CountAsync();

        private IQueryable<Apartament> AllAvailable()
            => this
                .All()
                .Where(apartament => apartament.IsAvailable);

        private IQueryable<Apartament> GetApartamentsQuery(
            ApartamentsQuery query, int? dealerId = null)
        {
            var dataQuery = this.Data.Apartaments.AsQueryable();

            if (dealerId.HasValue)
            {
                dataQuery = dataQuery.Where(c => c.DealerId == dealerId);
            }

            if (query.Category.HasValue)
            {
                dataQuery = dataQuery.Where(c => c.CategoryId == query.Category);
            }

            return dataQuery;
        }
    }
}
