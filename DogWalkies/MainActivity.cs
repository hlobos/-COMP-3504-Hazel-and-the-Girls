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
        private int REQUEST_PICK_IMAGE = 1;
        private int REQUEST_TAKE_IMAGE = 2;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView(Resource.Layout.Main);

            initializeFontStyle();
            initializeDogProfileImage();
            initializeClickEvents();
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
            //Programmatically set the default dog profile image
            dogProfileImageView = FindViewById<ImageView>(Resource.Id.ImageViewDogProfile);
            dogProfileImageView.SetBackgroundResource(Resource.Drawable.dogProfileImageMainView);
        }
        
        private void initializeClickEvents()
        {  
            Button profileButton = FindViewById<Button>(Resource.Id.ButtonProfile);
            profileButton.Click += ProfileButton_Click;

            Button startWalkButton = FindViewById<Button>(Resource.Id.ButtonStartWalk);
            startWalkButton.Click += StartWalkButton_Click;

            if (IsThereAnAppToTakePictures())
            {
                CreateDirectoryForPictures();

                ImageButton addDogProfileImage = FindViewById<ImageButton>(Resource.Id.ImageButtonAddDogProfileImage);
                addDogProfileImage.Click += GrabAPictureFromGallery;

                ImageButton camera = FindViewById<ImageButton>(Resource.Id.ImageButtonCamera);
                camera.Click += TakeAPicture;

            }
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

        private void GrabAPictureFromGallery(object sender, EventArgs e)
        {
            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(intent, "Select Picture"), REQUEST_PICK_IMAGE);
        }

        private void TakeAPicture(object sender, EventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            _file = new File(_dir, string.Format("DogWalkies_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(_file));
            StartActivityForResult(intent, REQUEST_TAKE_IMAGE);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == REQUEST_PICK_IMAGE) {
                if (data == null) {
                    Toast.MakeText(this, GetText(Resource.String.GeneralError), ToastLength.Short).Show();
                }
                else {
                    // Display image in the dogProfileImageView.
                    if (resultCode == Result.Ok) {
                        dogProfileImageView.SetImageURI(data.Data);
                    }
                }
            }
            
            if (requestCode == REQUEST_TAKE_IMAGE) {
                // Make it available in the gallery
                Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                Uri fromCameraUri = Uri.FromFile(_file);
                mediaScanIntent.SetData(fromCameraUri);
                SendBroadcast(mediaScanIntent);

                if (resultCode == Result.Ok) {
                    //Inform the user the image has been saved
                    Toast.MakeText(this, GetText(Resource.String.SavedToGallery), ToastLength.Short).Show();
                }
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

