using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Odev_Dagitim_Portali.Dtos;
using Odev_Dagitim_Portali.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Odev_Dagitim_Portali.Controllers
{
    [Route("api/Homeworks")]
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
        [Route("{id}/Homework_submission")]
        public List<Homework_submissionDto> GetHomeworkSubmissions(int id)
        {
            var homework_submissions = _context.Homework_submissions.Where(s => s.Homework_id == id).ToList();
            var homework_submissionDtos = _mapper.Map<List<Homework_submissionDto>>(homework_submissions);
            return homework_submissionDtos;
        }
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<ResultDto> Post(HomeworkDto dto)
        {
            //var userId = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(dto.User_name);

            try
            {
                var homework = _mapper.Map<Homework>(dto);
                homework.Updated = DateTime.Now;
                homework.Created = DateTime.Now;
                
                homework.User_id = user.Id.ToString();

                _context.Homeworks.Add(homework);
                _context.SaveChanges();
                result.Status = true;
                result.Message = "Ödev Eklendi userId = "+user.Id.ToString();
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "User ID = "+user.Id + " User name = "+ dto.User_name+" " +ex;
            }
            return result;
        }











    }
}
