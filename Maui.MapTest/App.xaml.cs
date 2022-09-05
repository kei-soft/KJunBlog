namespace Maui.MapTest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Register Syncfusion license - 주석을 풀어 키 입력
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("부여받은라이센스키");

            MainPage = new MainPage();
        }
    }
}