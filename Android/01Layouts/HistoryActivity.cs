using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Layouts
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class HistoryActivity : AppCompatActivity
    {
        private ListView listviewResuts;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_history);

           listviewResuts = FindViewById<ListView>(Resource.Id.listview_results);

           listviewResuts.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, MainActivity.DataResults);

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}