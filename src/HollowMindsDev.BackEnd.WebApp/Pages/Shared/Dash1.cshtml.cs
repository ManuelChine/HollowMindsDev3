using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollowMindsDev.BackEnd.Services.Interfaces.ISilos;
using HollowMindsDev.BackEnd.Services.Interfaces.ViewModel;
using HollowMindsDev.BackEnd.Services.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HollowMindsDev.BackEnd.WebApp.Pages.Shared.DashBoardSilos
{
    public class Dash1Model : PageModel
    {
        private readonly IMeasurementModelService _measurementModelService;

        public Dash1Model(IMeasurementModelService measurementModelService)
        {
            _measurementModelService = measurementModelService;
        }

        public List<MeasurementModel> Last { get; set; }

        public void OnGet()
        {
            Last = _measurementModelService.GetAllModel();
        }
    }
}
