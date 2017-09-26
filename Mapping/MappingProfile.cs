using System.Linq;
using AutoMapper;
using carvecho.Controllers.Resources;
using carvecho.Models;

namespace carvecho.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            //Domain to api Resource
         CreateMap<Make, MakeResource>();
         CreateMap<Model, ModelResource>(); 
         CreateMap<Feature, FeatureResource>();   
         CreateMap<Vehical, VehicalResource>()
                  .ForMember(v   => v.Contact, opt => opt.MapFrom(v => new ContactResource{Name= v.ContactName, Email= v.ContactEmail, Phone=v.ContactPhone}))
                  .ForMember(vr => vr.Features , opt => opt.MapFrom(v => v.Features.Select(vf => vf.FeatureId )));
         CreateMap<VehicalResource, Vehical>()
                  .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
                  .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
                  .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.Email))
                  .ForMember(v => v.Features , opt => opt.MapFrom(vr => vr.Features.Select(id => new VehicalFeature{FeatureId = id})));

           
        }
    }
}