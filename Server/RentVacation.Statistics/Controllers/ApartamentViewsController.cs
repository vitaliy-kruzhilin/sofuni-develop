using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentVacation.Common.Controllers;
using RentVacation.Common.Services.Identity;
using RentVacation.Statistics.Models.ApartamentsViews;
using RentVacation.Statistics.Services.ApartamentViews;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentVacation.Statistics.Controllers
{
    public class ApartamentViewsController : ApiController
    {
        private readonly IApartamentViewService apartamentViews;

        public ApartamentViewsController(IApartamentViewService apartamentViews) => this.apartamentViews = apartamentViews;

        [HttpGet]
        [Route(Id)]
        public async Task<int> TotalViews(int id)
            => await this.apartamentViews.GetTotalViews(id);

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<ApartamentViewOutputModel>> TotalViews(
            [FromQuery] IEnumerable<int> ids)
            => await this.apartamentViews.GetTotalViews(ids);
    }
}
