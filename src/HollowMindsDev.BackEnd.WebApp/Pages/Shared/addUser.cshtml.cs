using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollowMindsDev.BackEnd.ApplicationCore.Entities.Users;
using HollowMindsDev.BackEnd.Services.Interfaces.IUsers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HollowMindsDev.BackEnd.WebApp.Pages.Shared
{
    public class addUserModel : PageModel
    {
        private readonly IUserService _userService;

        public addUserModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnPostSubmit(User user)
        {
        
                _userService.InsertUser(user);
        }
    }
}
