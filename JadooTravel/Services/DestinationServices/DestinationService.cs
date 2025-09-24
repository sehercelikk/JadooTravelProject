using AutoMapper;
using JadooTravel.Dtos.DestinationDtos;
using JadooTravel.Entities;
using JadooTravel.Settings;
using MongoDB.Driver;

namespace JadooTravel.Services.DestinationServices;

public class DestinationService : IDestinationService
{
    private readonly IMongoCollection<Destination> _destinationCollection;
    private readonly IMapper _mapper;

    public DestinationService(IMapper mapper,IDatabaseSetting _databaseSetting)
    {
        var client= new MongoClient(_databaseSetting.ConnectionString);
        var database = client.GetDatabase(_databaseSetting.DatabaseName);
        _destinationCollection = database.GetCollection<Destination>(_databaseSetting.DestinationCollectionName);
        _mapper = mapper;
    }

    public async Task CreateDestinationAsync(CreateDestinationDto model)
    {
        var value = _mapper.Map<Destination>(model);
        await _destinationCollection.InsertOneAsync(value);
    }

    public async Task DeleteDestinationAsync(string id)
    {
       await _destinationCollection.DeleteOneAsync(a=>a.Id== id);
    }

    public async Task<GetDestinationByIdDto> GetDestinationByIdAsync(string id)
    {
        var value = await _destinationCollection.Find(a => a.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<GetDestinationByIdDto>(value);
    }

    public async Task<List<ResultDestinationDto>> GetDestinationListAsync()
    {
        var value = await _destinationCollection.Find(a => true).ToListAsync();
        return _mapper.Map<List<ResultDestinationDto>>(value);
    }

    public async Task UpdateDestinationAsync(UpdateDestinationDto model)
    {
        var value= _mapper.Map<Destination>(model);
        await _destinationCollection.FindOneAndReplaceAsync(a => a.Id == model.Id, value);

    }
}
