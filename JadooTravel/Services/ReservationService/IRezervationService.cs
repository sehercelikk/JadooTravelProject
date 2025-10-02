using JadooTravel.Dtos.ReservationDtos;

namespace JadooTravel.Services.ReservationService;

public interface IRezervationService
{
    Task<List<ResultRezervationDto>> GetAllRezervationAsync();
    Task CreateRezervationAsync(CreateRezervationDto model);
    Task UpdateRezervationAsync(UpdateRezervationDto model);
    Task DeleteRezervationAsync(string id);
    Task<GetRezervationByIdDto> GetRezervationByIdAsync(string id);
}
