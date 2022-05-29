using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using static Java.IO.OutputStream;
using static Java.IO.PushbackInputStream;
namespace test.encrypt.base64
{
    public class BASE64Decoder : CharacterDecoder
    {
        protected override int bytesPerAtom()
        { 
        
             return 0;
           // throw new NotImplementedException();
        }

        protected override int bytesPerLine()
        {
            return 0;
            //throw new NotImplementedException();
        }
    }
}