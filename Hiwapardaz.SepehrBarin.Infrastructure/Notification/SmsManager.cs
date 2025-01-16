using Hiwapardaz.SepehrBarin.Common.Extensions;

namespace Hiwapardaz.SepehrBarin.Infrastructure.Notification
{
    public interface ISmsManager
    {
        Task Send(string text, string recipient);
    }

    public sealed class SmsManager : ISmsManager
    {
        static string _clientName = "payam-rasan";
        static string _apiKey = "34564-a6bb601e9d6d463f9135f991350ba213";
        static string _sender = "500043580";

        private readonly IHttpClientFactory _clientFactory;
        public SmsManager(IHttpClientFactory httpClientFactory)
        {
            _clientFactory = httpClientFactory;
            _clientFactory.NotNull(nameof(_clientFactory));
        }

        public async Task Send(string text, string recipient)
        {
            var clinet = _clientFactory.CreateClient(_clientName);
            var uri = $"http://api.sms-webservice.com/api/V3/Send?ApiKey={_apiKey}&Text={text}&Sender={_sender}&Recipients={recipient}";
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            await clinet.SendAsync(request);
        }
    }
}
