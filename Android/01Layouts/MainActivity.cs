﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Layouts
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button btn1;
        private Button btn2;
        private Button btn3;
        private Button btn4;
        private Button btn5;
        private Button btn6;
        private Button btn7;
        private Button btn8;
        private Button btn9;
        private Button btn0;
        private Button btnPlus;
        private Button btnEqual;
        private Button btnHistory;
        //private ListView listviewResuts;
        private TextView currentTextview;
        private TextView resultTextview;

        public static List<string> DataResults = new List<string>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            btn1 = FindViewById<Button>(Resource.Id.button1);
            btn2 = FindViewById<Button>(Resource.Id.button2);
            btn3 = FindViewById<Button>(Resource.Id.button3);
            btn4 = FindViewById<Button>(Resource.Id.button4);
            btn5 = FindViewById<Button>(Resource.Id.button5);
            btn6 = FindViewById<Button>(Resource.Id.button6);
            btn7 = FindViewById<Button>(Resource.Id.button7);
            btn8 = FindViewById<Button>(Resource.Id.button8);
            btn9 = FindViewById<Button>(Resource.Id.button9);
            btn0 = FindViewById<Button>(Resource.Id.button0);
            btnPlus = FindViewById<Button>(Resource.Id.buttonPlus);
            btnEqual = FindViewById<Button>(Resource.Id.buttonEqual);
            btnHistory = FindViewById<Button>(Resource.Id.buttonHistory);

            //listviewResuts = FindViewById<ListView>(Resource.Id.listview_results);

            currentTextview = FindViewById<TextView>(Resource.Id.textview_current);
            currentTextview.Text = string.Empty;

            resultTextview = FindViewById<TextView>(Resource.Id.textview_result);
            resultTextview.Text = string.Empty;

            btn1.Click += Btn_Click;
            btn2.Click += Btn_Click;
            btn3.Click += Btn_Click;
            btn4.Click += Btn_Click;
            btn5.Click += Btn_Click;
            btn6.Click += Btn_Click;
            btn7.Click += Btn_Click;
            btn8.Click += Btn_Click;
            btn9.Click += Btn_Click;
            btn0.Click += Btn_Click;
            btnPlus.Click += Btn_Click;

            btnEqual.Click += BtnEqual_Click;
            btnHistory.Click += BtnHistory_Click;
        }

        private void BtnHistory_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(HistoryActivity));

            StartActivity(intent);
        }

        private void BtnEqual_Click(object sender, EventArgs e)
        {
            var operations = currentTextview
                                              .Text
                                              ?.Split('+')
                                              .Where(x => !string.IsNullOrEmpty(x))
                                              .ToList();

            if (!operations.Any())
                Toast.MakeText(this, "La saisie est vide", ToastLength.Short).Show();

            else
            {
                var result = operations
                                              .Select(int.Parse)
                                              .Sum()
                                              .ToString();

                DataResults.Insert(0, result);

                resultTextview.Text = result;

                //listviewResuts.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, dataResults);

                currentTextview.Text = string.Empty;
            }
        }

        private void Btn_Click(object sender, System.EventArgs e)
        {
            currentTextview.Text += ((Button)sender).Text;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}