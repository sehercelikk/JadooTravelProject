using AutoMapper;
using JadooTravel.Dtos.CategoryDtos;
using JadooTravel.Dtos.DestinationDtos;
using JadooTravel.Dtos.FeatureDtos;
using JadooTravel.Dtos.ReservationDtos;
using JadooTravel.Dtos.TestimonialDtos;
using JadooTravel.Dtos.TripPlanDtos;
using JadooTravel.Entities;

namespace JadooTravel.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Category, ResultCategoryDto>().ReverseMap();
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category,UpdateCategoryDto>().ReverseMap();
        CreateMap<Category,GetCategoryByIdDto>().ReverseMap();

        CreateMap<Destination,ResultDestinationDto>().ReverseMap();
        CreateMap<Destination, CreateDestinationDto>().ReverseMap();
        CreateMap<Destination, UpdateDestinationDto>().ReverseMap();
        CreateMap<Destination,GetDestinationByIdDto>().ReverseMap();


        CreateMap<Feature, ResultFeatureDto>().ReverseMap();
        CreateMap<Feature, CreateFeatureDto>().ReverseMap();
        CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
        CreateMap<Feature, GetFeatureByIdDto>().ReverseMap();

        CreateMap<Reservation, ResultRezervationDto>().ReverseMap();
        CreateMap<Reservation, CreateRezervationDto>().ReverseMap();
        CreateMap<Reservation, UpdateRezervationDto>().ReverseMap();
        CreateMap<Reservation, GetRezervationByIdDto>().ReverseMap();


        CreateMap<UserReservation, CreateUserReservationDto>().ReverseMap();
        CreateMap<UserReservation, UpdateUserReservationDto>().ReverseMap();
        CreateMap<UserReservation, ResultUserReservationDto>().ReverseMap();
        CreateMap<UserReservation, GetUserReservationByIdDto>().ReverseMap();


        CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
        CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
        CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
        CreateMap<Testimonial, GetTestimonialByIdDto>().ReverseMap();


        CreateMap<TripPlan, ResultUserReservationDto>().ReverseMap();
        CreateMap<TripPlan, CreateUserReservationDto>().ReverseMap();
        CreateMap<TripPlan, UpdateUserReservationDto>().ReverseMap();
        CreateMap<TripPlan, GetUserReservationByIdDto>().ReverseMap();

    }
}
