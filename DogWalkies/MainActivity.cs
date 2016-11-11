using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace DogWalkies
{
    [Activity(Label = "DogWalkies", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        //Switch to: SYNC,sync your master branch (make sure all is up-to-date)
        //Switch to: BRANCH, checkout to your 'develop' branch MAKE YOUR CHANGES HERE
        //Switch to: CHANGES, type in your commit comment > Commit All and Push
        //Switch to: BRANCHES, merge changes from 'develop' branch to your 'master' branch
        //Swtich to: SYNC, ... changes from master to origin

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

        }
    }
}

