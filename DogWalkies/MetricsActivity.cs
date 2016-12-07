using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Graphics.Drawables;
using DogWalkies.Interface;
using Android.Content;
using System.Globalization;

namespace DogWalkies
{
    [Activity(Label = "MetricsActivity", Theme = "@android:style/Theme.Material.Light.NoActionBar")]
    public class MetricsActivity : Activity
    {

        private TextView TVDogFirstName;
        private TextView TextViewNotes;
        private TextView TextViewLastWalked;
        private TextView TextViewLastWalkedData;
        private TextView TextViewTotalDistance;
        private TextView TextViewTotalDistanceData;
        private TextView TextViewTotalTime;
        private TextView TextViewTotalTimeData;
        private TextView TextViewReminder;
        private TextView TextViewReminderData;
        private TextView TextViewReminderTime;
        private TextView TextViewReminderTimeData;
        private Button ButtonWeek;
        private Button ButtonMonth;
        private Button ButtonYear;
        private Button ButtonWalkReminderDay;
        private Button ButtonWalkReminderTime;
        private ImageButton ImageButtonEditNotes;
        private TextView _dateDisplayDay;
        private TextView _dateDisplayTime;
        private int hour;
        private int minute;
       
        const int TIME_DIALOG_ID = 0;

        private DogAccessLayer dataDogAccess = DogAccessLayer.getInstance();
        private Dog dog;
        private RelativeLayout RelativeLayoutDogProfileImage;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Metrics);

            //Don't automatically popup the android keyboard when activity starts
            Window.SetSoftInputMode(SoftInput.StateHidden);

            loadViews();
            initializeFontStyle();
            initializeDogProfileImage();
            initializeClickEvents();
        }

        private void loadViews()
        {
            TVDogFirstName = FindViewById<TextView>(Resource.Id.TextViewDogFirstName);
            TextViewNotes = FindViewById<TextView>(Resource.Id.TextViewNotes);
            TextViewLastWalked = FindViewById<TextView>(Resource.Id.TextViewLastWalked);
            TextViewLastWalkedData = FindViewById<TextView>(Resource.Id.TextViewLastWalkedData);
            TextViewTotalDistance = FindViewById<TextView>(Resource.Id.TextViewTotalDistance);
            TextViewTotalDistanceData = FindViewById<TextView>(Resource.Id.TextViewTotalDistanceData);
            TextViewTotalTime = FindViewById<TextView>(Resource.Id.TextViewTotalTime);
            TextViewTotalTimeData = FindViewById<TextView>(Resource.Id.TextViewTotalTimeData);
            TextViewReminder = FindViewById<TextView>(Resource.Id.TextViewReminder);
            TextViewReminderData = FindViewById<TextView>(Resource.Id.TextViewReminderData);
            TextViewReminderTime = FindViewById<TextView>(Resource.Id.TextViewReminderTime);
            TextViewReminderTimeData = FindViewById<TextView>(Resource.Id.TextViewReminderTimeData);
            ButtonWeek = FindViewById<Button>(Resource.Id.ButtonWeek);
            ButtonMonth = FindViewById<Button>(Resource.Id.ButtonMonth);
            ButtonYear = FindViewById<Button>(Resource.Id.ButtonYear);
            ButtonWalkReminderDay = FindViewById<Button>(Resource.Id.ButtonWalkReminderDay);
            ButtonWalkReminderTime = FindViewById<Button>(Resource.Id.ButtonWalkReminderTime);
            ImageButtonEditNotes = FindViewById<ImageButton>(Resource.Id.ImageButtonEditNotes);
            RelativeLayoutDogProfileImage = FindViewById<RelativeLayout>(Resource.Id.RelativeLayoutDogProfileImage);
            _dateDisplayDay = FindViewById<TextView>(Resource.Id.TextViewReminderData);
            _dateDisplayTime = FindViewById<TextView>(Resource.Id.TextViewReminderTimeData);
        }

        private void initializeFontStyle()
        {
            Typeface centuryGothic = Typeface.CreateFromAsset(Assets, "centuryGothic.ttf");

            TVDogFirstName.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            TextViewNotes.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            TextViewLastWalked.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            TextViewLastWalkedData.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            TextViewTotalDistance.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            TextViewTotalDistanceData.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            TextViewTotalTime.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            TextViewTotalTimeData.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            TextViewReminder.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            TextViewReminderData.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            TextViewReminderTime.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            TextViewReminderTimeData.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            ButtonWeek.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            ButtonMonth.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            ButtonYear.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            ButtonWalkReminderDay.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            ButtonWalkReminderTime.SetTypeface(centuryGothic, TypefaceStyle.Normal);

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
            ButtonWalkReminderDay.Click += ButtonWalkReminderDay_Click;
            ButtonWalkReminderTime.Click += (o, e) => ShowDialog(TIME_DIALOG_ID);
            ImageButtonEditNotes.Click += ImageButtonEditNotes_Click;
            ButtonWeek.Click += ButtonWeek_Click;
            ButtonMonth.Click += ButtonMonth_Click;
            ButtonYear.Click += ButtonYear_Click;

            hour = DateTime.Now.Hour;
            minute = DateTime.Now.Minute;
        }

        private void ImageButtonEditNotes_Click(object sender, EventArgs e)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            AlertDialog editNotesDialog = builder.Create();
            editNotesDialog.SetTitle("Edit Notes:");
            editNotesDialog.SetMessage("Sorry! This feature is not quite ready, thank you for your patience.");
            editNotesDialog.Show();
        }

        private void ButtonWeek_Click(object sender, EventArgs e)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            AlertDialog weekDialog = builder.Create();
            weekDialog.SetMessage("Sorry! This feature is not quite ready, thank you for your patience.");
            weekDialog.Show();
        }

        private void ButtonMonth_Click(object sender, EventArgs e)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            AlertDialog monthDialog = builder.Create();
            monthDialog.SetMessage("Sorry! This feature is not quite ready, thank you for your patience.");
            monthDialog.Show();
        }

        private void ButtonYear_Click(object sender, EventArgs e)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            AlertDialog yearDialog = builder.Create();
            yearDialog.SetMessage("Sorry! This feature is not quite ready, thank you for your patience.");
            yearDialog.Show();
        }

        public void ButtonWalkReminderDay_Click(object sender, EventArgs e)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            { 
                _dateDisplayDay.Text = time.ToString("MMMM") + " " + time.Day.ToString() + ", " + time.Year.ToString();
            });
                frag.Show(FragmentManager, DatePickerFragment.TAG);
            
            //updateDatabaseAndSetDogWalkReminder();
        }

        private void TimePickerCallback(object sender, TimePickerDialog.TimeSetEventArgs e)
        {
            hour = e.HourOfDay;
            minute = e.Minute;
            updateDisplay();
        }

        private void updateDisplay()
        {
            TimeSpan timeSpan = new TimeSpan(hour, minute, 0);
            DateTime dateTime = new DateTime(timeSpan.Ticks); // Date part is 01-01-0001
            string formattedTime = dateTime.ToString("h:mm tt", CultureInfo.InvariantCulture);
            _dateDisplayTime.Text = formattedTime;
        }

        protected override Dialog OnCreateDialog(int id)
        {
            if (id == TIME_DIALOG_ID)
                return new TimePickerDialog(this, TimePickerCallback, hour, minute, false);

            return null;
        }

        private void updateDatabaseAndSetDogWalkReminder(string dateOrTime, DateTime time)
        {
            //Grab the Date and Time from EditViews
            if (dateOrTime == "date")
            {
                //grab the Day/Month/Year
            }
            else if (dateOrTime == "time")
            {
                //grab the Hour/Minute
            }

            //Create a new dateTime

            //Update the WalkReminder DateTime in the database to this new value

            //setReminder();
        }

        private void setReminder() {
            dog = dataDogAccess.getDogByID(0);

            DateTime date = dog.WalkReminder;
            TimeSpan span = (date - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));

            long wakeUpAt = (long)span.TotalMilliseconds;

            NotificationPublisher publisher = new NotificationPublisher();

            Intent intent = new Intent(ApplicationContext, publisher.GetType());
            PendingIntent pendingIntent = PendingIntent.GetBroadcast(ApplicationContext, 100, intent, PendingIntentFlags.UpdateCurrent);

            AlarmManager alarm = (AlarmManager)GetSystemService(AlarmService);
            alarm.Set(AlarmType.RtcWakeup, wakeUpAt, pendingIntent);
        }
    }
}