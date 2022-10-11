using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

using Microsoft.Win32;

using Path = System.IO.Path;

namespace Wpf.WebView2Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (!CheckWebview2Runtime())
            {
                Task.Run(async () => await InstallWebview2RuntimeAsync()).Wait();
            }

            BindingHtml();
        }

        /// <summary>
        /// WebView2 설치여부를 반환합니다.
        /// </summary>
        /// <returns></returns>
        public static bool CheckWebview2Runtime()
        {
            bool result = false;

            // 64비트 OS 인 경우
            if (Environment.Is64BitOperatingSystem)
            {
                string subKey = @"SOFTWARE\WOW6432Node\Microsoft\EdgeUpdate\Clients\{F3017226-FE2A-4295-8BDF-00C3A9A7E4C5}";
                using (var ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(subKey))
                {
                    // pv 는 버전을 의미합니다.
                    if (ndpKey != null && ndpKey.GetValue("pv") != null)
                    {
                        Debug.WriteLine($"64 bit version : {ndpKey.GetValue("pv")}");
                        result = true;
                    }
                    else
                    {
                        Debug.WriteLine("64 bit not installed");
                        result = false;
                    }
                }
            }
            // 32비트 OS 인 경우
            else
            {
                string subKey = @"SOFTWARE\Microsoft\EdgeUpdate\Clients\{F3017226-FE2A-4295-8BDF-00C3A9A7E4C5}";
                using (var ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(subKey))
                {
                    // pv 는 버전을 의미합니다.
                    if (ndpKey != null && ndpKey.GetValue("pv") != null)
                    {
                        Debug.WriteLine($"32 bit version : {ndpKey.GetValue("pv")}");
                        result = true;
                    }
                    else
                    {
                        Debug.WriteLine("32 bit not installed");
                        result = false;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// WebView2 runtime 을 다운받고 설치 합니다.
        /// </summary>
        /// <returns></returns>
        public static async Task InstallWebview2RuntimeAsync()
        {
            string? exePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string setupfileName = Path.Combine(exePath ?? "", "MicrosoftEdgeWebview2Setup.exe");

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var result = await httpClient.GetAsync("https://go.microsoft.com/fwlink/p/?LinkId=2124703");
                    var message = result.EnsureSuccessStatusCode();

                    // setup 파일 다운로드
                    using (var stream = await result.Content.ReadAsStreamAsync())
                    {
                        using (var fs = new FileStream(setupfileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                        {
                            await stream.CopyToAsync(fs);
                        }
                    }

                    if (File.Exists(setupfileName))
                    {
                        // 설치
                        await Process.Start(setupfileName, " /silent /install").WaitForExitAsync(); // .NET6
                        // Process.Start(appName, " /silent /install").WaitForExit(); // .Net FrameWork

                        // 설치 후 setup 파일 제거
                        //if (File.Exists(appName))
                        //{
                        //    File.Delete(appName);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// WebView2 에 Html Source 를 바인딩합니다.
        /// </summary>
        private async void BindingHtml()
        {
            string html = "<body><h1>Hello World</h1></body>";
            await webView2.EnsureCoreWebView2Async();

            webView2.NavigateToString(html);
        }
    }
}
