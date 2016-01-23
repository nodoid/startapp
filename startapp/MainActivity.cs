using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content.PM;

namespace startapp
{
    [Activity(Label = "startapp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);
            var txtView = FindViewById<TextView>(Resource.Id.txtView);

            var installed = AppInstalledOrNot("com.android.calculator2");  
            if (installed)
            {
                txtView.Text = "Application found. Launching.";
                var LaunchIntent = PackageManager.GetLaunchIntentForPackage("com.android.calculator2");
                StartActivity(LaunchIntent);      
            }
            else
            {
                txtView.Text = "Application not found.";
            }
        }

        bool AppInstalledOrNot(string uri)
        {
            var pm = PackageManager;
            var app_installed = false;
            try
            {
                pm.GetPackageInfo(uri, PackageInfoFlags.Activities);
                app_installed = true;
            }
            catch (PackageManager.NameNotFoundException e)
            {
                app_installed = false;
            }
            return app_installed;
        }
    }
}


