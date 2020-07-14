using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentVacation.Admin.Models.Dealers;
using RentVacation.Admin.Services.Dealers;
using System.Threading.Tasks;

namespace RentVacation.Admin.Controllers
{
    public class DealersController : AdministrationController
    {
        private readonly IDealersService dealers;
        private readonly IMapper mapper;

        public DealersController(IDealersService dealers, IMapper mapper)
        {
            this.dealers = dealers;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index() => View(await this.dealers.GetAllDealers());

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var dealer = await this.dealers.Details(id);

            var dealerForm = this.mapper.Map<DealerFormModel>(dealer);

            return View(dealerForm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, DealerFormModel model) 
            => await this.Handle(
                async () => await this.dealers
                    .Edit(id, this.mapper.Map<DealerInputModel>(model)),
                success: RedirectToAction(nameof(Index)),
                failure: View(model));
    }
}
