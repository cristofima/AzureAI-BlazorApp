using Azure.AI.Vision.ImageAnalysis;

namespace AzureAIBlazorApp.Services.Interfaces
{
    public interface IAzureVisionService
    {
        ImageAnalysisResult AnalizeImage(Stream stream);
    }
}
