using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using RentVacation.Dealers.Data;
using RentVacation.Dealers.Data.Models;
using Microsoft.EntityFrameworkCore;
using RentVacation.Dealers.Models.Dealers;
using System.Collections.Generic;
using RentVacation.Common.Services.Data;

namespace RentVacation.Dealers.Services.Dealers
{
    public class DealerService : DataService<Dealer>, IDealerService
    {
        private readonly IMapper mapper;

        public DealerService(DealersDbContext db, IMapper mapper) : base(db)
            => this.mapper = mapper;

        public async Task<bool> HasApartament(int dealerId, int apartamentId)
            => await this
                .All()
                .Where(d => d.Id == dealerId)
                .AnyAsync(d => d.Apartaments.Any(c => c.Id == apartamentId));

        public async Task<bool> IsDealer(string userId)
            => await this.All().AnyAsync(w => w.UserId == userId);

        public async Task<DealerDetailsOutputModel> GetDetails(int id)
            => await this.mapper
                .ProjectTo<DealerDetailsOutputModel>(this
                    .All()
                    .Where(d => d.Id == id))
                .FirstOrDefaultAsync();

        public async Task<DealerOutputModel> GetDetailsByApartamentId(int apartamentId)
            => await this.mapper
                .ProjectTo<DealerOutputModel>(this
                    .All()
                    .Where(d => d.Apartaments.Any(c => c.Id == apartamentId)))
                .SingleOrDefaultAsync();

        public Task<int> GetIdByUser(string userId) => this.FindByUser(userId, dealer => dealer.Id);

        public async Task<Dealer> FindById(int Id) => await this.Data.FindAsync<Dealer>(Id);

        public Task<Dealer> FindByUser(string userId) => this.FindByUser(userId, dealer => dealer);

        private async Task<T> FindByUser<T>(
            string userId,
            Expression<Func<Dealer, T>> selector)
        {
            var dealerData = await this
                .All()
                .Where(u => u.UserId == userId)
                .Select(selector)
                .FirstOrDefaultAsync();

            if (dealerData == null)
            {
                throw new InvalidOperationException("This user is not a dealer.");
            }

            return dealerData;
        }

        public async Task<IEnumerable<DealerDetailsOutputModel>> GetAllDealers()
            => await this.mapper.ProjectTo<DealerDetailsOutputModel>(this.All()).ToListAsync();
    }
}
