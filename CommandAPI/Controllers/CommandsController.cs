using AutoMapper;
using CommandAPI.Data;
using CommandAPI.Dtos;
using CommandAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CommandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandAPIRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommandAPIRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/<CommandsController>
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> Get()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        // GET api/<CommandsController>/5
        [HttpGet("{id}")]
        public ActionResult<CommandReadDto> Get(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if(commandItem == null)
            {
                return NotFound();
            }
            else
            {
                return _mapper.Map<CommandReadDto>(commandItem);
            }

        }

        // POST api/<CommandsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CommandsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CommandsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // DELETE api/<CommandsController>/5
        [HttpDelete("{command}")]
        public void Delete(Command command)
        {
        }
    }
}
