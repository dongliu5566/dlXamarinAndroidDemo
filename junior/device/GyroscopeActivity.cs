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
    [Activity(Label = "GyroscopeActivity")]
    public class GyroscopeActivity : Activity
    {
        private TextView tv_direction;
      //  private CompassView cv_sourth; // 声明一个罗盘视图对象
      //  private SensorManager mSensorMgr;// 声明一个传感管理器对象
        private float[] mAcceValues; // 加速度变更值的数组
        private float[] mMagnValues; // 磁场强度变更值的数组
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
    }
}