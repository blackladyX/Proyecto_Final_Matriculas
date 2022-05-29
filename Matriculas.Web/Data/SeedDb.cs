using Matriculas.Web.Data.Entities;
using Matriculas.Web.Enums;
using Matriculas.Web.Helpers;
using Matriculas.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matriculas.Web.Data;

namespace Matriculas.Web.Data
{
    public class SeedDb
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserHelper _userHelper;
        public SeedDb(ApplicationDbContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCoursesAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1", "Orlando", "A", "oralpez@hotmail.com", "3000000000", "Calle Luna Calle Sol", UserType.Admin);
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task<User> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                   
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456"); //password debe tener una longitud de 6 caracteres
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }


    
    private async Task CheckCoursesAsync()
        {
            if (!_context.Courses.Any())
            {
                _context.Courses.Add(new Course
                {
                    CourseCode = "123",
                    CourseName = "programación",
                    InicialDate = "10/10/2020",
                    FinalDate = "11/11/2020",
                    Description = "Description del curso",
                    CourseCost = 50000,
                    DateInscripcion = "09/09/2020",
                    Capacity = 50,
                    Intensity = 5,
                    ClassSchedule = "lunes a viernes de 8 a 12 ",

                    Teachers = new List<Teacher>
                   {
                    new Teacher
                    {
                    TeacherIdentification = 123456789,
                    TeacherFullName = "Juan Manuel Betancur",
                    Dateofbirth = "27/10/1994",
                    Experience= "Trabajó como docente en Gobierno",
                    TeacherAddress = "Calle 31D # 89D - 30",
                    TeacherCellPhone = "3053224270",
                    ArtisticArea = "Programación",
                    }
                    }
                });
                await _context.SaveChangesAsync();
            }
        }
    }
}

