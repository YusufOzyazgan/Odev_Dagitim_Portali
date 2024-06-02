using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Odev_Dagitim_Portali.Dtos;
using Odev_Dagitim_Portali.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Claims;

namespace Odev_Dagitim_Portali.Controllers
{
    [Authorize] 
    [Route("api/Homeworks/[Action]")]
    [ApiController]
    public class HomeworkController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        ResultDto result = new ResultDto();
        public HomeworkController(AppDbContext context, IMapper mapper,UserManager<AppUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }
        
        [HttpGet]
        public List<HomeworkDto> GetList()
        {
            var homeworks = _context.Homeworks.ToList();
            var homeworkDtos = _mapper.Map<List<HomeworkDto>>(homeworks);
            return homeworkDtos;
        }
        [HttpGet]
        [Route("{id}")]
        
        public HomeworkDto Get(int id)
        {
            var homework = _context.Homeworks.Where(s => s.Homework_id == id).SingleOrDefault();
            var homeworkDto = _mapper.Map<HomeworkDto>(homework);
            return homeworkDto;
        }
        
        [HttpGet]
        [Route("{id}")]
        public List<HomeworkSubmissionDto> GetHomeworkSubmissions(int id)
        {
            var homework_submissions = _context.HomeworkSubmissions.Where(s => s.Homework_id == id).ToList();
            var homework_submissionDtos = _mapper.Map<List<HomeworkSubmissionDto>>(homework_submissions);
            return homework_submissionDtos;
        }
        [HttpPost]
        [Authorize(Roles = "Teacher,Admin")]
        public async Task<ResultDto> Add(HomeworkDto dto)
        {
           
            
            if (dto == null)
            {
                result.Status = false;
                result.Message = "Değerleri Doldurun !!!";
                return result;
            }
            try
            {

                var homework = _mapper.Map<Homework>(dto);
                homework.Updated = DateTime.Now;
                homework.Created = DateTime.Now;
              
               

                _context.Homeworks.Add(homework);
                _context.SaveChanges();
                result.Status = true;
                result.Message = "Ödev Eklendi.";
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message ;
            }
            return result;
        }

        [HttpPut]
        [Authorize(Roles = "Teacher,Admin")]
        public ResultDto Edit(HomeworkDto dto)
        {
            var homework= _context.Homeworks.Where(s => s.Homework_id == dto.Homework_id).SingleOrDefault();
            if (homework == null)
            {
                result.Status = false;
                result.Message = "Ödev Bulunamadı!";
                return result;
            }
            homework.Homework_title = dto.Homework_title;
            homework.Homework_content = dto.Homework_content;
            homework.Homework_deadline = dto.Homework_deadline;
            homework.Updated = DateTime.Now;
            homework.Lesson_id = dto.Lesson_id;
            _context.Homeworks.Update(homework);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Ödev Düzenlendi";
            return result;
        }


        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Teacher,Admin")]
        public ResultDto Delete(int id)
        {
            var homework= _context.Homeworks.Where(s => s.Homework_id== id).SingleOrDefault();
            if (homework == null)
            {
                result.Status = false;
                result.Message = "Ödev Bulunamadı!";
                return result;
            }
            _context.Homeworks.Remove(homework);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Ödev Silindi";
            return result;
        }









    }
}
