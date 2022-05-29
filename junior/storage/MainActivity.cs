using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using static Android.Views.View;
using Android.Views;
using Android.Content;

namespace storage
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IOnClickListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
          

            FindViewById<Button>(Resource.Id.btn_share_write).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_share_read).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_login_share).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_sqlite_create).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_sqlite_write).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_sqlite_read).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_login_sqlite).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_file_basic).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_file_path).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_text_write).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_text_read).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_image_write).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_image_read).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_app_life).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_app_write).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_app_read).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_content_provider).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_content_resolver).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_content_observer).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_menu_option).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_menu_context).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_shopping_cart).SetOnClickListener(this);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_share_write)
            {
                Intent intent = new Intent(this,typeof(ShareWriteActivity));
             StartActivity(intent);
            } 
           else if (v.Id == Resource.Id.btn_share_read) 
            {
            Intent intent = new Intent(this, typeof(ShareReadActivity));
            StartActivity(intent);
           } 
            else if (v.Id == Resource.Id.btn_login_share) 
            {
              Intent intent = new Intent(this, typeof(LoginShareActivity));
              StartActivity(intent);
            } 
            else if (v.Id == Resource.Id.btn_sqlite_create)
            {
            Intent intent = new Intent(this, typeof(DatabaseActivity));
            StartActivity(intent);
           } else if (v.Id == Resource.Id.btn_sqlite_write) 
            {
            Intent intent = new Intent(this, typeof(SQLiteWriteActivity));
            StartActivity(intent);
            } else if (v.Id == Resource.Id.btn_sqlite_read) 
            {
            Intent intent = new Intent(this, typeof(SQLiteReadActivity));
            StartActivity(intent);
           } else if (v.Id == Resource.Id.btn_login_sqlite) 
            {
            Intent intent = new Intent(this, typeof(LoginSQLiteActivity));
            StartActivity(intent);
           } else if (v.Id == Resource.Id.btn_file_basic) {
            Intent intent = new Intent(this, typeof(FileBasicActivity));
            StartActivity(intent);
            } else if (v.Id == Resource.Id.btn_file_path) {
            Intent intent = new Intent(this, typeof(FilePathActivity));
            StartActivity(intent);
           } else if (v.Id == Resource.Id.btn_text_write) {
            Intent intent = new Intent(this, typeof(TextWriteActivity));
            StartActivity(intent);
           } else if (v.Id == Resource.Id.btn_text_read) {
            Intent intent = new Intent(this, typeof(TextReadActivity));
            StartActivity(intent);
           } else if (v.Id == Resource.Id.btn_image_write) {
            Intent intent = new Intent(this, typeof(ImageWriteActivity));
            StartActivity(intent);
           } else if (v.Id == Resource.Id.btn_image_read) {
            Intent intent = new Intent(this, typeof(ImageReadActivity));
            StartActivity(intent);
           } else if (v.Id == Resource.Id.btn_app_life) {
            Intent intent = new Intent(this, typeof(ActJumpActivity));
            StartActivity(intent);
          } else if (v.Id == Resource.Id.btn_app_write) {
            Intent intent = new Intent(this, typeof(AppWriteActivity));
            StartActivity(intent);
          } else if (v.Id == Resource.Id.btn_app_read) {
            Intent intent = new Intent(this, typeof(AppReadActivity));
            StartActivity(intent);
           } else if (v.Id == Resource.Id.btn_content_provider) {
            Intent intent = new Intent(this, typeof(ContentProviderActivity));
            StartActivity(intent);
          } else if (v.Id == Resource.Id.btn_content_resolver) {
            //if (PermissionUtil.checkMultiPermission(this, new String[] {Manifest.permission.READ_CONTACTS, Manifest.permission.WRITE_CONTACTS}, R.id.btn_content_resolver % 65536)) {
            //    startActivity(new Intent(this, ContentResolverActivity.class));
            //}
        } else if (v.Id == Resource.Id.btn_content_observer) {
            //if (PermissionUtil.checkMultiPermission(this, new String[] {Manifest.permission.SEND_SMS, Manifest.permission.READ_SMS}, R.id.btn_content_observer % 65536)) {
            //    startActivity(new Intent(this, ContentObserverActivity.class));
         
        } else if (v.Id == Resource.Id.btn_menu_option) {
            Intent intent = new Intent(this, typeof(MenuOptionActivity));
            StartActivity(intent);
          } else if (v.Id == Resource.Id.btn_menu_context) {
            Intent intent = new Intent(this, typeof(MenuContextActivity));
            StartActivity(intent);
          } else if (v.Id == Resource.Id.btn_shopping_cart) {
            Intent intent = new Intent(this, typeof(ShoppingCartActivity));
            StartActivity(intent);
        }
        }
    }
}