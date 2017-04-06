using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticoDeMatematicas.DAL;
using DiagnosticoDeMatematicas.Models;
using DiagnosticoDeMatematicas.Models.ViewModels.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace DiagnosticoDeMatematicas.Services
{
    public class UsersService
    {
        private readonly SiteContext _context;
        private readonly Settings _settings;

        public UsersService(SiteContext context)
        {
            _context = context;
            _settings = new Settings(_context);
        }

        public List<int> ExamGrades(string email)
        {
            var examGrades = new List<int>();

            var evaluations = _settings["Evaluations"].Split(',');

            foreach (var evaluation in evaluations)
            {
                var responses = _context.Responses.Where(e => e.ExamId.ToString() == evaluation && e.UserId == email);
                if (!responses.Any())
                {
                    examGrades.Add(-1);
                }
                else
                {
                    var max = 0.0;
                    foreach (var response in responses)
                    {
                        if (response.Grade > max)
                            max = response.Grade;
                    }
                    examGrades.Add((int)(Math.Ceiling(max) / 100 * 3));
                }
            }

            while(examGrades.Count < 20)
                examGrades.Add(-1);

            return examGrades;
        }

        public IdentityResult AddUser(CreateUserViewModel model)
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.UserName,
                DateOfBirth = model.DateOfBirth,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Facility = model.Facility,
                Liking = model.Liking,
                Interest = model.Interest,
                Gender = model.Gender
            };

            var userManager = new AppUserManager(new UserStore<User>(_context));
            return userManager.Create(user, model.Password);
        }

        public ICollection<UserWithRoleStringViewModel> GetUsersWithRoles()
        {
            ICollection<User> users = _context.Users.ToList();
            var model = new List<UserWithRoleStringViewModel>();

            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(_context));

            foreach (var user in users)
            {
                model.Add(new UserWithRoleStringViewModel
                {
                    User = user,
                    Roles = string.Join(", ", user.Roles.Select(r => roleManager.FindById(r.RoleId).Name))
                });
            }

            return model;
        }

        public User GetUser(string id)
        {
            return _context.Users.Find(id);
        }
    }
}