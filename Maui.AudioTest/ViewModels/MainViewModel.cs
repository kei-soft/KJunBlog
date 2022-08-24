using System.ComponentModel;
using System.Runtime.CompilerServices;

using Plugin.Maui.Audio;

namespace Maui.AudioTest.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Fields
        private IAudioManager audioManager;
        private IAudioPlayer audioPlayer;

        private bool isLoadComplete = false;
        public bool IsLoadComplete
        {
            get
            {
                return this.isLoadComplete;
            }
            set
            {
                this.isLoadComplete = value;
                NotifyPropertyChanged();
            }
        }


        private string status = "Wait";
        public string Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
                NotifyPropertyChanged();
            }
        }

        public Command PlayCommand { get; set; }
        public Command PauseCommand { get; set; }
        public Command StopCommand { get; set; }

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        // Constructor
        #region MainViewModel
        public MainViewModel()
        {
            this.audioManager = new AudioManager();

            SetMusic();

            PlayCommand = new Command(OnPlayCommand);
            PauseCommand = new Command(OnPauseCommand);
            StopCommand = new Command(OnStopCommand);
        }
        #endregion

        #region SetMusic
        /// <summary>
        /// Play 될 음악 파일을 설정합니다.
        /// </summary>
        private async void SetMusic()
        {
            audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("motive.mp3"));

            if (audioPlayer != null)
            {
                IsLoadComplete = true;
            }
        }
        #endregion

        #region OnPlayCommand
        void OnPlayCommand()
        {
            audioPlayer.Play();
            Status = "Play";
        }
        #endregion
        #region OnPauseCommand
        void OnPauseCommand()
        {
            if (audioPlayer.IsPlaying)
            {
                audioPlayer.Pause();
                Status = "Pause";
            }
            else
            {
                audioPlayer.Play();
                Status = "Play";
            }
        }
        #endregion
        #region OnStopCommand
        void OnStopCommand()
        {
            if (audioPlayer.IsPlaying)
            {
                audioPlayer.Stop();
                Status = "Stop";
            }
        }
        #endregion
    }
}
