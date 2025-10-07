using JadooTravel.Dtos.TripPlanDtos;

namespace JadooTravel.Services.UserReservationService;

public interface IUserReservationService
{
    Task<List<ResultUserReservationDto>> GetAllUserReservationAsync();
    Task CreateUserReservationAsync(CreateUserReservationDto model);
    Task DeleteUserReservationAsync(string id);
    Task<GetUserReservationByIdDto> GetUserReservationByIdAsync(string id);
}
