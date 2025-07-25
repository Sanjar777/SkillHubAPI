using SkillHubAPI.Data;
using SkillHubAPI.Models;
using SkillHubAPI.Services.Interfaces;

namespace SkillHubAPI.Services;

public class FileService(SkillHubDbContext context, IWebHostEnvironment env) : IFileService
{
    private readonly SkillHubDbContext _context = context;
    private readonly IWebHostEnvironment _env = env;

    public async Task<string> UploadAsync(IFormFile file, int sessionId)
    {
        var folderPath = Path.Combine(_env.WebRootPath, "uploads");
        Directory.CreateDirectory(folderPath);

        var fileName = $"{Guid.NewGuid()}_{file.FileName}";
        var filePath = Path.Combine(folderPath, fileName);

        using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);

        _context.UploadedFiles.Add(new UploadedFile
        {
            SessionId = sessionId,
            FileName = fileName,
            FilePath = filePath
        });

        await _context.SaveChangesAsync();
        return fileName;
    }
}