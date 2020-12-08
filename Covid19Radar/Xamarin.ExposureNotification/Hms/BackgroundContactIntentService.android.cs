using System;
using System.Collections.Generic;
using System.Text;
using Android.App;
using Android.Content;
using Android.Nfc;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Huawei.Hms.Contactshield;

namespace Xamarin.ExposureNotifications
{
    [Service(Exported = true, Enabled = true, Name = "com.huawei.nearby.contactshield.BackgroundContactntentService")]
    public class BackgroundContactIntentService : IntentService
    {
        private const string TAG = "ContactShield_BackgroundContackCheckingIntentService";
        private ContactShieldEngine contactShield;

        public BackgroundContactIntentService()
        {

        }

        public override void OnCreate()
        {
            base.OnCreate();
            contactShield = ContactShield.GetContactShieldEngine(this);
        }

       
        protected override void OnHandleIntent(Intent intent)
        {
            if (intent != null)
            {
                contactShield.HandleIntent(intent, new ContactShieldCallBackClass(this,intent));
            }
        }

        class ContactShieldCallBackClass : Java.Lang.Object, IContactShieldCallback
        {
            private Context Context;
            private Intent Intent;
            public ContactShieldCallBackClass(Context context, Intent intent)
            {
                Context = context;
                Intent = intent;

            }

            public void OnHasContact(string p0)
            {
                ExposureNotificationCallbackService.EnqueueWork(Context, Intent);
            }

            public void OnNoContact(string p0)
            {
                Console.WriteLine($"C19R {nameof(BackgroundContactIntentService)} ACTION_EXPOSURE_NOT_FOUND.");
            }
        }
    }
}
