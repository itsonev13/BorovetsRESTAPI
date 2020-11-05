
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using KabileApi.Entities;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using KabileApi.DbContext;

namespace KabileApi.Services

{
    public class MenuRepository : IMenuRepositorycs, IDisposable
    {
        private readonly borovetsdbContext _context;

        public MenuRepository(borovetsdbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddCourse( Courses course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }
            // always set the AuthorId to the passed-in authorId
            _context.Courses.Add(course);
        }

        public void DeleteCourse(Courses course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }
            var menuitems=_context.Menu.Where(x => x.CourseId == course.Id).ToList();
            foreach(var item in menuitems)
            {
                _context.Menu.Remove(item);
            }
            _context.Courses.Remove(course);
        }

        public Courses GetCourse(int courseId)
        {
            if (courseId == 0)
            {
                throw new ArgumentNullException(nameof(courseId));
            }

            return _context.Courses
              .Where(c => c.Id == courseId).FirstOrDefault();
        }

        public IEnumerable<Courses> GetCourses()
        {

            return _context.Courses.ToList();
        }

        public void UpdateCourse(Courses course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }
            var courseForUpdate = _context.Courses.Where(c => c.Id == course.Id).FirstOrDefault();
            courseForUpdate.Name = course.Name;
            _context.Attach(courseForUpdate).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void AddMenu(Menu menuItem)
        {
            

            if (menuItem == null)
            {
                throw new ArgumentNullException(nameof(menuItem));
            }
            // always set the AuthorId to the passed-in authorId
            _context.Menu.Add(menuItem);
        }

        public void DeleteMenu(Menu menuItem)
        {
            if (menuItem == null)
            {
                throw new ArgumentNullException(nameof(menuItem));
            }
            _context.Menu.Remove(menuItem);
        }

       public Menu GetMenuItem(int menuItemId)
        {
            if (menuItemId == 0)
            {
                throw new ArgumentNullException(nameof(menuItemId));
            }

            return _context.Menu.FirstOrDefault(m => m.Id == menuItemId);
        }

        public IEnumerable<Menu> GetMenu()
        {
            return _context.Menu.ToList<Menu>();
        }

        public void UpdateMenu(Menu menu)
        {
            // no code in this implementation
            if (menu == null)
            {
                throw new ArgumentNullException(nameof(menu));
            }
            var menuForUpdate = _context.Menu.Where(m => m.Id == menu.Id).FirstOrDefault();
            menuForUpdate.Name = menu.Name;
            menuForUpdate.Price = menu.Price;
            menuForUpdate.CourseId = menu.CourseId;
            _context.Attach(menuForUpdate).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}