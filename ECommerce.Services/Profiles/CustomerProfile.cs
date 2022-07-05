using AutoMapper;
using ECommerce.Dto.Request;
using ECommerce.Dto.Response;
using ECommerce.Entities;

namespace ECommerce.Services.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerDtoResponse>()
            .ForMember(dto => dto.Id, ent => ent.MapFrom(x => x.Id))
            .ForMember(dto => dto.FullName, ent => ent.MapFrom(x => $"{x.FirstName} {x.LastName}"))
            .ForMember(dto => dto.Age, ent => ent.MapFrom(x => DateTime.Today.Year - x.BirthDate.Year))
            .ForMember(dto => dto.Email, ent => ent.MapFrom(x => x.Email))
            .ForMember(dto => dto.DocumentNumber, ent => ent.MapFrom(x => x.DocumentNumber))
            .ForMember(dto => dto.Dependants, ent => ent.MapFrom(x => x.Dependants));

        CreateMap<CustomerDtoRequest, Customer>()
            .ForMember(ent => ent.FirstName, dto => dto.MapFrom(x => x.FirstName))
            .ForMember(ent => ent.LastName, dto => dto.MapFrom(x => x.LastName))
            .ForMember(ent => ent.Email, dto => dto.MapFrom(x => x.Email))
            .ForMember(ent => ent.BirthDate, dto => dto.MapFrom(x => Convert.ToDateTime(x.BirthDate)))
            .ForMember(ent => ent.DocumentNumber, dto => dto.MapFrom(x => x.DocumentNumber))
            .ForMember(ent => ent.Dependants, dto => dto.MapFrom(x => x.Dependants));

    }
}