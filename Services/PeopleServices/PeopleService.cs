using AutoMapper;
using FoodMartMongo.Dtos.PeopleDtos;
using FoodMartMongo.Entities;
using FoodMartMongo.Settings;
using MongoDB.Driver;

namespace FoodMartMongo.Services.PeopleServices
{
    public class PeopleService : IPeopleService
    {
        private readonly IMongoCollection<People> _peopleCollection;
        private readonly IMapper _mapper;

        public PeopleService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _peopleCollection = database.GetCollection<People>(_databaseSettings.PeopleCollectionName);
            _mapper = mapper;
        }
        public async Task CreatePeopleAsync(CreatePeopleDto createPeopleDto)
        {
            var value = _mapper.Map<People>(createPeopleDto);
            await _peopleCollection.InsertOneAsync(value);
        }

        public async Task DeletePeopleAsync(string id)
        {
            await _peopleCollection.DeleteOneAsync(x => x.PeopleId == id);
        }

        public async Task<List<ResultPeopleDto>> GetAllPeopleAsync()
        {
            var values = await _peopleCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultPeopleDto>>(values);
        }

        public async Task<GetPeopleByIdDto> GetPeopleByIdAsync(string id)
        {
            var value = await _peopleCollection.Find(x => x.PeopleId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetPeopleByIdDto>(value);
        }

        public async Task UpdatePeopleAsync(UpdatePeopleDto updatePeopleDto)
        {
            var value = _mapper.Map<People>(updatePeopleDto);
            await _peopleCollection.FindOneAndReplaceAsync(x => x.PeopleId == updatePeopleDto.PeopleId, value);
        }
    }
}
