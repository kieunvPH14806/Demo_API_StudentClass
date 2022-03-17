using Demo_API_StudentClass.BUS.Models;
using Demo_API_StudentClass.BUS.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_API_StudentClass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentsService _studentsService;

        public StudentController(StudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        [HttpGet("Get")]
        public List<Students> Get()
        {
            return _studentsService.GetStudentsList();
        }
        [HttpGet("Gethcc")]
        public List<string> Gethcc()
        {
            List<string> name = new List<string>();

            foreach (var x in _studentsService.GetStudentsList())
            {
                name.Add(x.Name);
            }

            return name;
        }
    }
}
