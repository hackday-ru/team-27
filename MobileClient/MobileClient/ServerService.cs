using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileClient
{
    class ServerService
    {
        static Queue<Competitor> _buffer=new Queue<Competitor>();

        public static void Initialize()
        {
            Xamarin.Forms.Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Task.Factory.StartNew(async () =>
                {
                    await CheckAndSendData();
                });
                return true;
            });
        }

        private static async Task CheckAndSendData()
        {
            if(_buffer.Count!=0)
            {
                List<Competitor> items = null;
                try {
                    items = _buffer.ToList();
                    _buffer.Clear();

                    for(var iCnt=items.Count-1; iCnt>=0;iCnt--)
                    {
                        await SendResult(items[iCnt]);
                        items.RemoveAt(iCnt);
                    }
                }
                catch
                {
                    if (items != null)
                    {
                        foreach (var item in items)
                            _buffer.Enqueue(item);
                    }
                }
            }
        }

        private static async Task SendResult(Competitor competitor)
        {
            HttpClient client = new HttpClient();            

            var url = "http://test.track-me.pro/Input/Mobile?deviceId=" + GetDeviceId() + "&number=" + competitor.Number + "&ticks=" + competitor.Time.Ticks;
            var item = await client.GetAsync(url);
            
        }

        private static string GetDeviceId()
        {
            return DependencyService.Get<IHardware>().DeviceId();
        }

        public static void EnqueueData(Competitor competitor)
        {
            _buffer.Enqueue(competitor);
            //TODO save to disk
        }
    }
}
