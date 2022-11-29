
using LanguageExt;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseRegistration.Application.Contracts.Commands;
using OnlineCourseRegistration.Contracts.Requests;


namespace OnlineCourseRegistration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> _logger;
        private readonly ISender _sender;
        private readonly IMapper _mapper; 
        public CourseController(ILogger<CourseController> logger, ISender sender ,IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
            _mapper=mapper?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost("AddCourse")]
        public async Task<IActionResult> AddCourse(AddCourseRequest request)

        {
            var command = _mapper.Map<CourseCommand>(request);
            var model = new AddNewCourseCommand(command);
            var result = await _sender.Send(model);
            return Ok(result);
           // return result.ToResponse(this);

        }


    }
}
