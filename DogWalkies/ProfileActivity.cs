using Android.App;
using Android.OS;

namespace DogWalkies
{
    [Activity(Label = "ProfileActivity", Theme = "@android:style/Theme.Material.Light.NoActionBar")]
    public class ProfileActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Profile);
        }
    }
}