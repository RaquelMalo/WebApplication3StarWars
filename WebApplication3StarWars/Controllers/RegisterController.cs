using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebApplication3StarWars.Cross_Structure.Exceptions;
using WebApplication3StarWars.Services.Register;
using WebApplication3StarWars.Services.Repository;

namespace WebApplication3StarWars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly ILogger _log;
        private readonly IRegister _register;
        private readonly IRepository _repository;
        private readonly ISaveRepository _saveRepository;

        public RegisterController(IRepository repository, ISaveRepository saveRepository, IRegister register,
            ILogger<RegisterController> log)
        {
            _repository = repository;
            _saveRepository = saveRepository;
            _register = register;
            _log = log;
        }

        // GET api/register
        [HttpGet]
        public ActionResult GetRebels()
        {
            try
            {
                var okRebels = _saveRepository.SaveRebels(_repository.RebelString());
                _register.RebelRegister(okRebels);
                _log.LogInformation("Data received and registered correctly");
                return Ok(JsonConvert.SerializeObject(okRebels));
            }
            catch (Exception e)
            {
                //_log.LogError(e.Message, e.InnerException); //Exception log inside the Middleware
                /* If I do return instead of throwing the exception, the middleware don't handle it. */
                //return new ObjectResult(new {message = e.Message, innerException = e.InnerException});
                throw new ControllerException(e.Message, e.InnerException);//throw e
            }
        }
    }
}