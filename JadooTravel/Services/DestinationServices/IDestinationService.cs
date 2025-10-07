using JadooTravel.Dtos.DestinationDtos;

namespace JadooTravel.Services.DestinationServices;

public interface IDestinationService
{
    Task<List<ResultDestinationDto>> GetDestinationListAsync();
    Task CreateDestinationAsync(CreateDestinationDto model);
    Task UpdateDestinationAsync(UpdateDestinationDto model);
    Task DeleteDestinationAsync(string id);
    Task<GetDestinationByIdDto> GetDestinationByIdAsync(string id);
    Task<List<ResultDestinationDto>> TourWidthCapasity();
}
