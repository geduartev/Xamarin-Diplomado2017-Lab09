using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab09
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView (Resource.Layout.Main);

            ValidateAsync();
        }

        private async void ValidateAsync()
        {
            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            var ServiceClient = new SALLab09.ServiceClient();
            var Result = await ServiceClient.ValidateAsync("email@email.com", "password", myDevice);

            var UserName = FindViewById<TextView>(Resource.Id.UserNameValue);
            var Status = FindViewById<TextView>(Resource.Id.StatusValue);
            var Token = FindViewById<TextView>(Resource.Id.TokenValue);

            UserName.Text = $"{Result.Fullname}";
            Status.Text = $"{Result.Status}";
            Token.Text = $"{Result.Token}";
        }
    }
}

