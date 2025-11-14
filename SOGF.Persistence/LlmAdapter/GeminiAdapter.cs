using Google.GenAI;
using Microsoft.Extensions.Configuration;
using SOGF.Domain;
using SOGF.Shared.Result;
using Solution.Application.Contracts.Adapters;

namespace Solution.Persistence.LlmAdapter;

public class GeminiAdapter : ILlMAdapter
{
    private readonly IConfiguration _configuration;

    public GeminiAdapter( IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<Result<string>> Consult(string prompt)
    {
        var key = _configuration["GOOGLE_API_KEY"];
        using var client = new Client(apiKey: key);
        var responseObject = await client.Models.GenerateContentAsync(
            model: "gemini-2.5-flash",
            contents: prompt);
        var response = responseObject.Candidates[0].Content.Parts[0].Text;
        return response  is null or "" ? DomainErrors.AiModelComunicationFailure : response; 
    }
}