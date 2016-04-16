using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace MobileClient.Droid
{
    [Activity(Label = "MobileClient", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        public NfcAdapter NFCdevice;
        public NfcForms x;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            NfcManager NfcManager = (NfcManager)Android.App.Application.Context.GetSystemService(Context.NfcService);
            NFCdevice = NfcManager.DefaultAdapter;

            Xamarin.Forms.DependencyService.Register<INfcForms, NfcForms>();
            x = Xamarin.Forms.DependencyService.Get<INfcForms>() as NfcForms;

            LoadApplication(new App());
        }
    }
}

