using FoodMartMongo.Dtos.CategoryDtos;
using FoodMartMongo.Dtos.PeopleDtos;
using FoodMartMongo.Services.CategoryServices;
using FoodMartMongo.Services.PeopleServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodMartMongo.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        public async Task<IActionResult> PeopleList()
        {
            var values = await _peopleService.GetAllPeopleAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreatePeople()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePeople(CreatePeopleDto createPeopleDto)
        {
            await _peopleService.CreatePeopleAsync(createPeopleDto);
            return RedirectToAction("PeopleList");
        }

        public async Task<IActionResult> DeletePeople(string id)
        {
            await _peopleService.DeletePeopleAsync(id);
            return RedirectToAction("PeopleList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdatePeople(string id)
        {
            var value = await _peopleService.GetPeopleByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePeople(UpdatePeopleDto updatePeopleDto)
        {
            await _peopleService.UpdatePeopleAsync(updatePeopleDto);
            return RedirectToAction("PeopleList");
        }
    }
}
