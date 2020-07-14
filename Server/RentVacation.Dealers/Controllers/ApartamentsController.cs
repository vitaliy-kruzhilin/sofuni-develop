using System.Collections.Generic;
using System.Threading.Tasks;
using RentVacation.Dealers.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentVacation.Dealers.Models.Apartaments;
using RentVacation.Dealers.Models.Categories;
using RentVacation.Dealers.Services.Apartaments;
using RentVacation.Dealers.Services.Categories;
using RentVacation.Dealers.Services.Dealers;
using RentVacation.Common.Controllers;
using RentVacation.Common.Services.Identity;
using RentVacation.Common.Services;
using MassTransit;
using RentVacation.Common.Messages.Dealers;

namespace RentVacation.Dealers.Controllers
{
    public class ApartamentsController : ApiController
    {
        private readonly IApartamentService apartaments;
        private readonly IDealerService dealers;
        private readonly ICategoryService categories;
        private readonly ICurrentUserService currentUser;
        private readonly IBus massTransitBus;

        public ApartamentsController(
            IApartamentService apartaments, 
            IDealerService dealers,
            ICategoryService categories,
            ICurrentUserService currentUser,
            IBus bus)
        {
            this.apartaments = apartaments;
            this.dealers = dealers;
            this.categories = categories;
            this.currentUser = currentUser;
            this.massTransitBus = bus;
        }

        [HttpGet]
        public async Task<ActionResult<SearchApartamentsOutputModel>> Search([FromQuery] ApartamentsQuery query)
        {
            var apartamentListings = await this.apartaments.GetListings(query);

            var totalPages = await this.apartaments.Total(query);

            return new SearchApartamentsOutputModel(apartamentListings, query.Page, totalPages);
        }

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<ApartamentDetailsOutputModel>> Details(int id)
            => await this.apartaments.GetDetails(id);

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateApartamentOutputModel>> Create(ApartamentInputModel input)
        {
            var dealer = await this.dealers.FindByUser(this.currentUser.UserId);

            var category = await this.categories.Find(input.Category);

            if (category == null)
            {
                return BadRequest(Result.Failure("Category does not exist."));
            }

            var apartament = new Apartament
            {
                Dealer = dealer,
                Information = input.Information,
                Category = category,
                ImageUrl = input.ImageUrl,
                PricePerDay = input.PricePerDay,
                Options = new Options
                {
                    HasClimateControl = input.HasClimateControl,
                    NumberOfBeds = input.NumberOfBeds,
                    Floor = input.Floor
                }
            };

            await this.apartaments.Save(apartament);

            await this.massTransitBus.Publish(new ApartamentCreatedMessage()
            {
                ApartamentId = apartament.Id,
                Information = apartament.Information
            });;

            return new CreateApartamentOutputModel(apartament.Id);
        }

        [HttpPut]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult> Edit(int id, ApartamentInputModel input)
        {
            var dealerId = await this.dealers.GetIdByUser(this.currentUser.UserId);

            var dealerHasApartament = await this.dealers.HasApartament(dealerId, id);

            if (!dealerHasApartament)
            {
                return BadRequest(Result.Failure("You cannot edit this apartament."));
            }

            var category = await this.categories.Find(input.Category);

            var apartament = await this.apartaments.Find(id);

            apartament.Information = input.Information;
            apartament.Category = category;
            apartament.ImageUrl = input.ImageUrl;
            apartament.PricePerDay = input.PricePerDay;
            apartament.Options = new Options
            {
                HasClimateControl = input.HasClimateControl,
                NumberOfBeds = input.NumberOfBeds,
                Floor = input.Floor
            };

            await this.apartaments.Save(apartament);

            await this.massTransitBus.Publish(new ApartamentUpdatedMessage()
            {
                ApartamentId = apartament.Id,
                Information = apartament.Information
            });

            return Result.Success;
        }

        [HttpDelete]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var dealerId = await this.dealers.GetIdByUser(this.currentUser.UserId);

            var dealerHasCar = await this.dealers.HasApartament(dealerId, id);

            if (!dealerHasCar)
            {
                return BadRequest(Result.Failure("You cannot edit this apartament."));
            }

            return await this.apartaments.Delete(id);
        }

        [HttpGet]
        [Authorize]
        [Route(nameof(Mine))]
        public async Task<ActionResult<MineApartamentsOutputModel>> Mine([FromQuery] ApartamentsQuery query)
        {
            var dealerId = await this.dealers.GetIdByUser(this.currentUser.UserId);

            var apartamentListings = await this.apartaments.Mine(dealerId, query);

            var totalPages = await this.apartaments.Total(query);

            return new MineApartamentsOutputModel(apartamentListings, query.Page, totalPages);
        }

        [HttpGet]
        [Route(nameof(Categories))]
        public async Task<IEnumerable<CategoryOutputModel>> Categories() => await this.categories.GetAll();

        [HttpPut]
        [Authorize]
        [Route(Id + PathSeparator + nameof(ChangeAvailability))]
        public async Task<ActionResult> ChangeAvailability(int id)
        {
            var dealerId = await this.dealers.GetIdByUser(this.currentUser.UserId);

            var dealerHasApartament = await this.dealers.HasApartament(dealerId, id);

            if (!dealerHasApartament)
            {
                return BadRequest(Result.Failure("You cannot edit this apartament."));
            }

            var apartament = await this.apartaments.Find(id);

            apartament.IsAvailable = !apartament.IsAvailable;

            await this.apartaments.Save(apartament);

            return Result.Success;
        }
    }
}
