using System;

namespace Maui.MapHandlerTest.Handlers
{
	public partial class MapHandler : ViewHandler<MapView, Android.Gms.Maps.MapView>
	{
		private MapHelper _mapHelper;

		internal static Bundle Bundle { get; set; }

		public MapHandler(IPropertyMapper mapper, CommandMapper commandMapper = null) : base(mapper, commandMapper)
		{ }

		protected override Android.Gms.Maps.MapView CreatePlatformView()
		{
			return new Android.Gms.Maps.MapView(Context);
		}

		protected override void ConnectHandler(Android.Gms.Maps.MapView platformView)
		{
			base.ConnectHandler(platformView);

			_mapHelper = new MapHelper(Bundle, platformView);
			_mapHelper.MapIsReady += _mapHelper_MapIsReady;
			_mapHelper.CallCreateMap();
		}

		private void _mapHelper_MapIsReady(object sender, EventArgs e)
		{
			_mapHelper.Map.UiSettings.ZoomControlsEnabled = true;
			_mapHelper.Map.UiSettings.CompassEnabled = true;
		}
	}

	class MapHelper : Java.Lang.Object, IOnMapReadyCallback
	{
		private Bundle _bundle;
		private Android.Gms.Maps.MapView _mapView;

		public event EventHandler MapIsReady;

		public GoogleMap Map { get; set; }

		public MapHelper(Bundle bundle, Android.Gms.Maps.MapView mapView)
		{
			_bundle = bundle;
			_mapView = mapView;
		}

		public void CallCreateMap()
		{
			_mapView.OnCreate(_bundle);
			_mapView.OnResume();
			_mapView.GetMapAsync(this);
		}

		public void OnMapReady(GoogleMap googleMap)
		{
			Map = googleMap;
			MapIsReady?.Invoke(this, EventArgs.Empty);
		}
	}
}
