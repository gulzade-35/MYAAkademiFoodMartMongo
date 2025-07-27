using FoodMartMongo.Dtos.PeopleDtos;

namespace FoodMartMongo.Services.PeopleServices
{
    public interface IPeopleService
    {
        Task<List<ResultPeopleDto>> GetAllPeopleAsync();
        Task CreatePeopleAsync(CreatePeopleDto createPeopleDto);
        Task UpdatePeopleAsync(UpdatePeopleDto updatePeopleDto);
        Task DeletePeopleAsync(string id);
        Task<GetPeopleByIdDto> GetPeopleByIdAsync(string id);
    }
}
