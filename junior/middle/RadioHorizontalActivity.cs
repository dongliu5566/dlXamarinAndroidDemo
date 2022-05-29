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
using Java.Interop;
using static Android.Widget.RadioGroup;
//using static Android.Widget.CompoundButton;

namespace middle 
{
    [Activity(Label = "RadioHorizontalActivity")]
    public class RadioHorizontalActivity : Activity, IOnCheckedChangeListener
    {
        private TextView tv_sex; // 声明一个文本视图对象
     

        public void OnCheckedChanged(RadioGroup group, int checkedId)
        {
            if (checkedId == Resource.Id.rb_male)
            {
                tv_sex.Text="哇哦，你是个帅气的男孩";
            }
            else if (checkedId == Resource.Id.rb_female)
            {
                tv_sex.Text="哇哦，你是个漂亮的女孩";
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_radio_horizontal);
            // 从布局文件中获取名叫tv_sex的文本视图
            tv_sex = FindViewById<TextView>(Resource.Id.tv_sex);
            // 从布局文件中获取名叫rg_sex的单选组
            RadioGroup rg_sex = FindViewById<RadioGroup>(Resource.Id.rg_sex);
            // 给rg_sex设置单选监听器，一旦用户点击组内的单选按钮，就触发监听器的onCheckedChanged方法
            rg_sex.SetOnCheckedChangeListener(this);
            // 给rg_sex设置单选监听器，一旦用户点击组内的单选按钮，就触发监听器的onCheckedChanged方法
            //rg_sex.setOnCheckedChangeListener(new RadioListener());
            // Create your application here
        }

        // 定义一个单选监听器，它实现了接口RadioGroup.OnCheckedChangeListener
        //class RadioListener :  IOnCheckedChangeListener, IJavaObject, IDisposable
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

        //    // 在用户点击组内的单选按钮时触发


        //    public void OnCheckedChanged(CompoundButton buttonView, bool isChecked)
        //    {
        //        // throw new NotImplementedException();
        //        //   Toast.makeText(RadioHorizontalActivity.this, "您选中了控件" + checkedId, Toast.LENGTH_LONG).show();
        //    }

        //    public void OnCheckedChanged(RadioGroup group, int checkedId)
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