using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NdefLibrary.Ndef;

namespace MobileClient
{
    public class NfcFormsTag
    {
        public NfcFormsTag()
        {

        }

        public NdefMessage NdefMessage;
        public IList TechList;
        public bool IsNdefSupported;
        public bool IsWriteable;
        public bool IsConnected;
        public byte[] Id;
        public int MaxSize;
    }
}
