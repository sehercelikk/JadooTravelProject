using AutoMapper;
using JadooTravel.Dtos.TestimonialDtos;
using JadooTravel.Dtos.TripPlanDtos;
using JadooTravel.Entities;
using JadooTravel.Settings;
using MongoDB.Driver;

namespace JadooTravel.Services.UserReservationService;

public class UserReservationService : IUserReservationService
{
    private readonly IMongoCollection<UserReservation> _userReservation;
    private readonly IMapper _mapper;

    public UserReservationService(IMapper mapper, IDatabaseSetting _databaseSetting)
    {
        var client = new MongoClient(_databaseSetting.ConnectionString);
        var database = client.GetDatabase(_databaseSetting.DatabaseName);
        _userReservation = database.GetCollection<UserReservation>(_databaseSetting.UserReservationCollectionName);

        _mapper = mapper;
    }
    public async Task CreateUserReservationAsync(CreateUserReservationDto model)
    {
        var value = _mapper.Map<UserReservation>(model);
        await _userReservation.InsertOneAsync(value);
    }

    public Task DeleteUserReservationAsync(string id)
    {
        return _userReservation.DeleteOneAsync(a => a.Id == id);
    }

    public async Task<List<ResultUserReservationDto>> GetAllUserReservationAsync()
    {
        var values = await _userReservation.Find(a => true).ToListAsync();
        return _mapper.Map<List<ResultUserReservationDto>>(values);
    }

    public async Task<GetUserReservationByIdDto> GetUserReservationByIdAsync(string id)
    {
        var value = await _userReservation.Find(a => a.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<GetUserReservationByIdDto>(value);
    }
}
