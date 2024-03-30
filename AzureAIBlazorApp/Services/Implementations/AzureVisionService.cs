using Azure;
using Azure.AI.Vision.ImageAnalysis;
using AzureAIBlazorApp.Options;
using AzureAIBlazorApp.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace AzureAIBlazorApp.Services.Implementations
{
    public class AzureVisionService : IAzureVisionService
    {
        private readonly ImageAnalysisClient imageAnalysisClient;

        public AzureVisionService(IOptions<CognetiveServiceSettings> options)
        {
            var settings = options.Value;

            this.imageAnalysisClient = new ImageAnalysisClient(
                new Uri(settings.Endpoint),
                new AzureKeyCredential(settings.ApiKey));
        }

        public ImageAnalysisResult AnalizeImage(Stream stream)
        {
            return imageAnalysisClient.Analyze(
                BinaryData.FromStream(stream),
                VisualFeatures.Caption |
                VisualFeatures.Tags |
                VisualFeatures.Objects
                );
        }
    }
}
