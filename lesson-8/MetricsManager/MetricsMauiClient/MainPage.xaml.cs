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

        private void SendRequest<T>(string url)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, url);
            try
            {
                var response = _httpClient.SendAsync(httpRequest).Result;
                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                var result = JsonSerializer.DeserializeAsync<T>(responseStream);
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }

        private string GetUrl()
        {

            return "";
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            _viewModel.MetricsType = MetricsEnum.Cpu;
            SendRequest();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            _viewModel.MetricsType = MetricsEnum.DotNet;
            SendRequest();
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            _viewModel.MetricsType = MetricsEnum.Hdd;
            SendRequest();
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            _viewModel.MetricsType = MetricsEnum.Network;
            SendRequest();
        }

        private void Button_Clicked_4(object sender, EventArgs e)
        {
            _viewModel.MetricsType = MetricsEnum.Ram;
            SendRequest();
        }

    }
}