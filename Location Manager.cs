using System;
using CoreLocation;

namespace FindMyCar.iOS
{
	public class LocationManager
	{

		public CLLocationManager locMgr { get; set; }

		public event EventHandler<LocationUpdatedEventArgs> LocationUpdated = delegate { };

		public void StartLocationUpdates()
		{
			
		}




		//public LocationManager()
		//{
		//	this.locMgr = new CLLocationManager();
		//	this.locMgr.PausesLocationUpdatesAutomatically = false;

		//	locMgr.AllowsBackgroundLocationUpdates = true;
		//}

		//public CLLocationManager LocMgr
		//{
		//	get { return this.locMgr; }
		//}

		//public void StartLocationUpdates()
		//{
		//	if (CLLocationManager.LocationServicesEnabled)
		//	{
		//		locMgr.RequestAlwaysAuthorization();

		//		//set the desired accuracy, in meters
		//		LocMgr.DesiredAccuracy = 1;

		//		LocMgr.LocationsUpdated += (object sender, CLLocationsUpdatedEventArgs e) =>
		//		{
		// 				// fire our custom Location Updated event
		// 				LocationUpdated(this, new LocationUpdatedEventArgs(e.Locations[e.Locations.Length - 1]));
		//		};

		//		LocMgr.StartUpdatingLocation();

		//		latLong = new CLLocationCoordinate2D(locMgr.Location.Coordinate.Latitude, locMgr.Location.Coordinate.Longitude);
		//	}
		//}

		//public CLLocationCoordinate2D returnLocation()
		//{
		//	return latLong;
		//}

	}
}


