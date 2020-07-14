using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentVacation.Common.Controllers;
using RentVacation.Dealers.Models.Dealers;
using RentVacation.Dealers.Services.Dealers;
using RentVacation.Common.Services.Identity;
using RentVacation.Common.Services;
using Microsoft.AspNetCore.Authorization;
using RentVacation.Dealers.Data.Models;
using System.Collections.Generic;
using RentVacation.Common.Infrastructure;

namespace RentVacation.Dealers.Controllers
{
    public class DealersController : ApiController
    {
        private readonly IDealerService dealers;
        private readonly ICurrentUserService currentUser;

        public DealersController(
            IDealerService dealers, 
            ICurrentUserService currentUser)
        {
            this.dealers = dealers;
            this.currentUser = currentUser;
        }

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<DealerDetailsOutputModel>> Details(int id) => await this.dealers.GetDetails(id);

        [HttpGet]
        [Authorize]
        [Route("Id")]
        public async Task<ActionResult<int>> GetId()
        {
            string currentUserId = this.currentUser.UserId;

            bool isDealer = await this.dealers.IsDealer(currentUserId);

            if (isDealer)
            {
                return await this.dealers.GetIdByUser(currentUserId);
            }
            else
            {
                return this.BadRequest("User is not a dealer!");
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create(CreateDealerInputModel input)
        {
            var dealer = new Dealer
            {
                Name = input.Name,
                PhoneNumber = input.PhoneNumber,
                UserId = this.currentUser.UserId
            };

            await this.dealers.Save(dealer);

            return Ok();
        }

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> Edit(int id, EditDealerInputModel input)
        {
            var dealer = this.currentUser.IsAdministrator ? await this.dealers.FindById(id) : await this.dealers.FindByUser(this.currentUser.UserId);

            if (id != dealer.Id)
            {
                return BadRequest(Result.Failure("You cannot edit this dealer."));
            }

            dealer.Name = input.Name;
            dealer.PhoneNumber = input.PhoneNumber;

            await this.dealers.Save(dealer);

            return Ok();
        }

        [HttpGet]
        [AuthorizeAdministrator]
        public async Task<IEnumerable<DealerDetailsOutputModel>> GetAllDealers() => await this.GetAllDealers();
    }
}
