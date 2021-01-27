using AutoMapper;
using Registration.DomainModels.Models;
using Registration.WebApi.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.WebApi.Mapper
{
    public class ObjectsMapper:Profile
    {
        public ObjectsMapper()
        {
            CreateMap<LogInCommand, LogInUser>().ReverseMap();
            CreateMap<RegisterUserCommand, User>()
                .ForMember(d => d.Email, m => m.MapFrom(o => o.Email))
                .ForMember(d => d.UserName, m => m.MapFrom(o => o.UserName))
                .ForMember(d => d.GeneralInformation, m => m.MapFrom(o => new UserInformation()
                {
                   PersonalNumber = o.PersonalNumber,
                   IsMarried = o.IsMarried,
                   IsEmployed = o.IsEmployed,
                   RemunerationPerMonthe = o.RemunerationPerMonthe,
                   Address = o.Address
                })).ReverseMap();

            CreateMap<UpdateUserInfoCommand, UserInformation>()
                .ForMember(d => d.PersonalNumber, m => m.MapFrom(o => o.PersonalNumber))
                .ForMember(d => d.IsMarried, m => m.MapFrom(o => o.IsMarried))
                .ForMember(d => d.IsEmployed, m => m.MapFrom(o => o.IsEmployed))
                .ForMember(d => d.RemunerationPerMonthe, m => m.MapFrom(o => o.RemunerationPerMonthe))
                .ForMember(d => d.Address, m => m.MapFrom(o => o.Address)).ReverseMap();

        }
    }
}
