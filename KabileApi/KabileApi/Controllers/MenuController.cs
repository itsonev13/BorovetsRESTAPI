using AutoMapper;
using KabileApi.Entities;
using KabileApi.Models;
using KabileApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KabileApi.Controllers
{
    [ApiController]
    [Route("api/menu")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepositorycs _menurepository;
        private readonly IMapper _mapper;

        public MenuController(IMenuRepositorycs menurepository, IMapper mapper)
        {
            _menurepository = menurepository ??
                throw new ArgumentNullException(nameof(menurepository));
            this._mapper = mapper ??
                 throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet()]
        public IActionResult GetMenu()
        {
            var menuFromRepo = _menurepository.GetMenu();
            if (menuFromRepo == null)
            {
                return NotFound();
            }
            List<MenuDto> allcourses = new List<MenuDto>();
            foreach (var item in menuFromRepo)
            {
                var  menu = _mapper.Map<MenuDto>(item);
                allcourses.Add(menu);
            }
            return Ok(allcourses); ;
        }
        [HttpGet("{menuId}", Name = "getMenu")]
        public IActionResult GetMenu(int menuId)
        {
            var menuFromRepo = _menurepository.GetMenuItem(menuId);
            if (menuFromRepo == null)
            {
                return NotFound();
            }

            return Ok(menuFromRepo);
        }
        
        [HttpPost]
        public ActionResult CreateMenu([FromBody] MenuDto menu)
        {

            if (menu == null)
            {
                return BadRequest();
            }
            var menuEntity = _mapper.Map<Menu>(menu);
            _menurepository.AddMenu(menuEntity);
            _menurepository.Save();
            var menutoReturn = _mapper.Map<MenuDto>(menuEntity);
            return CreatedAtRoute("getMenu",
                new { menuId = menutoReturn.Id }, menutoReturn);

        }
        
        [HttpPut]
        public ActionResult UpdateMenu([FromBody] MenuDto menu)
        {

            if (menu == null)
            {
                return BadRequest();
            }
            var menuEntity = _mapper.Map<Menu>(menu);
            _menurepository.UpdateMenu(menuEntity);
            _menurepository.Save();
            return Ok();

        }
        [HttpDelete]
        public ActionResult DeleteMenu([FromBody] MenuDto menu)
        {

            if (menu == null)
            {
                return BadRequest();
            }
            var menuEntity = _mapper.Map<Menu>(menu);
            _menurepository.DeleteMenu(menuEntity);
            _menurepository.Save();
            return Ok();

        }
    }
}
