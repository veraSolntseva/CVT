using AutoMapper;
using BL.DataModels;
using CVT.Models;
using DAL.DbObjects;
using System.Linq;

namespace CVT.Mapper
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<Person, PersonDataModel>();

            CreateMap<PersonDataModel, Person>();


            CreateMap<ContactInfo, ContactDataModel>();

            CreateMap<ContactDataModel, ContactInfo>();


            CreateMap<PersonDataModel, PersonViewModel>()
                .ForMember(x => x.Contacts, opt => opt.MapFrom(y => y.Contacts.OrderBy(i => i.Type)));

            CreateMap<PersonViewModel, PersonDataModel>();


            CreateMap<ContactDataModel, ContactViewModel>();

            CreateMap<ContactViewModel, ContactDataModel>();
        }
    }
}
