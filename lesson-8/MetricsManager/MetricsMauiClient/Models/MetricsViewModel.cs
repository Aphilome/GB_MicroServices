using Metrics.Data.Dto;
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

        private List<AMetricDto<int>> _data;
        public List<AMetricDto<int>> Data
        {
            get => _data?.Take(100)?.ToList();
            set
            {
                _data = value;
                OnPropertyChanged();
            }
        }

        public class Tmp
        {
            public DateTime X { get; set; }
            public int Y { get; set; }
        }

        public List<Tmp> Temp => new List<Tmp>
            {
                new Tmp() { X = DateTime.Now.AddDays(0), Y = 5},
                new Tmp() { X = DateTime.Now.AddDays(1), Y = 10},
                new Tmp() { X = DateTime.Now.AddDays(2), Y = 7},
            };

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
