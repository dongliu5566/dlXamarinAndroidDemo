using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Chip;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Interop;
using static Android.Widget.CompoundButton;
//using static Android.Widget.RadioGroup;
//using static Android.Support.Design.Chip.ChipGroup;

namespace middle 
{
    [Activity(Label = "CheckboxActivity")]
    public class CheckboxActivity : Activity, IOnCheckedChangeListener
    {
        //public void OnCheckedChanged(ChipGroup p0, int p1)
        //{
        //    if(p1==0)
        //    {
        //        String desc = String.Format("您{0}了这个CheckBox",  "勾选" );
        //        Log.Info("调试", desc);

        //    }
        
        //}

        public void OnCheckedChanged(RadioGroup group, int checkedId)
        {
            // throw new NotImplementedException();
            String desc = String.Format("您{0}了这个CheckBox", checkedId.ToString());
         //   group.SetText(desc);
            Log.Info("调试", desc);
        }

        public void OnCheckedChanged(CompoundButton buttonView, bool isChecked)
        {
            String desc = String.Format("您{0}了这个CheckBox", isChecked ? "勾选" : "取消勾选");
            buttonView.Text=desc;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_checkbox);
            // 从布局文件中获取名叫ck_system的复选框
            CheckBox ck_system = FindViewById<CheckBox>(Resource.Id.ck_system);
            // 从布局文件中获取名叫ck_custom的复选框
            CheckBox ck_custom = FindViewById<CheckBox>(Resource.Id.ck_custom);
            // 给ck_system设置勾选监听器，一旦用户点击复选框，就触发监听器的onCheckedChanged方法
           ck_system.SetOnCheckedChangeListener(this);
            // 给ck_custom设置勾选监听器，一旦用户点击复选框，就触发监听器的onCheckedChanged方法
           ck_custom.SetOnCheckedChangeListener(this);
            // Create your application here

            // 给ck_system设置勾选监听器，一旦用户点击复选框，就触发监听器的onCheckedChanged方法
            //ck_system.SetOnCheckedChangeListener(new CheckListener());
            //// 给ck_custom设置勾选监听器，一旦用户点击复选框，就触发监听器的onCheckedChanged方法
            //ck_custom.SetOnCheckedChangeListener(new CheckListener());
        }
        //CompoundButton.OnCheckedChangeListener
        //private class CheckListener : CompoundButton.IOnCheckedChangeListener
        //{
        //    public IntPtr Handle => throw new NotImplementedException();

        //    public int JniIdentityHashCode => throw new NotImplementedException();

        //    public JniObjectReference PeerReference => throw new NotImplementedException();

        //    public JniPeerMembers JniPeerMembers => throw new NotImplementedException();

        //    public JniManagedPeerStates JniManagedPeerState => throw new NotImplementedException();

        //    public void Dispose()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void Disposed()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void DisposeUnlessReferenced()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void Finalized()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void OnCheckedChanged(RadioGroup group, int checkedId)
        //    {
        //        String desc = String.Format("您勾选了控件%d，状态为%b", group.Id, checkedId);
        //        //   Toast.MakeText(CheckboxActivity., desc, ToastLength.Short).Show();
        //        Log.Info("标题", desc);
        //       // throw new NotImplementedException();
        //    }

        //    public void OnCheckedChanged(CompoundButton buttonView, bool isChecked)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void SetJniIdentityHashCode(int value)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void SetJniManagedPeerState(JniManagedPeerStates value)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void SetPeerReference(JniObjectReference reference)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void UnregisterFromRuntime()
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
}
}