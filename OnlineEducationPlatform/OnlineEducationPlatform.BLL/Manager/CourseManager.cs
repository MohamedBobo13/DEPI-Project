using AutoMapper;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.DAL.Data.Models;
using OnlineEducationPlatform.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager
{
    public class CourseManager : ICourseManager
    {
        private readonly ICourseRepo _courseRepo;
        private readonly IMapper _mapper;

        public CourseManager(ICourseRepo courseRepo,IMapper mapper)
        {
           _courseRepo = courseRepo;
            _mapper = mapper;
        }
        //public void Add(CourseAddDto courseAddDto)
        //{
        //    _courseRepo.Add(_mapper.Map<Course>(courseAddDto));
        //    SaveChanges();
        //}

        public async Task AddAsync(CourseAddDto courseAddDto) /// Done 
        {
            var course = _mapper.Map<Course>(courseAddDto);
            await _courseRepo.AddAsync(course);
            //SaveChangesAsync();
        }

        //public void Delete(int id)
        //{
        //    _courseRepo.Delete(id);
        //    SaveChanges();
        //}

        public async Task<bool> DeleteAsync(int id)
        {
            var course =await _courseRepo.GetByIdAsync(id);
            if (course != null)
            {
                var result= await _courseRepo.DeleteAsync(course.Id);
                //SaveChangesAsync();
                if (result == true)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        //public IEnumerable<CourseReadDto> GetAll()
        //{
        //    return _mapper.Map<List<CourseReadDto>>(_courseRepo.GetAll());
        //}

        public async Task<IEnumerable<CourseReadDto>> GetAllAsync()
        {
            var courses =await _courseRepo.GetAllAsync();
            return _mapper.Map<List<CourseReadDto>>(courses);
        }

        //public async Task<CourseReadDto> GetById(int id)
        //{
        //    var course = await _courseRepo.GetById(id);

        //    // If the course is not found, return null.
        //    if (course == null)
        //    {
        //        return null;
        //    }

        //    // Map the course entity to a DTO asynchronously.
        //    return _mapper.Map<CourseReadDto>(course);
        //}

        public async Task<CourseReadDto> GetByIdAsync(int id)
        {
            var course=await _courseRepo.GetByIdAsync(id);
            if (course != null )
            {
                return _mapper.Map<CourseReadDto>(course);
            }
            return null;
        }

        //public CourseReadDto GetById(int id)
        //{
        //    return _mapper.Map<CourseReadDto>(_courseRepo.GetById(id));
        //}


        //public void SaveChanges()
        //{
        //    _courseRepo.SaveChanges();
        //}

        //public async Task SaveChangesAsync()
        //{
        //    await _courseRepo.SaveChangesAsync();
        //}

        //public async void  Task<Update>(CourseUpdateDto courseUpdateDto)
        //{
        //    // Retrieve the existing course asynchronously.
        //    var existingCourse = await _courseRepo.GetById(courseUpdateDto.Id);

        //    // Check if the course exists.
        //    if (existingCourse == null)
        //    {
        //        throw new KeyNotFoundException($"Course with ID {courseUpdateDto.Id} not found.");
        //    }

        //    // Map the updated values from the DTO to the existing course entity.
        //    _mapper.Map(courseUpdateDto, existingCourse);

        //    // Save changes to the database asynchronously.
        //    await _courseRepo.SaveChanges();
        //}

        //public async void Task<SaveChanges>()
        //{
        //    await _courseRepo.SaveChangesAsync();
        //}

        public async Task<CourseUpdateDto> UpdateAsync(CourseUpdateDto courseUpdateDto)
        {
            var course = await _courseRepo.GetByIdAsync(courseUpdateDto.Id);
            if (course != null)
            {
                course.Id = courseUpdateDto.Id; 
                course.TotalHours = courseUpdateDto.TotalHours;
                course.CreatedDate = courseUpdateDto.CreatedDate;   
                course.Description = courseUpdateDto.Description;
                course.Title = courseUpdateDto.Title;
                course.InstructorId = courseUpdateDto.InstructorId;

                await _courseRepo.UpdateAsync(course);
            }
            return null;
        }

        //public void Update(CourseUpdateDto courseUpdateDto)
        //{
        //    _mapper.Map<CourseUpdateDto, Course>(courseUpdateDto, await _courseRepo.GetById(courseUpdateDto.Id));
        //    SaveChanges();
        //}
    }
}
