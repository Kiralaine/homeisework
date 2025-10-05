using FileMongo.Domain;

namespace FileMongo.App.Interfaces;

public interface IMongoFile
{
    Task<List<File>> GetFiles();
    Task<File> GetFile( long id);
    Task<long> AddFile(File file);
    Task DeleteFile(File file);
    
    
}