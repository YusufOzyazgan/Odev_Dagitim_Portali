using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Odev_Dagitim_Portali.Dtos;
using Odev_Dagitim_Portali.Models;

namespace Odev_Dagitim_Portali.Controllers
{
    [Route("api/Homeworks")]
    [ApiController]
    public class HomeworkController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        ResultDto result = new ResultDto();
        public HomeworkController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
        public ResultDto Post(HomeworkDto dto)
        {
            
            var homework = _mapper.Map<Homework>(dto);
            homework.Updated = DateTime.Now;
            homework.Created = DateTime.Now;
            _context.Homeworks.Add(homework);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Kategori Eklendi";
            return result;
        }











    }
}
