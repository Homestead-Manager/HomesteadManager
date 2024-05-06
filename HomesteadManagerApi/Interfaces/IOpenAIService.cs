namespace HomesteadManagerApi.Interfaces;

public interface IOpenAIService
{
    public Task<string> CallEndpointAsync(string prompt);
}
