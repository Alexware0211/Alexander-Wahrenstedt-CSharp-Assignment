using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Infrastructure.Services;

public class FileService(IFileRepository fileRepository) : IFileService
{
    private readonly IFileRepository _fileRepository = fileRepository;

    public FileResult GetContentFromFile(string path)
    {
        try
        {
            var exists = _fileRepository.FileExists(path);

            if (exists)
            {
                var content = _fileRepository.GetFileContent(path);
                return new FileResult { Success = true, Content = content };
            }

            return new FileResult { Success = true, ErrorMessage = "File Not Found" };

        }
        catch (Exception ex)
        {
            return new FileResult { Success = false, ErrorMessage = ex.Message };
        }
    }

    public FileResult SaveContentToFile(string path, string content)
    {
        try
        {
            var result = _fileRepository.SaveFileContent(path, content);

            if (result)
                return new FileResult { Success = true };

            return new FileResult { Success = false };
        }   
        catch (Exception ex)
        {
            return new FileResult { Success = false, ErrorMessage = ex.Message };
        }
    }
}

