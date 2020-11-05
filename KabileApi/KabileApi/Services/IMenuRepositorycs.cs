using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KabileApi.Entities;

namespace KabileApi.Services
{
    public interface IMenuRepositorycs
    {
        IEnumerable<Courses> GetCourses();
        Courses GetCourse(int courseId);
        void AddCourse(Courses course);
        void UpdateCourse(Courses course);
        void DeleteCourse(Courses course);
        IEnumerable<Menu> GetMenu();
      //  IEnumerable<Menu> GetMenu(string mainCategory);
        Menu GetMenuItem(int menuItemId);
        void AddMenu(Menu menuItem);
        void DeleteMenu(Menu menuItem);
        void UpdateMenu(Menu menuItem);
        bool Save();
    }
}
