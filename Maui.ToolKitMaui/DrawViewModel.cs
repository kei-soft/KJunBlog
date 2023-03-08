using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace Maui.ToolKitMaui
{
    public partial class DrawViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        ObservableCollection<IDrawingLine> drawingLines = null;
        /// <summary>
        /// 그려진 선들
        /// </summary>
        public ObservableCollection<IDrawingLine> DrawingLines
        {
            get
            {
                if (drawingLines == null)
                {
                    drawingLines = new ObservableCollection<IDrawingLine>();
                }
                return this.drawingLines;
            }
            set
            {
                this.drawingLines = value;
                OnPropertyChanged();
            }
        }

        ImageSource resultImage = null;
        /// <summary>
        /// 결과 이미지
        /// </summary>
        public ImageSource ResultImage
        {
            get
            {
                return this.resultImage;
            }
            set
            {
                this.resultImage = value;
                OnPropertyChanged();
            }
        }

        public ICommand DrawingLineCompletedCommand => new Command<IDrawingLine>((line) => OnDrawingLineCompletedCommand(line));

        /// <summary>
        /// 선긋기 완료시 이벤트
        /// </summary>
        /// <param name="line"></param>
        private async void OnDrawingLineCompletedCommand(IDrawingLine line)
        {
            await Snackbar.Make("Animation Command").Show();

            // 300 * 300 이미지로 처리
            var stream = await line.GetImageStream(300, 300, Colors.Gray.AsPaint());
            ResultImage = ImageSource.FromStream(() => stream);
        }

        public ICommand ClearCommand => new Command(() => OnClearCommand());

        /// <summary>
        /// 모두 지우기
        /// </summary>
        private void OnClearCommand()
        {
            DrawingLines.Clear();
        }
    }
}