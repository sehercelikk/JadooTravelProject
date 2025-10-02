using JadooTravel.Dtos.TripPlanDtos;

namespace JadooTravel.Services.TripPlanService;

public interface ITripPlanService
{
    Task<List<ResultTripPlanDto>> GetAllTripPlanAsync();
    Task CreateTripPlanAsync(CreateTripPlanDto model);
    Task UpdateTripPlanAsync(UpdateTripPlanDto model);
    Task DeleteTripPlanAsync(string id);
    Task<GetTripPlanByIdDto> GetTripPlanByIdAsync(string id);
}
