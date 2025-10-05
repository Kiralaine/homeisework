using FileMongo.App.Interfaces;
using FileMongo.Domain;
using Microsoft.AspNetCore.Mvc;

namespace FileMongo.Endpoints;

[Route("api/files")]
[ApiController]
public class BoookEndpoint
{
    private readonly IMongoFile _mongoFile;

    [HttpPost]
    public async Task<long> AddFile(File file)
    {
        await _mongoFile.AddFile(file);
        return file.Id;
    }

    [HttpGet]
    public async Task<List<File>> GetFiles()
    {
        return await _mongoFile.GetFiles();
    }

    [HttpGet("{id}")]
    public async Task<File> GetFile(long id)
    {
        return await _mongoFile.GetFile(id);
    }

    [HttpDelete("{id}")]
    public async Task DeleteFile(long id)
    {
        var file = await _mongoFile.GetFile(id);
        await _mongoFile.DeleteFile(file);
    }
}