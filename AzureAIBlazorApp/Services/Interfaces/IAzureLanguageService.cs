using Azure.AI.TextAnalytics;

namespace AzureAIBlazorApp.Services.Interfaces
{
    public interface IAzureLanguageService
    {
        DocumentSentiment AnalyzeSentiment(string text);
        KeyPhraseCollection ExtractKeyPhrases(string text);
    }
}
