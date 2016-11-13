﻿using System;
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
    [Activity(Label = "DogWalkies", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button profileButton = FindViewById<Button>(Resource.Id.ButtonProfile);
            profileButton.Click += ProfileButton_Click;

            Button startWalkButton = FindViewById<Button>(Resource.Id.ButtonStartWalk);
            startWalkButton.Click += StartWalkButton_Click;
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

