using System.Drawing;
using CoreLocation;
using Google.Maps;
using UIKit;

namespace FindMyCar.iOS
{
	public class MyViewController : UIViewController
	{

		//define variable of type MapView
		MapView mapView;


		public static LocationManager Manager { get; set; }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//Manager.LocationUpdated += HandleLocationChanged;

			//// Perform any additional setup after loading the view, typically from a nib.
			var mojioManager = new MojioAPIManager();

			//load the location for the first time
			mojioManager.MakeGetCall().Wait();
			SetStreetViewLocation(mojioManager.lattitude, mojioManager.longitude);
		}

		public override void LoadView()
		{
			base.LoadView();
		}

		public void SetStreetViewLocation(double lattitude, double longitude)
		{
			//creating a location variable compatible with google maps
			var location = new CLLocationCoordinate2D(lattitude, longitude);

			//setting the view to streetview
			this.View = PanoramaView.FromFrame(RectangleF.Empty, location);
		}

		//public UIWebView InternetView()
		//{

		//	//as soon as the app launches, prompt the user to login
		//	String appId = "062305af-78a8-4e1e-927f-01dc9f0ddf70";
		//	var redirectUri = System.Net.WebUtility.UrlEncode("http://localhost");
		//	var url = "https://accounts.moj.io/OAuth2/authorize?response_type=token&client_id=" + appId + "&redirect_uri=" + redirectUri;

		//	var url = "https://www.google.com";

		//	var webview = new UIWebView();

		//	webview.LoadRequest(new NSUrlRequest(new NSUrl(url)));

		//	webview.ScalesPageToFit = true;

		//	return webview;
		//}

		//public MapView MapsView()
		//{
		//	//mapView = new MapView();

		//	//CLLocationCoordinate2D location = Manager.returnLocation();

		//	////define a camera and indicate our initial extent to which we want to zoom
		//	//CameraPosition camera = CameraPosition.FromCamera(location, 8);

		//	////assign the camera with our mapview variable
		//	//mapView = MapView.FromCamera(RectangleF.Empty, camera);

		//	//return mapView;
		//}

	}
}
