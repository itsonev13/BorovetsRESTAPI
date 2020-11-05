using AutoMapper;
using KabileApi.Entities;
using KabileApi.Models;
using KabileApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KabileApi.Controllers
{
    [ApiController]
    [Route("api/course")]
     public class CourseController : ControllerBase
    {
        private readonly IMenuRepositorycs _menurepository;
        private readonly IMapper _mapper;

        public CourseController(IMenuRepositorycs menurepository, IMapper mapper)
        {
            _menurepository = menurepository ??
                throw new ArgumentNullException(nameof(menurepository));
            this._mapper = mapper ??
                 throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet(Name = "getCourses")]
        public IActionResult GetAllCourses()
        {
            IEnumerable <Courses> coursesFromRepo = _menurepository.GetCourses();
            if (coursesFromRepo == null)
            {
                return NotFound();
            }

            List<CourseDto> allcourses=new List<CourseDto>();
            foreach (var item in coursesFromRepo)
            {
                var course = _mapper.Map<CourseDto>(item);
                allcourses.Add(course);
            }
            return Ok(allcourses);
        }
        [HttpGet("{courseId}", Name = "getCourse")]
        public IActionResult GetCourse(int courseId)
        {
            var coursesFromRepo = _menurepository.GetCourse(courseId);
            if (coursesFromRepo == null)
            {
                return NotFound();
            }

            return Ok(coursesFromRepo);
        }
        [HttpPost]
        public ActionResult CreateCourse([FromBody] CourseDto course)
        {
            
            if (course == null)
            {
                return BadRequest();
            }
            var courseEntity = _mapper.Map<Courses>(course);
            _menurepository.AddCourse(courseEntity);
            _menurepository.Save();
            var courseToReturn = _mapper.Map<CourseDto>(courseEntity);
            return CreatedAtRoute("getCourse",
                new { courseId = courseToReturn.Id }, courseToReturn);

        }
        [HttpPut]
        public ActionResult UpdateCourse([FromBody] CourseDto course)
        {

            if (course == null)
            {
                return BadRequest();
            }
            var courseEntity = _mapper.Map<Courses>(course);
            _menurepository.UpdateCourse(courseEntity);
            _menurepository.Save();
            var courseToReturn = _mapper.Map<CourseDto>(courseEntity);
            return Ok();

        }
        [HttpDelete]
        public ActionResult DeleteCourse([FromBody] CourseDto course)
        {

            if (course == null)
            {
                return BadRequest();
            }
            var courseEntity = _mapper.Map<Courses>(course);
            _menurepository.DeleteCourse(courseEntity);
            _menurepository.Save();
            var courseToReturn = _mapper.Map<CourseDto>(courseEntity);
            return Ok();

        }
    }
}
