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
            try
            {
                return _studentsService.GetStudentsList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet("GetOne/{nameClass}")]
        public List<Students> GetOne(string nameClass)
        {
            try
            {
                return _studentsService.GetStudentsClass(nameClass);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost("Add")]
        public List<Students> Add(Students inputStudents)
        {
            try
            {
                return _studentsService.AddStudent(inputStudents);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        [HttpPut("Edit")]
        public List<Students> Edit(Students inputStudents)
        {
            try
            {
                return _studentsService.EditStudent(inputStudents);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [HttpDelete("Delete")]
        public List<Students> Delete(Students inputStudents)
        {
            try
            {
                return _studentsService.DeleteStudent(inputStudents);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
