using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollowMindsDev.BackEnd.ApplicationCore.Entities.Silos;
using HollowMindsDev.BackEnd.Services.Interfaces.Allert;
using HollowMindsDev.BackEnd.Services.Interfaces.ISilos;
using HollowMindsDev.BackEnd.Services.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HollowMindsDev.BackEnd.WebApp.Pages.Shared
{
    public class userDashModel : PageModel
    {
        private readonly IMeasurementService _measurementService;
        private readonly IAllertService _allertService;


        public userDashModel(IMeasurementService measurementService, IAllertService allertService)
        {
            _measurementService = measurementService;
            _allertService = allertService;
        }

        public List<Measurement> Last { get; set; }
        public List<AllertModel> Allert { get; set; }

        public void OnGet()
        {
            Last = (List<Measurement>)_measurementService.GetLastMeasurement();

            Allert = _allertService.CreatorAllert();
        }
    }
}
