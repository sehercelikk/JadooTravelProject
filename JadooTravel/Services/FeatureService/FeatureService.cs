using AutoMapper;
using JadooTravel.Dtos.FeatureDtos;
using JadooTravel.Entities;
using JadooTravel.Settings;
using MongoDB.Driver;

namespace JadooTravel.Services.FeatureService;

public class FeatureService : IFeatureService
{
    private readonly IMongoCollection<Feature> _features;
    private readonly IMapper _mapper;

    public FeatureService(IMapper mapper, IDatabaseSetting _databaseSetting)
    {
        var client = new MongoClient(_databaseSetting.ConnectionString);
        var database = client.GetDatabase(_databaseSetting.DatabaseName);
        _features = database.GetCollection<Feature>(_databaseSetting.FeatureCollectionName);
        _mapper = mapper;
    }

    public async Task<bool> CreateFeatureAsync(CreateFeatureDto feature)
    {
        var value = _mapper.Map<Feature>(feature);
        var kontrol = await _features.CountDocumentsAsync(FilterDefinition<Feature>.Empty);
        if (kontrol == 0)
        {
            await _features.InsertOneAsync(value);
            return true; // eklendi
        }
        else
        {
            return false; // zaten vardı, eklenmedi
        }
    }

    public async Task DeleteFeatureAsync(string id)
    {
        await _features.DeleteOneAsync(a => a.Id == id);
    }

    public async Task<List<ResultFeatureDto>> GetAllFeaturesAsync()
    {
        var values = await _features.Find(a => true).ToListAsync();
        return _mapper.Map<List<ResultFeatureDto>>(values);
    }

    public async Task<GetFeatureByIdDto> GetFeatureByIdAsync(string id)
    {
        var value = await _features.Find(a => a.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<GetFeatureByIdDto>(value);
    }

    public async Task UpdateFeatureAsync(UpdateFeatureDto feature)
    {
        var value = _mapper.Map<Feature>(feature);
        await _features.FindOneAndReplaceAsync(a => a.Id == feature.Id, value);
    }
}
