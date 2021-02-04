using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapiPlaanetsRecycler
{
    public interface IPlanetsApi
    {
        [Get("/planets/?page={pageNumber}")]
        Task<PlanetsResponse> GetPlanets(string pageNumber);
    }
}