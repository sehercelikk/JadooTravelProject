using JadooTravel.Dtos.FeatureDtos;

namespace JadooTravel.Services.FeatureService;

public interface IFeatureService
{
    Task<List<ResultFeatureDto>> GetAllFeaturesAsync();
    Task<bool> CreateFeatureAsync(CreateFeatureDto feature);
    Task UpdateFeatureAsync(UpdateFeatureDto feature);
    Task DeleteFeatureAsync(string id);
    Task<GetFeatureByIdDto> GetFeatureByIdAsync(string id);
}
