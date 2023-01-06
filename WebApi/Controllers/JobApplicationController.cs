using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork unitOfWork;


        public JobApplicationController(
           IUnitOfWork UnitOfWork,
           IMapper mapper
          )
        {

            unitOfWork = UnitOfWork;
            _mapper = mapper;
        }



        [Route("[action]")]
        [HttpPost]
        public IActionResult Add(DTO.JobApplication dtoModel)
        {
            var entitiy = _mapper.Map<Entity.JobApplication>(dtoModel);
            unitOfWork.JobApplication.Insert(entitiy);
            unitOfWork.Complete();
            return Ok(entitiy);
        }
    }
}
