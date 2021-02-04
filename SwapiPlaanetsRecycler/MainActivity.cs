using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Refit;
using System.Net.Http;
using ModernHttpClient;
using System;
using System.Threading.Tasks;
using System.Linq;
using Android.Text;
using Android.Views;

namespace SwapiPlaanetsRecycler
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private IPlanetsApi _planetsApi;
        private RecyclerView _recyclerView;
        private List<Planet> _planets = new List<Planet>();
        private PlanetAdapter _adapter;
        private EditText _editText;
        private string _planetNumber;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
                      

            var client = new HttpClient(new NativeMessageHandler())
            {
                BaseAddress = new Uri("https://swapi.dev/api")
            };
            _planetsApi = RestService.For<IPlanetsApi>(client);
            _editText = FindViewById<EditText>(Resource.Id.editText1);

            _recyclerView = (RecyclerView)FindViewById(Resource.Id.list);
            _adapter = new PlanetAdapter(this, _planets);
            _recyclerView.SetLayoutManager(new LinearLayoutManager(this));
            _recyclerView.SetAdapter(_adapter);
            _editText.TextChanged += EditTextTextChanged;
            InitialisePlanetsList();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
           
            switch (item.ItemId)
            {
                case Resource.Id.itemMenu1:
                    InitializePlanetListByItemMenu("1");
                    return true;
                case Resource.Id.itemMenu2:
                    InitializePlanetListByItemMenu("2");
                    return true;
                case Resource.Id.itemMenu3:
                    InitializePlanetListByItemMenu("3");
                    return true;
                case Resource.Id.itemMenu4:
                    InitializePlanetListByItemMenu("4");
                    return true;
                case Resource.Id.itemMenu5:
                    InitializePlanetListByItemMenu("5");
                    return true;
                case Resource.Id.itemMenu6:
                    InitializePlanetListByItemMenu("6");
                    return true;
                default:
                    return true;
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void InitializePlanetListByItemMenu(string id)
        {
            var task = Task.Run(async () =>
            {
                try
                {
                    _planets.Clear();
                    _planets.AddRange((await _planetsApi.GetPlanets(id)).Results);
                    RunOnUiThread(() => _adapter.NotifyDataSetChanged());
                }
                catch (Exception ex)
                {
                }
            });
        }

        private void InitialisePlanetsList()
        {
            if (string.IsNullOrEmpty(_planetNumber))
            {
                _planets.Clear();
                _adapter.NotifyDataSetChanged();
                return;
            }

            var task = Task.Run(async () =>
            {
                try
                {
                    _planets.Clear();
                    _planets.AddRange((await _planetsApi.GetPlanets(_planetNumber)).Results);
                    RunOnUiThread(() => _adapter.NotifyDataSetChanged());
                }
                catch (Exception ex)
                {
                }
            });
        }

        private void EditTextTextChanged(object sender, TextChangedEventArgs e)
        {
            _planetNumber = _editText.Text;
             InitialisePlanetsList();
        }
    }
}