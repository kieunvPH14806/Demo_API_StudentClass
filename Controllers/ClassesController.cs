using Demo_API_StudentClass.BUS.Models;
using Demo_API_StudentClass.BUS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_API_StudentClass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly ClassServices _classServices;
        

        public ClassesController(ClassServices classServices)
        {
            _classServices = classServices;
        }

        [HttpGet("Get")]
        public List<Classes> Get()
        {
            try
            {
                return _classServices.GetClassesList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [HttpGet("GetStudentInClass")]
        public List<Students> GetStudent(string nameClass)
        {
            try
            {
                return _classServices.GetStudentsInClass(nameClass);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [HttpPost]
        public List<Classes> GetStudent(Classes newClass)
        {
            try
            {
                return _classServices.AddClass(newClass);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [HttpPut("{id}")]
        public List<Classes> Edit(Classes newClass)
        {
            try
            {
                return _classServices.EditClass(newClass);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [HttpDelete("{id}")]
        public List<Classes> Delete(Classes newClass)
        {
            try
            {
                return _classServices.Delete(newClass);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
