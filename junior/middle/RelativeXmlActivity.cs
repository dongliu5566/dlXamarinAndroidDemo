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

namespace middle 
{
    [Activity(Label = "RelativeXmlActivity")]
    public class RelativeXmlActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // setContentView(R.layout.activity_relative_xml);
            SetContentView(Resource.Layout.activity_relative_xml);
          //  SetContentView(Resource..activity_relative_xml);
            // Create your application here
        }
    }
}