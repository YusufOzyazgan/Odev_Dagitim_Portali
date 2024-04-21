using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Odev_Dagitim_Portali.Dtos;
using Odev_Dagitim_Portali.Models;
using System.Security.Claims;

namespace Odev_Dagitim_Portali.Controllers
{
    [Route("api/HomeworkSubmission")]
    [ApiController]
    public class HomeworkSubmissionController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        ResultDto result = new ResultDto();
        public HomeworkSubmissionController(AppDbContext context, IMapper mapper, UserManager<AppUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }
        [HttpGet]
        public List<Homework_submissionDto> GetList()
        {
            var homework_submissions = _context.Homework_submissions.ToList();
            var homework_submissionDtos = _mapper.Map<List<Homework_submissionDto>>(homework_submissions);
            return homework_submissionDtos;
        }
        [HttpGet]
        [Route("{id}")]
        public HomeworkDto Get(int id)
        {
            var homework = _context.Homeworks.Where(s => s.Homework_id == id).SingleOrDefault();
            var homeworkDto = _mapper.Map<HomeworkDto>(homework);
            return homeworkDto;
        }
        [HttpPost]
        [Authorize]
        public async Task<ResultDto> Post(Homework_submissionDto dto)
        {
            //var userId = _userManager.GetUserId(User);

            //var user = await _userManager.FindByIdAsync(userId);


            var usernameClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            var userID = usernameClaim.Value.ToString();

            ;
            if (userID == null)
            {
                result.Status = false;
                result.Message = "Kayıt için giriş yapmalısınız !!!";
                return result;
            }
            try
            {

                var homework_submission = _mapper.Map<Homework_submission>(dto);
                homework_submission.Updated = DateTime.Now;
                homework_submission.Created = DateTime.Now;

                homework_submission.User_id = userID;

                _context.Homework_submissions.Add(homework_submission);
                _context.SaveChanges();
                result.Status = true;
                result.Message = "Ödev Eklendi.";
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message;
            }
            return result;
        }






    }
}
