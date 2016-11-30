using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Graphics;

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
        private Button ButtonWeek;
        private Button ButtonMonth;
        private Button ButtonYear;
        private Button ButtonWalkReminder;
        private TextView _dateDisplay;
        private Button _dateSelectButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Metrics);

            //Don't automatically popup the android keyboard when activity starts
            Window.SetSoftInputMode(SoftInput.StateHidden);

            loadViews();
            initializeFontStyle();
            initializeClickEvents();

            /*_dateDisplay = FindViewById<TextView>(Resource.Id.date_display);
            _dateSelectButton = FindViewById<Button>(Resource.Id.date_select_button);
            _dateSelectButton.Click += DateSelect_OnClick;*/
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
            ButtonWeek = FindViewById<Button>(Resource.Id.ButtonWeek);
            ButtonMonth = FindViewById<Button>(Resource.Id.ButtonMonth);
            ButtonYear = FindViewById<Button>(Resource.Id.ButtonYear);
            ButtonWalkReminder = FindViewById<Button>(Resource.Id.ButtonWalkReminder);
        }

        private void initializeClickEvents()
        {
            ButtonWalkReminder.Click += ButtonWalkReminder_Click;
        }

        private void ButtonWalkReminder_Click(object sender, EventArgs e)
        {
            //Create Dialogue
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
            ButtonWeek.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            ButtonMonth.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            ButtonYear.SetTypeface(centuryGothic, TypefaceStyle.Normal);
            ButtonWalkReminder.SetTypeface(centuryGothic, TypefaceStyle.Normal);
        }

        /*public void DateSelect_OnClick(object sender, EventArgs eventArgs)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                _dateDisplay.Text = time.ToLongDateString();
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }*/


    }
}