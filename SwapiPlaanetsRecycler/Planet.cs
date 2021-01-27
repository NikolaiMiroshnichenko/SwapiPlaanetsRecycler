﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwapiPlaanetsRecycler
{

    public class Planet
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rotation_period")]
        public long RotationPeriod { get; set; }

        [JsonProperty("orbital_period")]
        public long OrbitalPeriod { get; set; }

        [JsonProperty("diameter")]
        public long Diameter { get; set; }

        [JsonProperty("climate")]
        public string Climate { get; set; }

        [JsonProperty("gravity")]
        public string Gravity { get; set; }

        [JsonProperty("terrain")]
        public string Terrain { get; set; }

        [JsonProperty("surface_water")]
        public long SurfaceWater { get; set; }

        [JsonProperty("population")]
        public string Population { get; set; }

        [JsonProperty("residents")]
        public Uri[] Residents { get; set; }

        [JsonProperty("films")]
        public Uri[] Films { get; set; }

        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        [JsonProperty("edited")]
        public DateTimeOffset Edited { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

}