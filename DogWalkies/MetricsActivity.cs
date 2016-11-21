using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;

namespace DogWalkies
{
    [Activity(Label = "DogWalkies", MainLauncher = true, Icon = "@drawable/icon", Theme = "@android:style/Theme.Material.Light.NoActionBar")]
    public class MetricsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Metrics);
            initializeFontStyle();
            initializeClickEvents();
        }

        private void initializeClickEvents()
        {
            //do dis later
        }

        private void initializeFontStyle()
        {
            Typeface centuryGothic = Typeface.CreateFromAsset(Assets, "centuryGothic.ttf");

            TextView TVDogFirstName = FindViewById<TextView>(Resource.Id.TextViewDogFirstName);
            Button ButtonWeek = FindViewById<Button>(Resource.Id.ButtonWeek);
            Button ButtonMonth = FindViewById<Button>(Resource.Id.ButtonMonth);
            Button ButtonYear = FindViewById<Button>(Resource.Id.ButtonMonth);
            Button ButtonNotes = FindViewById<Button>(Resource.Id.ButtonNotesText);
            
            ButtonWeek.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            ButtonMonth.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            ButtonYear.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            TVDogFirstName.SetTypeface(centuryGothic, TypefaceStyle.Normal);
        }
    }
}