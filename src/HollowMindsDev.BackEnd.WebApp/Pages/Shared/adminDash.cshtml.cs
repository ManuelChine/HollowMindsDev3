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
    public class adminDashModel : PageModel
    {
        private readonly IMeasurementService _measurementService;

        public adminDashModel(IMeasurementService measurementService)
        {
            _measurementService = measurementService;
        }

        public List<Measurement> Last { get; set; }

        public void OnGet()
        {
            Last = (List<Measurement>)_measurementService.GetLastMeasurement();
        }
    }
}
