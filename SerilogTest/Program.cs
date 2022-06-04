using Serilog;
using Serilog.Core;

namespace SerilogTest;

class Program
{
    static void Main(string[] args)
    {
        var levelSwitch = new LoggingLevelSwitch();

        Log.Logger = new LoggerConfiguration()
                    // 최소 지정 로그 레벨 : Info 레벨 이상 로그를 기록한다는 의미
                    .MinimumLevel.Information()
                    // 콘솔에도 내용을 남김
                    .WriteTo.Console()
                    //파일로 기록할 로그 파일명을 입력
                    .WriteTo.File(@"c:\log\log.txt", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
                    // Seq 에 로그 정보 입력
                    .WriteTo.Seq("http://localhost:5341", controlLevelSwitch: levelSwitch)
                    .CreateLogger();

        for (int idx = 0; idx < 100; idx++)
        {
            Log.Information($"{idx} - Serilog Test");
        }

        Log.CloseAndFlush();
    }
}
