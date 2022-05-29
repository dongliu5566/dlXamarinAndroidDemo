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
using static Android.Views.View;

namespace test
{
    [Activity(Label = "EncryptActivity")]
    public class EncryptActivity : Activity, IOnClickListener
    {
        private readonly static String TAG = "EncryptActivity";
        private EditText et_raw;
        private TextView tv_des;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_encrypt);
            et_raw = FindViewById<EditText>(Resource.Id.et_raw);
            tv_des = FindViewById<TextView>(Resource.Id.tv_des);
            FindViewById(Resource.Id.btn_md5).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_rsa).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_aes).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_3des).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_sm3).SetOnClickListener(this);
            // Create your application here
        }

        public void OnClick(View v)
        {

        }
    }
}