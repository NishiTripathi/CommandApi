using AutoMapper;
using Commander.Dto;
using Commander.Models;

namespace Commander.Profiles
{
   public class CommandProfiles : Profile
   {
     public CommandProfiles()
     {
         CreateMap<Command , CommandReadDto>();
         CreateMap<CommandCreateDto , Command>();
         CreateMap<CommandUpdateDto ,Command>();
     }
   }
}