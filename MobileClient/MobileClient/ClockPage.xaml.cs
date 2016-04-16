using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using NdefLibrary.Ndef;
using Xamarin.Forms;

namespace MobileClient
{
    public partial class ClockPage : ContentPage
    {
        public ClockPage()
        {
            InitializeComponent();

            Xamarin.Forms.Device.StartTimer(TimeSpan.FromMilliseconds(50), UpdateTime);

            INfcForms device = DependencyService.Get<INfcForms>();
            device.NewTag += HandleNewTag;
        }

        private void HandleNewTag(object sender, NfcFormsTag e)
        {
            var time = DateTime.Now;
            foreach (var record in e.NdefMessage)
            {
                if (record.CheckSpecializedType(false) == typeof(NdefTextRecord))
                {
                    var textRecord = new NdefTextRecord(record);
                    var item = ParseRecord(textRecord.Text);

                    if (item != null)
                    {
                        item.Time = time;
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            UserDialogs.Instance.Alert(item.ToString(), "test", "test");
                        });
                    }
                }
            }
        }

        private Competitor ParseRecord(string text)
        {
            try
            {
                var tokens = text.Split('-');
                return new Competitor(tokens);
            }
            catch
            {
                return null;
            }
        }

        private bool UpdateTime()
        {
            this.lblTime.Text = DateTime.Now.ToString("HH:mm:ss.f");

            return true;
        }
    }
}
