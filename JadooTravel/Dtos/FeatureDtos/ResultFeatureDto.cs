namespace JadooTravel.Dtos.FeatureDtos;

public class ResultFeatureDto
{
    public string Id { get; set; } //Mongo db de object id olarak tutuluyor
    public string Title { get; set; }
    public string MainTitle { get; set; }
    public string Description { get; set; }
    public string VideoUrl { get; set; }
}
