using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dto;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    { //private readonly MockCommandRepo _repo = new MockCommandRepo();
    private readonly ICommandRepo _repo;
    private readonly IMapper _mapper;
    public CommandsController(ICommandRepo repo,IMapper mapper)
    {
        _repo= repo;
        _mapper = mapper;
    }
    //Get
    [HttpGet]
     public ActionResult <IEnumerable<CommandReadDto>> GetAllCommands()
     {
      var commandItems = _repo.GetAppCommand();
      return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
     }
     //Get By ID
     [HttpGet("{id}", Name="GetCommandById")]
     public ActionResult <CommandReadDto> GetCommandById (int id)
     {
       var commandItem = _repo.GetCommandById(id);
       if(commandItem==null)
       {
         return NotFound();
       }
       return Ok(_mapper.Map<CommandReadDto>(commandItem));
     }
     //Post
     [HttpPost]
     public ActionResult <CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
     {
       var createCommand = _mapper.Map<Command>(commandCreateDto);
       _repo.CreateCommand(createCommand);
       _repo.SaveChanges();
       var commandReadDto = _mapper.Map<CommandReadDto>(createCommand);
        return CreatedAtRoute(nameof(GetCommandById),new {Id = commandReadDto.Id},commandReadDto);

     }
     [HttpPut("{id}")]
     public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdate)
     {
        var updateCommand = _repo.GetCommandById(id);
        if(updateCommand==null)
        {
          NotFound();
        }
        _mapper.Map(commandUpdate,updateCommand);
        _repo.UpdateCommand(updateCommand);
        _repo.SaveChanges();
        return Ok(updateCommand);
     }
    }    
}