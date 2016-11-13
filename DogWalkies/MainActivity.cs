using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Android.Content.Res;

namespace DogWalkies
{
    [Activity(Label = "DogWalkies", MainLauncher = true, Icon = "@drawable/icon", Theme = "@android:style/Theme.Material.Light.NoActionBar")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView(Resource.Layout.Main);

            initializeFontStyle();
            initializeClickEvents();
        }

        private void initializeClickEvents()
        {
            Button profileButton = FindViewById<Button>(Resource.Id.ButtonProfile);
            profileButton.Click += ProfileButton_Click;

            Button startWalkButton = FindViewById<Button>(Resource.Id.ButtonStartWalk);
            startWalkButton.Click += StartWalkButton_Click;
        }

        private void initializeFontStyle()
        {
            Typeface centuryGothic = Typeface.CreateFromAsset(Assets, "centuryGothic.ttf");

            TextView TVDogFirstName = FindViewById<TextView>(Resource.Id.TextViewDogFirstName);
            Button ButtonProfile = FindViewById<Button>(Resource.Id.ButtonProfile);
            Button ButtonStartWalk = FindViewById<Button>(Resource.Id.ButtonStartWalk);

            ButtonProfile.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            ButtonStartWalk.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            TVDogFirstName.SetTypeface(centuryGothic, TypefaceStyle.Normal);
        }

        private void StartWalkButton_Click(object sender, EventArgs e)
        {
            //click event
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            //Click event
        }
    }
}

