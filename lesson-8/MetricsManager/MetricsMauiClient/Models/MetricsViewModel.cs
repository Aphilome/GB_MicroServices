using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MetricsMauiClient.Models
{
    public class MetricsViewModel : INotifyPropertyChanged
    {
        private readonly MetricsModel _model;

        public MetricsViewModel(MetricsModel model)
        {
            _model = model;
        }

        public DateTime From
        {
            get => _model.From; 
            set
            {
                _model.From = value;
                OnPropertyChanged();
            }
        }

        public TimeSpan FromTime
        {
            get => _model.From.TimeOfDay;
            set
            {
                _model.From = _model.From.Date.Add(value);
                OnPropertyChanged();
            }
        }

        public DateTime To 
        { 
            get => _model.To;
            set
            {
                _model.To = value;
                OnPropertyChanged();
            }
        }

        public TimeSpan ToTime
        {
            get => _model.To.TimeOfDay;
            set
            {
                _model.To = _model.To.Date.Add(value);
                OnPropertyChanged();
            }
        }

        public MetricsEnum MetricsType { get; set; }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
