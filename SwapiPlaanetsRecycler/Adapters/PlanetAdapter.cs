﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwapiPlaanetsRecycler
{
    public class PlanetAdapter : RecyclerView.Adapter
    {
        private LayoutInflater _inflater;
        private List<Planet> _planets;

        public override int ItemCount => _planets.Count;

        public PlanetAdapter(Context context, List<Planet> planets)
        {
            _planets = planets;
            _inflater = LayoutInflater.From(context);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = _inflater.Inflate(Resource.Layout.item_layout, parent, false);
            return new PlanetViewHolder(view);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            Planet planet = _planets.ElementAt(position);
            var planetVH = (PlanetViewHolder)holder;
            planetVH.nameTW.Text = planet.Name;
            planetVH.terrainTW.Text = planet.Terrain;
            planetVH.poppulationTW.Text = planet.Population;
        }
    }
}