using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Widget;

namespace _03Navigation
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private const int DETAIL_REQUESTCODE = 1;

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            switch (requestCode)
            {
                case DETAIL_REQUESTCODE: 
                    Toast.MakeText(this, $"Result : { resultCode }, id result : {data.GetIntExtra("DETAIL_RESULT_ID", -1)}", ToastLength.Short).Show();
                    break;
                default: break;
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            var button = FindViewById<Button>(Resource.Id.main_button1);

            button.Click += Button_Click;
        }

        private void Button_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(DetailActivity));
            intent.PutExtra("MAIN_DETAIL_ID", 1);

            // Uniquement pour des navigations sans resultat
            StartActivity(intent);

            // A appeler pour que le OnActivityResult soit déclencher au retour
            //StartActivityForResult(intent, DETAIL_REQUESTCODE);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}