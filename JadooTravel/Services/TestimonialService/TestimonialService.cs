using AutoMapper;
using JadooTravel.Dtos.TestimonialDtos;
using JadooTravel.Entities;
using JadooTravel.Settings;
using MongoDB.Driver;

namespace JadooTravel.Services.TestimonialService;

public class TestimonialService : ITestimonialService
{
    private readonly IMongoCollection<Testimonial> _testimonial;
    private readonly IMapper _mapper;

    public TestimonialService(IMapper mapper, IDatabaseSetting _databaseSetting)
    {
        var client = new MongoClient(_databaseSetting.ConnectionString);
        var database = client.GetDatabase(_databaseSetting.DatabaseName);
        _testimonial = database.GetCollection<Testimonial>(_databaseSetting.TestimonialCollectionName);

        _mapper = mapper;
    }


    public async Task CreateTestimonialAsync(CreateTestimonialDto model)
    {
        var value= _mapper.Map<Testimonial>(model);
        await _testimonial.InsertOneAsync(value);
    }

    public Task DeleteTestimonialAsync(string id)
    {
        return _testimonial.DeleteOneAsync(a => a.Id == id);
    }

    public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
    {
        var values = await _testimonial.Find(a => true).ToListAsync();
        return _mapper.Map<List<ResultTestimonialDto>>(values);
    }

    public async Task<GetTestimonialByIdDto> GetTestimonialByIdAsync(string id)
    {
        var value = await _testimonial.Find(a => a.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<GetTestimonialByIdDto>(value);
    }

    public async Task UpdateTestimonialAsync(UpdateTestimonialDto model)
    {
        var value = _mapper.Map<Testimonial>(model);
        await _testimonial.FindOneAndReplaceAsync(a => a.Id == model.Id, value);
    }
}
