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

namespace device
{
    [Activity(Label = "TurnViewActivity")]
    public class TurnViewActivity : Activity
    {
        private TurnView tv_circle; // 声明一个转动视图对象
        private CheckBox ck_control;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
    }
}