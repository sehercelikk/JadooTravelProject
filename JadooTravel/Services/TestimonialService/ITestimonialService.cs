using JadooTravel.Dtos.TestimonialDtos;

namespace JadooTravel.Services.TestimonialService;

public interface ITestimonialService
{
    Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();
    Task CreateTestimonialAsync(CreateTestimonialDto model);
    Task UpdateTestimonialAsync(UpdateTestimonialDto model);
    Task DeleteTestimonialAsync(string id);
    Task<GetTestimonialByIdDto> GetTestimonialByIdAsync(string id);
}
