using FoodMartMongo.Services.PeopleServices;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartMongo.ViewComponents
{
    public class _PeopleComponentPartial : ViewComponent
    {
        private readonly IPeopleService _peopleService;

        public _PeopleComponentPartial(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _peopleService.GetAllPeopleAsync();
            return View(values);
        }
    }
}
