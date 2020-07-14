using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentVacation.Common.Controllers;
using RentVacation.Dealers.Gateway.Models.Apartaments;
using RentVacation.Dealers.Gateway.Services.Apartaments;
using RentVacation.Dealers.Gateway.Services.ApartamentViews;

namespace RentVacation.Dealers.Gateway.Controllers
{
    public class ApartamentsController : ApiController
    {
        private readonly IApartamentService apartamentService;
        private readonly IApartamentViewService apartamentViewService;
        private readonly IMapper mapper;

        public ApartamentsController(IApartamentService apartamentService, IApartamentViewService apartamentViewService, IMapper mapper)
        {
            this.apartamentService = apartamentService;
            this.apartamentViewService = apartamentViewService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<MineApartamentOutputModel>> Mine()
        {
            var apartaments = await this.apartamentService.Mine();


            var mineApartamentIds = apartaments.Apartaments.Select(s => s.Id);

            var mineApartamentViews = await apartamentViewService.TotalViews(mineApartamentIds);

            var mineApartaments = this.mapper.Map<IEnumerable<ApartamentOutputModel>, IEnumerable<MineApartamentOutputModel>>(apartaments.Apartaments).ToDictionary(d => d.Id);

            var mineApartamentViewsD = mineApartamentViews.ToDictionary(d => d.ApartamentId, d => d.TotalViews);

            foreach (var (apartamentId, totalView) in mineApartamentViewsD)
            {
                mineApartaments[apartamentId].TotalViews = totalView;
            }

            return mineApartaments.Values;
        }
    }
}
