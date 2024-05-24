using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Odev_Dagitim_Portali.Dtos;
using Odev_Dagitim_Portali.Models;

namespace Odev_Dagitim_Portali.Controllers
{
    [Route("api/Class/[Action]")]
    [ApiController]
    //[Authorize]
    public class ClassController : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        ResultDto result = new ResultDto();
        public ClassController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }


        [HttpGet]
        public List<ClassDto> GetList()
        {
            var Class = _context.Classes.ToList();
            var ClassDtos = _mapper.Map<List<ClassDto>>(Class);
            return ClassDtos;
        }

        [HttpGet]
        [Route("{id}")]

        public ClassDto GetById(int id)
        {
            var Class = _context.Classes.Where(s => s.Class_id == id).SingleOrDefault();
            var ClassDto = _mapper.Map<ClassDto>(Class);
            return ClassDto;

        }

        [HttpPost]
        //[Authorize(Roles = "Ogretmen,Admin")]
        public async Task<ResultDto> Add(ClassDto dto)
        {


            try
            {

                var Class = _mapper.Map<Class>(dto);

                _context.Classes.Add(Class);
                _context.SaveChanges();
                result.Status = true;
                result.Message = "Sınıf Eklendi.";
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message;
            }
            return result;
        }


        [HttpPut]
        //[Authorize(Roles = "Ogretmen,Admin")]
        public ResultDto Edit(ClassDto dto)
        {
            var Class = _context.Classes.Where(s => s.Class_id == dto.Class_id).SingleOrDefault();
            if (Class == null)
            {
                result.Status = false;
                result.Message = "Sınıf Bulunamadı!";
                return result;
            }
            Class.Class_name= dto.Class_name;


            _context.Classes.Update(Class);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Sınıf Düzenlendi";
            return result;
        }


        [HttpDelete]
        [Route("{id}")]
        //[Authorize(Roles = "Ogretmen,Admin")]
        public ResultDto Delete(int id)
        {
            var Class = _context.Classes.Where(s => s.Class_id == id).SingleOrDefault();
            if (Class == null)
            {
                result.Status = false;
                result.Message = "Sınıf Bulunamadı!";
                return result;
            }
            _context.Classes.Remove(Class);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Sınıf Silindi";
            return result;
        }


        
    }
}
