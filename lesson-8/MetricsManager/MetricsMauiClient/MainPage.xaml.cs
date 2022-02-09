using Metrics.Data.Dto;
using Metrics.Data.Requests;
using Metrics.Data.Responses;
using MetricsMauiClient.Models;
using System.Text.Json;

namespace MetricsMauiClient
{
    public partial class MainPage : ContentPage
    {
        private readonly MetricsModel _model;
        private readonly MetricsViewModel _viewModel;
        private readonly HttpClient _httpClient;

        public MainPage()
        {
            InitializeComponent();

            _model = new MetricsModel();
            _model.From = DateTime.Now.AddDays(-1);
            _model.To = DateTime.Now;
            _viewModel = new MetricsViewModel(_model);
            BindingContext = _viewModel;
            _httpClient = new HttpClient();
        }

        private T SendRequest<T>(BaseMetricsRequest request)
            where T : class, new()
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, request.Url);
            try
            {
                var response = _httpClient.SendAsync(httpRequest).Result;
                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                return JsonSerializer.DeserializeAsync<T>(responseStream).Result;
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
            return null;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var resalt = SendRequest<CpuMetricsResponse>(new CpuMetricsRequest
            {
                FromTime = _viewModel.From,
                ToTime = _viewModel.To,
            });
            _viewModel.Data = resalt.Metrics.OfType<AMetricDto<int>>().ToList();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            var resalt = SendRequest<DotNetMetricsResponse>(new DotNetMetricsRequest
            {
                FromTime = _viewModel.From,
                ToTime = _viewModel.To,
            });
            _viewModel.Data = resalt.Metrics.OfType<AMetricDto<int>>().ToList();
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            var resalt = SendRequest<HddMetricsResponse>(new HddMetricsRequest
            {
                FromTime = _viewModel.From,
                ToTime = _viewModel.To,
            });
            _viewModel.Data = resalt.Metrics.OfType<AMetricDto<int>>().ToList();
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            var resalt = SendRequest<NetworkMetricsResponse>(new NetworkMetricsRequest
            {
                FromTime = _viewModel.From,
                ToTime = _viewModel.To,
            });
            _viewModel.Data = resalt.Metrics.OfType<AMetricDto<int>>().ToList();
        }

        private void Button_Clicked_4(object sender, EventArgs e)
        {
            var resalt = SendRequest<RamMetricsResponse>(new RamMetricsRequest
            {
                FromTime = _viewModel.From,
                ToTime = _viewModel.To,
            });
            _viewModel.Data = resalt.Metrics.OfType<AMetricDto<int>>().ToList();
        }
    }
}