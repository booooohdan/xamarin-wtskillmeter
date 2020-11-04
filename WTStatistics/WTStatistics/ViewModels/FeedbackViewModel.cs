using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WTStatistics.ViewModels
{
    public class FeedbackViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand RedditCommand { get; }
        public ICommand VKCommand { get; }
        public ICommand GMailCommand { get; }
        public ICommand VersusCommand { get; }
        public ICommand ChartsCommand { get; }
        public ICommand WTQuizCommand { get; }
        public ICommand WoTQuizCommand { get; }

        public FeedbackViewModel()
        {
            RedditCommand = new Command(RedditHandler);
            VKCommand = new Command(VKHandler);
            GMailCommand = new Command(GMailHandler);
            VersusCommand = new Command(VersusHandler);
            ChartsCommand = new Command(ChartsHandler);
            WTQuizCommand = new Command(WTQuizHandler);
            WoTQuizCommand = new Command(WoTQuizHandler);
        }

        private void RedditHandler(object obj)
        {
            Launcher.OpenAsync(new Uri("https://www.reddit.com/r/wave_app/"));
        }

        private void VKHandler(object obj)
        {
            Launcher.OpenAsync(new Uri("https://www.vk.com/wave_app/"));
        }

        private void GMailHandler(object obj)
        {
            Launcher.OpenAsync(new Uri("mailto:waveappfeedback@gmail.com"));
        }

        private void VersusHandler(object obj)
        {
            Launcher.OpenAsync(new Uri("https://play.google.com/store/apps/details?id=com.wave.wtversus"));
        }

        private void ChartsHandler(object obj)
        {
            Launcher.OpenAsync(new Uri("https://play.google.com/store/apps/details?id=com.wtwave.wtinsider"));
        }

        private void WTQuizHandler(object obj)
        {
            Launcher.OpenAsync(new Uri("https://play.google.com/store/apps/details?id=com.wave.wtquiz"));
        }

        private void WoTQuizHandler(object obj)
        {
            Launcher.OpenAsync(new Uri("https://play.google.com/store/apps/details?id=com.wave.wotquiz"));
        }
    }
}
