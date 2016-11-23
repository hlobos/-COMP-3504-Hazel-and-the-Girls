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

        private ImageView ImageViewDogProfile;
        private Button ButtonProfile;
        private Button ButtonStartWalk;
        private TextView TextViewDogFirstName;
        private ImageButton ImageButtonAddDogProfileImage;
        private ImageButton ImageButtonCamera;

        private int REQUEST_PICK_IMAGE = 1;
        private int REQUEST_TAKE_IMAGE = 2;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView(Resource.Layout.Main);

            loadViews();
            initializeFontStyle();
            initializeDogProfileImage();
            initializeClickEvents();
        }

        private void loadViews()
        {
            TextViewDogFirstName = FindViewById<TextView>(Resource.Id.TextViewDogFirstName);
            ButtonProfile = FindViewById<Button>(Resource.Id.ButtonProfile);
            ButtonStartWalk = FindViewById<Button>(Resource.Id.ButtonStartWalk);
            ImageViewDogProfile = FindViewById<ImageView>(Resource.Id.ImageViewDogProfile);
            ImageButtonAddDogProfileImage = FindViewById<ImageButton>(Resource.Id.ImageButtonAddDogProfileImage);
            ImageButtonCamera = FindViewById<ImageButton>(Resource.Id.ImageButtonCamera);
        }

        private void initializeDogProfileImage()
        {
            //Programmatically set the default dog profile image
            ImageViewDogProfile.SetBackgroundResource(Resource.Drawable.dogProfileImageMainView);
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

        
        
        private void initializeClickEvents()
        {  
            
            ButtonProfile.Click += ButtonProfile_Click;
            ButtonStartWalk.Click += ButtonStartWalk_Click;

            if (IsThereAnAppToTakePictures())
            {
                CreateDirectoryForPictures();

                ImageButtonAddDogProfileImage.Click += GrabAPictureFromGallery;
                ImageButtonCamera.Click += TakeAPicture;
            }
        }

        private void initializeFontStyle()
        {
            Typeface centuryGothic = Typeface.CreateFromAsset(Assets, "centuryGothic.ttf");

            ButtonProfile.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            ButtonStartWalk.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            TextViewDogFirstName.SetTypeface(centuryGothic, TypefaceStyle.Normal);
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
                    if (resultCode == Result.Ok) {
                        saveAndDisplayDogProfileImage(data);
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

        private void saveAndDisplayDogProfileImage(Intent data)
        {
            ImageViewDogProfile.SetImageURI(data.Data);
        }

        private void ButtonStartWalk_Click(object sender, EventArgs e)
        {
            //Start Walk
        }

        private void ButtonProfile_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ProfileActivity));
        }

    }
}

