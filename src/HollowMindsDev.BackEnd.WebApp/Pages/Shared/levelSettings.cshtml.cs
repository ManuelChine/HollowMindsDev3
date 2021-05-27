using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollowMindsDev.BackEnd.ApplicationCore.Entities.Silos;
using HollowMindsDev.BackEnd.Services.Interfaces.ISilos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HollowMindsDev.BackEnd.WebApp.Pages.Shared
{
    public class levelSettingsModel : PageModel
    {
        private readonly ILimitService _limitService;

        public levelSettingsModel(ILimitService limitService)
        {
            _limitService = limitService;
        }
        public Limit Limit { get; set; }

        public void OnPostSubmit(Limit limit)
        {

            _limitService.InsertLimit(limit);
        }
    }
}
