using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Odev_Dagitim_Portali.Dtos;
using Odev_Dagitim_Portali.Models;
using System.Security.Claims;

namespace Odev_Dagitim_Portali.Controllers
{
    [Route("api/Department/[Action]")]
    [ApiController]
    [Authorize]
    public class UniversityDepartmentController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        ResultDto result = new ResultDto();
        public UniversityDepartmentController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        
        [HttpGet]
        public List<University_departmentDto> GetList()
        {
            var department = _context.University_departments.ToList();
            var departmentDtos = _mapper.Map<List<University_departmentDto>>(department);
            return departmentDtos;
        }

        [HttpGet]
        [Route("{id}")]
        
        public University_departmentDto Get(int id)
        {
            var department = _context.University_departments.Where(s => s.Department_id == id).SingleOrDefault();
            var departmentDto = _mapper.Map<University_departmentDto>(department);
            return departmentDto;
        }

        [HttpPost]
        [Authorize(Roles = "Ogretmen,Admin")]
        public async Task<ResultDto> Post(University_departmentDto dto)
        {


            try
            {

                var department = _mapper.Map<University_department>(dto);

                _context.University_departments.Add(department);
                _context.SaveChanges();
                result.Status = true;
                result.Message = "Bölüm Eklendi.";
            }
            catch (Exception ex)
            {
                result.Status = false;  
                result.Message = ex.Message;
            }
            return result;
        }


        [HttpPut]
        [Authorize(Roles = "Ogretmen,Admin")]
        public ResultDto Put(University_departmentDto dto)
        {
            var department = _context.University_departments.Where(s => s.Department_id == dto.Department_id).SingleOrDefault();
            if (department == null)
            {
                result.Status = false;
                result.Message = "Bölüm Bulunamadı!";
                return result;
            }
            department.Department_name = dto.Department_name;
        

            _context.University_departments.Update(department);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Bölüm Düzenlendi";
            return result;
        }


        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Ogretmen,Admin")]
        public ResultDto Delete(int id)
        {
            var department = _context.University_departments.Where(s => s.Department_id == id).SingleOrDefault();
            if (department == null)
            {
                result.Status = false;
                result.Message = "Bölüm Bulunamadı!";
                return result;
            }
            _context.University_departments.Remove(department);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Bölüm Silindi";
            return result;
        }





    }
}
