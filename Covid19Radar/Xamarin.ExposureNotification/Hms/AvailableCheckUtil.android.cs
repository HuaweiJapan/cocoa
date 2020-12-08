
using Android.Gms.Common;
using Com.Huawei.Hms.Api;
using Android.App;
using ConnectionResult = Android.Gms.Common.ConnectionResult;

namespace Xamarin.ExposureNotifications
{

	public static class AvailableCheckUtil
	{
		public static bool IsGms()
		{
			int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(Application.Context);
			return resultCode == ConnectionResult.Success;
		}

		public static bool IsHms()
		{
			int resultCode = HuaweiApiAvailability.Instance.IsHuaweiMobileServicesAvailable(Application.Context);
			return resultCode == Com.Huawei.Hms.Api.ConnectionResult.Success;
		}
	}
}
