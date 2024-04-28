﻿using AutoMapper;
using Odev_Dagitim_Portali.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Odev_Dagitim_Portali.Dtos;
using Odev_Dagitim_Portali.Models;
using System.Linq.Expressions;
using System.Security.Claims;
using System.IO;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Hosting;
using static Odev_Dagitim_Portali.Service.ManageImage;
using static Odev_Dagitim_Portali.Service.ImanageImage;

namespace Odev_Dagitim_Portali.Controllers
{
    [Authorize]
    [Route("api/HomeworkSubmission")]
    [ApiController]
    public class HomeworkSubmissionController : ControllerBase
    {
        
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IManageImage _iManageImage;
        ResultDto result = new ResultDto();

        public HomeworkSubmissionController(AppDbContext context, IMapper mapper, IManageImage iManageImage)
        {
            _context = context;
            _mapper = mapper;
            
            _iManageImage = iManageImage;
        }
        [HttpGet]
        [Authorize(Roles = "Ogretmen,Admin")]
        [Route("List")]
        public List<Homework_submissionDto> GetList()
        {
            var homework_submissions = _context.Homework_submissions.ToList();
            var homework_submissionDtos = _mapper.Map<List<Homework_submissionDto>>(homework_submissions);
            return homework_submissionDtos;
        }
        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Ogretmen,Admin")]
        public HomeworkDto Get(int id)
        {
            var homework = _context.Homeworks.Where(s => s.Homework_id == id).SingleOrDefault();

            var homeworkDto = _mapper.Map<HomeworkDto>(homework);
            return homeworkDto;
        }
        

        [HttpPost]
        [Route("UploadFile")]
        public async Task<ResultDto> UploadFile([FromForm] IFormFile file, [FromForm] Homework_submissionDto dto)
        {
            ResultDto result = new ResultDto(); 

            try
            {
                
                var usernameClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                var userId = usernameClaim?.Value; 

               
                var fileName = await _iManageImage.UploadFile(file);

                
                var homework_submission = new Homework_submission
                {
                    
                    Homework_id = dto.Homework_id,
                    User_id = userId,
                    File_name = fileName,
                    Updated = DateTime.Now,
                    Created = DateTime.Now
                };

               
                _context.Homework_submissions.Add(homework_submission);
                await _context.SaveChangesAsync(); 

               
                result.Status = true;
                result.Message = "Ödev eklendi " + fileName;
            }
            catch (Exception ex)
            {
                // Hata durumunu ve mesajını ayarlıyoruz
                result.Status = false;
                result.Message = "Hata oluştu: " + ex.Message;
            }

            // Sonucu döndürüyoruz
            return result;
        }
        [Authorize(Roles = "Ogretmen,Admin")]
        [HttpGet]
        [Route("DownloadFile")]
        public async Task<IActionResult> DownloadFile(string FileName)
        {
            var result = await _iManageImage.DownloadFile(FileName);
            return File(result.Item1, result.Item2, result.Item2);
        }

        [HttpPut]
        public async Task<ResultDto> Put([FromForm] IFormFile file, [FromForm] Homework_submissionDto dto)
        {
            var usernameClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            var userId = usernameClaim?.Value;

            var fileName = await _iManageImage.UploadFile(file);

            var submission = _context.Homework_submissions.Where(s => s.Submission_id == dto.Submission_id).SingleOrDefault();
            if (submission.User_id != userId)
            {
                result.Message = "kullanıcılar uyuşmuyor!!!";
                result.Status = false;
                return result;
            }
            if (submission == null)
            {
                result.Status = false;
                result.Message = "Ödev Bulunamadı!";
                return result;
            }
            submission.File_name = fileName;
            
            submission.Updated = DateTime.Now;
            
            _context.Homework_submissions.Update(submission);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Ödev Düzenlendi";
            return result;
        }
        [Authorize(Roles = "Ogretmen,Admin")]
        [HttpDelete]
        [Route("{id}")]
        public ResultDto Delete(int id)
        {
            var submission = _context.Homework_submissions.Where(s => s.Submission_id == id).SingleOrDefault();
            if (submission == null)
            {
                result.Status = false;
                result.Message = "Ödev Bulunamadı!";
                return result;
            }
            _context.Homework_submissions.Remove(submission);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Ödev Silindi";
            return result;
        }





    }
}
