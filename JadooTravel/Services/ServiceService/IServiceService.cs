using JadooTravel.Dtos.ReservationDtos;
using JadooTravel.Dtos.ServiceDtos;

namespace JadooTravel.Services.ServiceService;

public interface IServiceService
{
    Task<List<ResultServiceDto>> GetAllServiceAsync();
    Task CreateServiceAsync(CreateServiceDto model);
    Task UpdateServiceAsync(UpdateServiceDto model);
    Task DeleteServiceAsync(string id);
    Task<GetServiceByIdDto> GetServiceByIdAsync(string id);
}
