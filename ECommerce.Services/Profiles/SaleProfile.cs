using AutoMapper;
using ECommerce.Dto.Response;
using ECommerce.Entities.Infos;

namespace ECommerce.Services.Profiles;

public class SaleProfile : Profile
{
    public SaleProfile()
    {
        CreateMap<InvoiceInfo, SaleDtoResponse>();

        CreateMap<SaleDetailInfo, SaleDetailDtoResponse>();

        CreateMap<ReportInfo, ReportDtoResponse>();
    }
}