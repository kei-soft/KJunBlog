namespace Maui.ZxingBarcodeTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BarcodeReader_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
        {
            Dispatcher.Dispatch(() =>
            {
                this.barcodeResult.Text = $"{e.Results[0].Value}{Environment.NewLine}[{e.Results[0].Format}]";

                //this.generateBarcode.Format = e.Results[0].Format; // Error 발생
                this.generateBarcode.Value = e.Results[0].Value;
            });
        }

        private void touchOnSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            this.barcodeReader.IsTorchOn = this.touchOnSwitch.IsToggled;
        }

        private void cameraSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (this.cameraSwitch.IsToggled)
            {
                this.barcodeReader.CameraLocation = ZXing.Net.Maui.CameraLocation.Front;
            }
            else
            {
                this.barcodeReader.CameraLocation = ZXing.Net.Maui.CameraLocation.Rear;
            }
        }
    }
}