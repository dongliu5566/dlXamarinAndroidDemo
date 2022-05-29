using Android.App;
using Android.Content;
using Android.OS;
//using Android.Support.V7.App;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using static Android.Views.View;

namespace middle
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity, IOnClickListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            FindViewById(Resource.Id.btn_relative_xml).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_relative_code).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_frame).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_checkbox).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_switch_default).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_switch_ios).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_radio_horizontal).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_radio_vertical).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_spinner_dropdown).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_spinner_dialog).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_spinner_dialog).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_spinner_icon).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_edit_simple).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_edit_cursor).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_edit_border).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_edit_hide).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_edit_jump).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_edit_auto).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_act_jump).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_act_rotate).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_act_home).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_act_uri).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_act_request).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_text_check).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_mortgage).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_alert).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_login).SetOnClickListener(this);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_relative_xml)
            {
                // Intent intent =new Intent(this,RelativeXmlActivity.class);
                Intent intent = new Intent(this, typeof(RelativeXmlActivity));

                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_relative_code)
            {
                Intent intent = new Intent(this, typeof(RelativeCodeActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_frame)
            {
                Intent intent = new Intent(this, typeof(FrameActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_checkbox)
            {
                Intent intent = new Intent(this, typeof(CheckboxActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_switch_default)
            {
                Intent intent = new Intent(this, typeof(SwitchDefaultActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_switch_ios)
            {
                Intent intent = new Intent(this, typeof(SwitchIOSActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_radio_horizontal)
            {
                Intent intent = new Intent(this, typeof(RadioHorizontalActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_radio_vertical)
            {
                Intent intent = new Intent(this, typeof(RadioVerticalActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_spinner_dropdown)
            {
                Intent intent = new Intent(this, typeof(SpinnerDropdownActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_spinner_dialog)
            {
                Intent intent = new Intent(this, typeof(SpinnerDialogActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_spinner_icon)
            {
                Intent intent = new Intent(this, typeof(SpinnerIconActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_edit_simple)
            {
                Intent intent = new Intent(this, typeof(EditSimpleActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_edit_cursor)
            {
                Intent intent = new Intent(this, typeof(EditCursorActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_edit_border)
            {
                Intent intent = new Intent(this, typeof(EditBorderActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_edit_hide)
            {
                Intent intent = new Intent(this, typeof(EditHideActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_edit_jump)
            {
                Intent intent = new Intent(this, typeof(EditJumpActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_edit_auto)
            {
                Intent intent = new Intent(this, typeof(EditAutoActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_act_jump)
            {
                Intent intent = new Intent(this, typeof(ActJumpActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_act_rotate)
            {
                Intent intent = new Intent(this, typeof(ActRotateActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_act_home)
            {
                Intent intent = new Intent(this, typeof(ActHomeActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_act_uri)
            {
                Intent intent = new Intent(this, typeof(ActUriActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_act_request)
            {
                Intent intent = new Intent(this, typeof(ActRequestActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_text_check)
            {
                Intent intent = new Intent(this, typeof(TextCheckActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_mortgage)
            {
                Intent intent = new Intent(this, typeof(MortgageActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_alert)
            {
                Intent intent = new Intent(this, typeof(AlertActivity));
                StartActivity(intent);
            }
            else if (v.Id == Resource.Id.btn_login)
            {
                Intent intent = new Intent(this, typeof(LoginMainActivity));
                StartActivity(intent);
            }
        }
    }
}