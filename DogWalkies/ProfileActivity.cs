using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace DogWalkies
{
    [Activity(Label = "ProfileActivity", Theme = "@android:style/Theme.Material.Light.NoActionBar")]
    public class ProfileActivity : Activity
    {
        private ImageView dogProfileImageView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Profile);

            //Don't automatically popup the android keyboard when activity starts
            Window.SetSoftInputMode(SoftInput.StateHidden);

            initializeDogProfileImage();
            initializeClickEvents();
        }

        private void initializeDogProfileImage()
        {
            //Programmatically set the default dog profile image
            dogProfileImageView = FindViewById<ImageView>(Resource.Id.ImageViewDogProfile);
            dogProfileImageView.SetBackgroundResource(Resource.Drawable.dogProfileImageMainView);
        }

        private void initializeClickEvents()
        {
            Button metricsButton = FindViewById<Button>(Resource.Id.ButtonMetrics);
            metricsButton.Click += MetricsButton_Click;
        }

        private void MetricsButton_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MetricsActivity));
        }
    }
}