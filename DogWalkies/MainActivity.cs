using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Java.IO;
using Android.Provider;
using System.Collections.Generic;
using Android.Content.PM;
using Environment = Android.OS.Environment;
using Uri = Android.Net.Uri;

namespace DogWalkies
{
    [Activity(Label = "DogWalkies", MainLauncher = true, Icon = "@drawable/icon", Theme = "@android:style/Theme.Material.Light.NoActionBar")]
    public class MainActivity : Activity
    {

        public static File _file;
        public static File _dir;
        public static Bitmap bitmap;
        private ImageView dogProfileImageView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView(Resource.Layout.Main);

            initializeFontStyle();
            initializeDogProfileImage();
            initializeClickEvents();

            if (IsThereAnAppToTakePictures())
            {
                CreateDirectoryForPictures();

                ImageButton addDogProfileImage = FindViewById<ImageButton>(Resource.Id.ImageButtonAddDogProfileImage);
                ImageButton camera = FindViewById<ImageButton>(Resource.Id.ImageButtonCamera);
                camera.Click += TakeAPicture;
                addDogProfileImage.Click += TakeAPicture;
            }
        }

        private void CreateDirectoryForPictures()
        {
            _dir = new File(
            Environment.GetExternalStoragePublicDirectory(Environment.DirectoryPictures), "DogWalkies");
            if (!_dir.Exists())
            {
                _dir.Mkdirs();
            }
        }

        private bool IsThereAnAppToTakePictures()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities =
                PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }

        private void initializeDogProfileImage()
        {
            //Programatically set the default dog profile image
            dogProfileImageView = FindViewById<ImageView>(Resource.Id.ImageViewDogProfile);
            dogProfileImageView.SetBackgroundResource(Resource.Drawable.dogProfileImageMainView);
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

        private void TakeAPicture(object sender, EventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            _file = new File(_dir, string.Format("DogWalkies_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(_file));
            StartActivityForResult(intent, 0);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            // Make it available in the gallery
            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            Uri contentUri = Uri.FromFile(_file);
            mediaScanIntent.SetData(contentUri);
            SendBroadcast(mediaScanIntent);

            // Display in the dogProfileImageView. 
            // We will resize the bitmap to fit the display.
            /*
            int height = Resources.DisplayMetrics.HeightPixels;
            int width = dogProfileImageView.Height;
            bitmap = _file.Path.LoadAndResizeBitmap(width, height);
            if (bitmap != null)
            {
                dogProfileImageView.SetImageBitmap(bitmap);
                bitmap = null;
            }
            */

            if (requestCode == 0 && resultCode == Result.Ok) {
                //Toast the User about the Saved Image
                string msg = "Image Saved to Gallery";
                Toast.MakeText(this, msg, ToastLength.Short).Show();
            }
            
            // Dispose of the Java side bitmap.
            GC.Collect();
        }

        private void StartWalkButton_Click(object sender, EventArgs e)
        {
            //Start Walk
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ProfileActivity));
        }

    }
}

