using Android.App;
using Android.Content;
using Android.Content.PM;

namespace PicturesPet.Droid
{
    [Activity(Label = "Pictures Pet",
        Icon = "@mipmap/ic_launcher",
        Theme = "@style/Theme.Splash",
        MainLauncher = true,
        NoHistory = true,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreenActivity : Activity
    {
        protected override void OnCreate(Android.OS.Bundle bundle)
        {
            base.OnCreate(bundle);
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
            Finish();
        }
    }
}