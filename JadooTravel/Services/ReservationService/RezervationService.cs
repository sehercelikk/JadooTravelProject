using AutoMapper;
using JadooTravel.Dtos.ReservationDtos;
using JadooTravel.Entities;
using JadooTravel.Settings;
using MongoDB.Driver;

namespace JadooTravel.Services.ReservationService;

public class RezervationService : IRezervationService
{
    private readonly IMongoCollection<Reservation> _reservations;
    private readonly IMapper _mapper;

    public RezervationService(IMapper mapper, IDatabaseSetting _databaseSetting)
    {
        var client = new MongoClient(_databaseSetting.ConnectionString);
        var database = client.GetDatabase(_databaseSetting.DatabaseName);
        _reservations = database.GetCollection<Reservation>(_databaseSetting.ReservationCollectionName);

        _mapper = mapper;
    }

    public async Task CreateRezervationAsync(CreateRezervationDto model)
    {
        var value = _mapper.Map<Reservation>(model);
        await _reservations.InsertOneAsync(value);
    }

    public async Task DeleteRezervationAsync(string id)
    {
        await _reservations.DeleteOneAsync(a=>a.Id==id);
    }

    public async Task<List<ResultRezervationDto>> GetAllRezervationAsync()
    {
        var values = await _reservations.Find(a => true).ToListAsync();
        return _mapper.Map<List<ResultRezervationDto>>(values);
    }

    public async Task<GetRezervationByIdDto> GetRezervationByIdAsync(string id)
    {
        var value = await _reservations.Find(a => a.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<GetRezervationByIdDto>(value);
    }

    public async Task UpdateRezervationAsync(UpdateRezervationDto model)
    {
       var value= _mapper.Map<Reservation>(model);
        await _reservations.FindOneAndReplaceAsync(a=>a.Id==model.Id, value);
    }
}
