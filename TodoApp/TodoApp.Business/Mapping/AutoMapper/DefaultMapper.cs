using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Business.Dtos.Responses;
using TodoApp.Entities;

namespace TodoApp.Business.Mapping.AutoMapper
{
    public class DefaultMapper : Profile
    {
        public DefaultMapper()
        {           
            CreateMap<User, UserResponse>().ReverseMap();           
        }
    }
}
