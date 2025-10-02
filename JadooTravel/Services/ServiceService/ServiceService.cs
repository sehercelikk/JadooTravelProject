using AutoMapper;
using JadooTravel.Dtos.CategoryDtos;
using JadooTravel.Dtos.ReservationDtos;
using JadooTravel.Dtos.ServiceDtos;
using JadooTravel.Entities;
using JadooTravel.Settings;
using MongoDB.Driver;

namespace JadooTravel.Services.ServiceService;

public class ServiceService : IServiceService
{
    private readonly IMongoCollection<Service> _service;
    private readonly IMapper _mapper;

    public ServiceService(IMapper mapper, IDatabaseSetting _databaseSetting)
    {
        var client = new MongoClient(_databaseSetting.ConnectionString);
        var database = client.GetDatabase(_databaseSetting.DatabaseName);
        _service = database.GetCollection<Service>(_databaseSetting.ServiceCollectionName);

        _mapper = mapper;
    }

    public async Task CreateServiceAsync(CreateServiceDto model)
    {
        var value = _mapper.Map<Service>(model);
        await _service.InsertOneAsync(value);
    }

    public async Task DeleteServiceAsync(string id)
    {
        await _service.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<List<ResultServiceDto>> GetAllServiceAsync()
    {
        var values = await _service.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultServiceDto>>(values);
    }

    public async Task<GetServiceByIdDto> GetServiceByIdAsync(string id)
    {
        var value = await _service.Find(a => a.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<GetServiceByIdDto>(value);
    }

    public async Task UpdateServiceAsync(UpdateServiceDto model)
    {
        var value = _mapper.Map<Service>(model);
        await _service.FindOneAndReplaceAsync(a => a.Id == model.Id, value);
    }
}
