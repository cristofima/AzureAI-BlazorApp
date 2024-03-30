using Azure;
using Azure.AI.TextAnalytics;
using AzureAIBlazorApp.Options;
using AzureAIBlazorApp.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace AzureAIBlazorApp.Services.Implementations
{
    public class AzureLanguageService : IAzureLanguageService
    {
        private readonly TextAnalyticsClient textAnalyticsClient;

        public AzureLanguageService(IOptions<CognetiveServiceSettings> options)
        {
            var settings = options.Value;

            this.textAnalyticsClient = new TextAnalyticsClient(
                new Uri(settings.Endpoint), 
                new AzureKeyCredential(settings.ApiKey));
        }

        public DocumentSentiment AnalyzeSentiment(string text)
        {
            var response = textAnalyticsClient.AnalyzeSentiment(text);
            return response.Value;
        }

        public KeyPhraseCollection ExtractKeyPhrases(string text)
        {
            var response = textAnalyticsClient.ExtractKeyPhrases(text);
            return response.Value;
        }
    }
}
