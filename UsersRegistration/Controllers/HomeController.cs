using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UsersRegistration.Models;
using UsersRegistration.Models.ViewModels;


namespace UsersRegistration.Controllers
{

   
    public class HomeController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly ApplicationContext context;

        public HomeController(UserManager<User> user, SignInManager<User> signIn, ApplicationContext applicationContext)
        {
            userManager = user;
            signInManager = signIn;
            context = applicationContext;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await userManager.GetUserAsync(User);
            if (currentUser == null || currentUser.Block == true)
            {
                await signInManager.SignOutAsync();
                return RedirectToAction("Login", "Account");
            }

            List<UsersViewModel> viewModels = new List<UsersViewModel>();
            var users = context.Users.ToList();

            foreach (var user in users)
            {
                UsersViewModel model = new UsersViewModel();
                model.Id = user.Id;
                model.Name = user.Name;
                model.Email = user.Email;
                model.RegistrationDate = user.RegistrationDate;
                model.LastLoginTime = user.LastLoginTime;
                model.IsBlock = user.Block;

                viewModels.Add(model);

            }

            return View(viewModels);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(List<UsersViewModel> usersViewModels)
        {

            List<User> users = await GetAllCheckedUsers(usersViewModels);
            context.Users.RemoveRange(users);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");


        }
        [HttpPost]
        public async Task<IActionResult> Bloked(List<UsersViewModel> usersViewModels)
        {

            List<User> users = await GetAllCheckedUsers(usersViewModels);
            foreach (var user in users)
            {
                user.Block = true;
            }
            context.Users.UpdateRange(users);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> UnBloked(List<UsersViewModel> usersViewModels)
        {
            List<User> users = await GetAllCheckedUsers(usersViewModels);
            foreach (var user in users)
            {
                user.Block = false;
            }
            context.Users.UpdateRange(users);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        public async Task<List<User>> GetAllCheckedUsers(List<UsersViewModel> usersViewModels)
        {
            List<User> users = new List<User>();
            foreach (var item in usersViewModels)
            {
                if (item.IsChecked)
                {
                    var selectedUser = await context.Users.FindAsync(item.Id);

                    if (selectedUser != null)
                    {
                        users.Add(selectedUser);
                    }

                }
            }
            return users;

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
