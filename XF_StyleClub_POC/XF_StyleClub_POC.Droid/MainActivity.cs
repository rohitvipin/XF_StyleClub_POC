using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using FFImageLoading.Forms.Droid;
using ImageCircle.Forms.Plugin.Droid;
using Octane.Xam.VideoPlayer.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace XF_StyleClub_POC.Droid
{
    [Activity(Label = "XF_StyleClub_POC", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar; 
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            Xamarin.Forms.Forms.Init(this, bundle);
            FormsVideoPlayer.Init();
            CachedImageRenderer.Init();
            ImageCircleRenderer.Init();
            UserDialogs.Init(this);
            LoadApplication(new App());
        }
    }
}

