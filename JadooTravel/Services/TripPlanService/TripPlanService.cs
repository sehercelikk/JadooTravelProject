using AutoMapper;
using JadooTravel.Dtos.TripPlanDtos;
using JadooTravel.Entities;
using JadooTravel.Settings;
using MongoDB.Driver;

namespace JadooTravel.Services.TripPlanService;

public class TripPlanService : ITripPlanService
{
    private readonly IMongoCollection<TripPlan> _tripPlan;
    private readonly IMapper _mapper;

    public TripPlanService(IMapper mapper, IDatabaseSetting _databaseSetting)
    {
        var client= new MongoClient(_databaseSetting.ConnectionString);
        var database = client.GetDatabase(_databaseSetting.DatabaseName);
        _tripPlan=database.GetCollection<TripPlan>(_databaseSetting.TripPlanCollectionName);

        _mapper = mapper;
    }

    public async Task CreateTripPlanAsync(CreateTripPlanDto model)
    {
        var value = _mapper.Map<TripPlan>(model);
        await _tripPlan.InsertOneAsync(value);
    }

    public async Task DeleteTripPlanAsync(string id)
    {
        await _tripPlan.DeleteOneAsync(a=>a.Id==id);
    }

    public async Task<List<ResultTripPlanDto>> GetAllTripPlanAsync()
    {
        var value= await _tripPlan.Find(a=>true).ToListAsync();
        return _mapper.Map<List<ResultTripPlanDto>>(value);
    }

    public async Task<GetTripPlanByIdDto> GetTripPlanByIdAsync(string id)
    {
        var value = await _tripPlan.Find(a => a.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<GetTripPlanByIdDto>(value);
    }

    public async Task UpdateTripPlanAsync(UpdateTripPlanDto model)
    {
        var value= _mapper.Map<TripPlan>(model);
        await _tripPlan.FindOneAndReplaceAsync(a=>a.Id==model.Id,value);
    }
}
