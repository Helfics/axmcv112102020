using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;

namespace _03Navigation
{
    [Activity(Label = "DetailActivity")]
    public class DetailActivity : AppCompatActivity
    {
        private int id;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_detail);

            var textview = FindViewById<TextView>(Resource.Id.detail_textview1);
            var close = FindViewById<Button>(Resource.Id.detail_close);
            var cancel = FindViewById<Button>(Resource.Id.detail_cancel);

            id = Intent.GetIntExtra("MAIN_DETAIL_ID", -1);

            textview.Text = $"Detail id : {id}";

            close.Click += Close_Click;
            cancel.Click += Cancel_Click;
        }

        private void Cancel_Click(object sender, System.EventArgs e)
        {
            var data = new Intent();

            data.PutExtra("DETAIL_RESULT_ID",id);

            SetResult(Result.Canceled, data);

            Finish();
        }

        private void Close_Click(object sender, System.EventArgs e)
        {
            var data = new Intent();

            data.PutExtra("DETAIL_RESULT_ID",id);

            SetResult(Result.Ok, data);

            Finish();
        }
    }
}