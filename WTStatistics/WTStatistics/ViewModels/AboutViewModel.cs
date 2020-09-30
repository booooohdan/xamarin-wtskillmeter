using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace WTStatistics.ViewModels
{
    [Preserve(AllMembers = true)]
    public class AboutViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public AboutViewModel()
        {

        }

        private string headerText;
        public string HeaderText
        {
            get { return headerText; }
            set
            {
                headerText = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                           new PropertyChangedEventArgs("HeaderText"));
                }
            }
        }

        #region PointerValue

        private double pointerValue;

        public double PointerValue
        {
            get { return pointerValue; }
            set
            {
                pointerValue = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("PointerValue"));
                }
            }
        }

        #endregion PointerValue

        #region NeedlePointerColor

        private Color needlePointerColor;

        public Color NeedlePointerColor
        {
            get { return needlePointerColor; }
            set
            {
                needlePointerColor = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("NeedlePointerColor"));
                }
            }
        }
        #endregion NeedlePointerColor



    }
}