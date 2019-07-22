using AutoMapper;
using ToDo.Models;
using ToDo.DataLayer.Entities;

namespace ToDo.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ToDoModel, ToDoEntity>();

            CreateMap<ToDoEntity, ToDoModel>();
        }

    }
}