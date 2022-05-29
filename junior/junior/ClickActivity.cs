using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Java.Interop;
using static Android.Views.View;
using Android.Views;
//using static Android.App.Usage.UsageEvents;

namespace junior
{
    [Activity(Label = "ClickActivity")]
    public class ClickActivity : Activity, View.IOnClickListener, View.IOnLongClickListener
    {
        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_click)
            { // 判断是否为btn_click被点击
                Toast.MakeText(Android.App.Application.Context, "您点击了控件：" + ((TextView)v).Text, ToastLength.Long).Show();
                //  Toast.SetText( "您点击了控件：" + ((TextView)v).Text);
            }
        }

        public bool OnLongClick(View v)
        {
            //  throw new NotImplementedException();
            if (v.Id == Resource.Id.btn_click)
            { // 判断是否为btn_click被长按
              // Toast.MakeText(this, "您长按了控件：" + ((TextView)v).Text, Toast.LENGTH_SHORT).show();
                Toast.MakeText(Android.App.Application.Context, "您长按了控件：" + ((TextView)v).Text, ToastLength.Short).Show();

            }
            return true;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_click);
            // Create your application here

            // 从布局文件中获取名叫btn_click的按钮控件
            Button btn_click = FindViewById<Button>(Resource.Id.btn_click);
            // 给btn_click设置点击监听器，一旦用户点击按钮，就触发监听器的onClick方法
            //  btn_click.SetOnClickListener(this);
            btn_click.SetOnClickListener(new MyOnClickListener());
            // 给btn_click设置长按监听器，一旦用户长按按钮，就触发监听器的onLongClick方法
            btn_click.SetOnLongClickListener(this);
            //第一种button.Click += delegate { button.Text = string.Format ("{0} clicks!", count++);};
            //第二种    button.Click +=button_Click;
            //第三种   button.Click += new EventHandler(button_Click);
            //第四种  button.Click += (sender, e) =>{ button.Text = string.Format ("{0} clicks!", count++);};
        }
        public class MyOnClickListener : Java.Lang.Object, IOnClickListener
        {
            // Java.Lang.Object   比较重要
            public void OnClick(View v)
            {
                if (v.Id == Resource.Id.btn_click)
                { // 判断是否为btn_click被点击
                  //  Toast.makeText(ClickActivity.this, "您长按了控件：" + ((TextView) v).getText(), Toast.LENGTH_SHORT).show();
                  //  Toast.MakeText(Android.App.Application.Context, "您点击了控件：" + ((TextView)v).Text, ToastLength.Long).Show();
                    Toast.MakeText(Android.App.Application.Context, "您点击了控件：" + ((TextView)v).Text, ToastLength.Long).Show();
                    //  Toast.SetText( "您点击了控件：" + ((TextView)v).Text);
                }
            }
        }

        // public class MyOnClickListener : View.IOnClickListener
        //  {
        //      public IntPtr Handle => throw new NotImplementedException();

        //      public int JniIdentityHashCode => throw new NotImplementedException();

        //      public JniObjectReference PeerReference => throw new NotImplementedException();

        //      public JniPeerMembers JniPeerMembers => throw new NotImplementedException();

        //      public JniManagedPeerStates JniManagedPeerState => throw new NotImplementedException();

        //      public void Dispose()
        //      {
        //          throw new NotImplementedException();
        //      }

        //      public void Disposed()
        //      {
        //          throw new NotImplementedException();
        //      }

        //      public void DisposeUnlessReferenced()
        //      {
        //          throw new NotImplementedException();
        //      }

        //      public void Finalized()
        //      {
        //          throw new NotImplementedException();
        //      }



        //      public void OnClick(View v)
        //      {
        //          if (v.Id == Resource.Id.btn_click)
        //          { // 判断是否为btn_click被点击
        //              Toast.MakeText(Android.App.Application.Context, "您点击了控件：" + ((TextView)v).Text, ToastLength.Short).Show();
        //            //  Toast.SetText( "您点击了控件：" + ((TextView)v).Text);
        //          }
        //      }

        //      public void SetJniIdentityHashCode(int value)
        //      {
        //          throw new NotImplementedException();
        //      }

        //      public void SetJniManagedPeerState(JniManagedPeerStates value)
        //      {
        //          throw new NotImplementedException();
        //      }

        //      public void SetPeerReference(JniObjectReference reference)
        //      {
        //          throw new NotImplementedException();
        //      }

        //      public void UnregisterFromRuntime()
        //      {
        //          throw new NotImplementedException();
        //      }
        //  }


        //  // 定义一个长按监听器，它实现了接口View.OnLongClickListener

    }
}