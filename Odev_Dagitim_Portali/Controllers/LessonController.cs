﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Odev_Dagitim_Portali.Dtos;
using Odev_Dagitim_Portali.Models;
using System.Security.Claims;

namespace Odev_Dagitim_Portali.Controllers
{
    [Route("api/Lesson/[Action]")]
    [ApiController]
    [Authorize]
    public class LessonController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        
        ResultDto result = new ResultDto();
        public LessonController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

       
        [HttpGet]
        
        public List<LessonDto> GetList()
        {
            var lesson = _context.Lessons.ToList();
            var lessonDtos = _mapper.Map<List<LessonDto>>(lesson);
            return lessonDtos;
        }

        [HttpGet]
        [Route("{id}")]
        
        public LessonDto Get(int id)
        {
            var lesson = _context.Lessons.Where(s => s.Lesson_id == id).SingleOrDefault();
            var lessonDto = _mapper.Map<LessonDto>(lesson);
            return lessonDto;
        }

        [HttpPost]
        [Authorize(Roles = "Ogretmen,Admin")]
        public async Task<ResultDto> Post(LessonDto dto)
        {



            

            
            
            try
            {

                var lesson = _mapper.Map<Lesson>(dto);
                
                _context.Lessons.Add(lesson);
                _context.SaveChanges();
                result.Status = true;
                result.Message = "Ders Eklendi.";
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
        public ResultDto Put(LessonDto dto)
        {
            var lesson = _context.Lessons.Where(s => s.Lesson_id == dto.Lesson_id).SingleOrDefault();
            if (lesson == null)
            {
                result.Status = false;
                result.Message = "Ders Bulunamadı!";
                return result;
            }
            lesson.Lesson_name = dto.Lesson_name;
            lesson.Department_id = dto.Department_id;
            
            _context.Lessons.Update(lesson);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Ders Düzenlendi";
            return result;
        }


        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Ogretmen,Admin")]
        public ResultDto Delete(int id)
        {
            var lesson = _context.Lessons.Where(s => s.Lesson_id == id).SingleOrDefault();
            if (lesson == null)
            {
                result.Status = false;
                result.Message = "Ders Bulunamadı!";
                return result;
            }
            _context.Lessons.Remove(lesson);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Ders Silindi";
            return result;
        }


    }
}
