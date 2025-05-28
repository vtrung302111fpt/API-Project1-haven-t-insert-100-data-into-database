using API_Project1.Entities;
using AutoMapper;

namespace API_Project1
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<InvoiceListEntity, InvoiceListEntity>().
                ForMember(dest => dest.ghiChu, opt => opt.Ignore());
            CreateMap<GhiChuEntity, GhiChuEntity>();
            CreateMap<InvoiceDetailEntity, InvoiceDetailEntity>();
            CreateMap<DsHangHoaEntity, DsHangHoaEntity>();
            CreateMap<DsThueSuatEntity, DsThueSuatEntity>();
        }
    }
}
