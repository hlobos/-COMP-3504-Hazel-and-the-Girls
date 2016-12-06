using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Content;
using Uri = Android.Net.Uri;
using Android.Provider;
using System.IO;
using Android.Graphics.Drawables;

namespace DogWalkies
{
    [Activity(Label = "ProfileActivity", Theme = "@android:style/Theme.Material.Light.NoActionBar")]
    public class ProfileActivity : Activity
    {
        private TextView TextViewDogFirstName;
        private TextView TextViewOwnerName;
        private EditText EditTextOwnerNameData;
        private TextView TextViewBreed;
        private EditText EditTextBreedData;
        private TextView TextViewAge;
        private EditText EditTextAgeData;
        private TextView TextViewBirthdate;
        private EditText EditTextBirthdateData;
        private TextView TextViewColor;
        private EditText EditTextColorData;
        private TextView TextViewGender;
        private EditText EditTextGenderData;
        private TextView TextViewMicrochip;
        private EditText EditTextMicrochipData;

        private RelativeLayout RelativeLayoutDogProfileImage;
        private ImageButton ImageButtonAddDogProfileImage;
        //private ImageButton ImageButtonEditDogOwnerName;

        private Button ButtonViewAlbum;
        private Button ButtonMetrics;

        private DogAccessLayer dataDogAccess = DogAccessLayer.getInstance();
        private Dog dog;
        private byte[] dogProfileImage;

        private int REQUEST_PICK_IMAGE = 1;
        //private int REQUEST_EDIT_INFO = 1;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Profile);

            //Don't automatically popup the android keyboard when activity starts
            Window.SetSoftInputMode(SoftInput.StateHidden);

            loadViews();
            initializeFontStyle();
            initializeDogProfileImage();
            initializeClickEvents();
            initializeTextViewData();
        }

        
        private void loadViews()
        {
            TextViewDogFirstName = FindViewById<TextView>(Resource.Id.TextViewDogFirstName);
            TextViewOwnerName = FindViewById<TextView>(Resource.Id.TextViewOwnerName);
            EditTextOwnerNameData = FindViewById<EditText>(Resource.Id.EditTextOwnerNameData);
            TextViewBreed = FindViewById<TextView>(Resource.Id.TextViewBreed);
            EditTextBreedData = FindViewById<EditText>(Resource.Id.EditTextBreedData);
            TextViewAge = FindViewById<TextView>(Resource.Id.TextViewAge);
            EditTextAgeData = FindViewById<EditText>(Resource.Id.EditTextAgeData);
            TextViewBirthdate = FindViewById<TextView>(Resource.Id.TextViewBirthdate);
            EditTextBirthdateData = FindViewById<EditText>(Resource.Id.EditTextBirthdateData);
            TextViewColor = FindViewById<TextView>(Resource.Id.TextViewColor);
            EditTextColorData = FindViewById<EditText>(Resource.Id.EditTextColorData);
            TextViewGender = FindViewById<TextView>(Resource.Id.TextViewGender);
            EditTextGenderData = FindViewById<EditText>(Resource.Id.EditTextGenderData);
            TextViewMicrochip = FindViewById<TextView>(Resource.Id.TextViewMicrochip);
            EditTextMicrochipData = FindViewById<EditText>(Resource.Id.EditTextMicrochipData);
            RelativeLayoutDogProfileImage = FindViewById<RelativeLayout>(Resource.Id.RelativeLayoutDogProfileImage);
            ImageButtonAddDogProfileImage = FindViewById<ImageButton>(Resource.Id.ImageButtonAddDogProfileImage);
            ButtonViewAlbum = FindViewById<Button>(Resource.Id.ButtonViewAlbum);
            ButtonMetrics = FindViewById<Button>(Resource.Id.ButtonMetrics);
        }

        private void initializeFontStyle()
        {
            Typeface centuryGothic = Typeface.CreateFromAsset(Assets, "centuryGothic.ttf");
            TextViewDogFirstName.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            TextViewOwnerName.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            EditTextOwnerNameData.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            TextViewBreed.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            EditTextBreedData.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            TextViewAge.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            EditTextAgeData.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            TextViewBirthdate.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            EditTextBirthdateData.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            TextViewColor.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            EditTextColorData.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            TextViewGender.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            EditTextGenderData.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            TextViewMicrochip.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            EditTextMicrochipData.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            ButtonViewAlbum.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            ButtonMetrics.SetTypeface(centuryGothic, TypefaceStyle.Normal);
        }

        private void initializeDogProfileImage()
        {
            dog = dataDogAccess.getDogByID(0);

            //Set the ImageView for the dog profile image
            var bitmapDrawable = new BitmapDrawable(BitmapFactory.DecodeByteArray(dog.ProfileImage, 0, dog.ProfileImage.Length));
            RelativeLayoutDogProfileImage.SetBackgroundDrawable(bitmapDrawable);
        }

        private void initializeClickEvents()
        {
            ButtonMetrics.Click += ButtonMetrics_Click;
            ImageButtonAddDogProfileImage.Click += GrabAPictureFromGallery;

           // ImageButtonEditDogOwnerName.Click += EditDogProfile;

            ButtonViewAlbum.Click += ButtonViewAlbum_Click;

        }
        private void initializeTextViewData()
        {
           
            EditTextOwnerNameData.Text = dog.OwnerName;
            EditTextBreedData.Text = dog.Breed;
            EditTextAgeData.Text = dog.Age;
            EditTextBirthdateData.Text = dog.Birthdate;
            EditTextColorData.Text = dog.Color;
            EditTextGenderData.Text = dog.Gender;
            EditTextMicrochipData.Text = dog.Microchip;
        }


        private void ButtonMetrics_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MetricsActivity));
        }

        
        private void ButtonViewAlbum_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionView);
            intent.SetFlags(ActivityFlags.NewTask);
            StartActivity(Intent.CreateChooser(intent, "Open folder"));
        }

        private void GrabAPictureFromGallery(object sender, EventArgs e)
        {
            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(intent, "Select Picture"), REQUEST_PICK_IMAGE);
            
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == REQUEST_PICK_IMAGE)
            {
                if (data == null)
                {
                    Toast.MakeText(this, GetText(Resource.String.GeneralError), ToastLength.Short).Show();
                }
                else
                {
                    if (resultCode == Result.Ok)
                    {
                        UpdateDogProfileImageFromIntentData(data);
                    }
                }
            }
        }


       

        private void UpdateDogProfileImageFromIntentData(Intent data)
        {
            //Uri --> Bitmap
            Uri newProfileImgUri = data.Data;
            Bitmap newProfileImgBitmap = MediaStore.Images.Media.GetBitmap(ContentResolver, newProfileImgUri);

            //Bitmap --> byte[] array
            MemoryStream stream = new MemoryStream();
            newProfileImgBitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
            dogProfileImage = stream.ToArray();

            //Update database
            dog.ProfileImage = dogProfileImage;
            dataDogAccess.updateDog(dog);

            //Re-set the dog profile ImageView
            var bitmapDrawable = new BitmapDrawable(BitmapFactory.DecodeByteArray(dog.ProfileImage, 0, dog.ProfileImage.Length));
            RelativeLayoutDogProfileImage.SetBackgroundDrawable(bitmapDrawable);
        }


        }
}