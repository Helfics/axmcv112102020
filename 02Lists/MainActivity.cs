using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using Java.Lang;
using Android.Views;
using Android.Support.V7.Widget;

namespace _02Lists
{

    public class CustomAdapter : BaseAdapter
    {
        private readonly Activity context;
        private readonly List<string> lst;

        public CustomAdapter(Activity context, List<string> lst)
        {
            this.context = context;
            this.lst = lst;
        }

        public override int Count => lst.Count;

        public override Object GetItem(int position)
        {
            return lst[position];
        }

        public override long GetItemId(int position)
        {
            return -1;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.listitem_simplelistitem, parent, false);

            var textview = view.FindViewById<TextView>(Resource.Id.listitem_text1);

            textview.Text = lst[position];

            return view;
        }
    }

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private List<string> data;
        private BaseAdapter adapter;
        private ListView listview;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            listview = FindViewById<ListView>(Resource.Id.listview);

            data =  new List<string> { "1", "2", "3", "1", "2", "3", "1", "2", "3", "1", "2", "3", "1", "2", "3", "1", "2", "3", "1", "2", "3", "1", "2", "3", "1", "2", "3", "1", "2", "3" };
            
            adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, data);
            
            listview.Adapter = adapter;

            listview.ItemClick += Listview_ItemClick;
        }

        private void Listview_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var item = adapter.GetItem(e.Position);

            Toast.MakeText(this, $"Element selectionnée {item}", ToastLength.Short).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}