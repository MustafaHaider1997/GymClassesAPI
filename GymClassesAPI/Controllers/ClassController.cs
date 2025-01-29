using GymClassesAPI.Models;
using GymClassesAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GymClassesAPI.Controllers
{
    [Route("api/classes")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly ClassRepository _classRepository;

        // Injecting the repository through constructor
        public ClassController(ClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        [HttpPost]
        public IActionResult CreateClass([FromBody] ClassModel classRequest)
        {
            if (string.IsNullOrWhiteSpace(classRequest.Name))
                return BadRequest("Class name is required.");
            if (classRequest.Capacity < 1)
                return BadRequest("Class capacity must be at least 1.");
            if (classRequest.EndDate <= DateTime.UtcNow.Date)
                return BadRequest("End date must be in the future.");

            for (DateTime date = classRequest.StartDate; date <= classRequest.EndDate; date = date.AddDays(1))
            {
                classRequest.ClassInstances.Add(new ClassInstance
                {
                    Date = date,
                    Capacity = classRequest.Capacity
                });
            }

            _classRepository.AddClass(classRequest);
            return CreatedAtAction(nameof(GetClassById), new { id = classRequest.Id }, classRequest);
        }

        [HttpGet]
        public IActionResult GetAllClasses() => Ok(_classRepository.GetAllClasses());

        [HttpGet("{id}")]
        public IActionResult GetClassById(Guid id)
        {
            var gymClass = _classRepository.GetClassById(id);
            return gymClass is not null ? Ok(gymClass) : NotFound("Class not found.");
        }
    }
}