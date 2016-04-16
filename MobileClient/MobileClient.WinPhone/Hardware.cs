using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System.Profile;

namespace MobileClient.WinPhone
{
    public class Hardware : IHardware
    {
        string m_DeviceUniqueId = null;
        public string DeviceId()
        {
            if (m_DeviceUniqueId == null)
            {
                var token= HardwareIdentification.GetPackageSpecificToken(null);
                var dataReader = Windows.Storage.Streams.DataReader.FromBuffer(token.Id);

                byte[] bytes = new byte[token.Id.Length];
                dataReader.ReadBytes(bytes);
                m_DeviceUniqueId = BitConverter.ToString(bytes).Replace("-", "");
            }
            return m_DeviceUniqueId;
        }
    }
}
