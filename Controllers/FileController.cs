using System.Diagnostics;
using System.Drawing;
using GaragesStructure.DATA.DTOs.File;
using GaragesStructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace GaragesStructure.Controllers;


public class FileController: Properties.BaseController{
    
    
    private readonly IFileService _fileService;

    public FileController(IFileService fileService) {
        _fileService = fileService;
    }

    [HttpPost]
    public async Task<IActionResult> Upload([FromForm] FileForm fileForm) =>  Ok(await _fileService.Upload(fileForm));
    [HttpPost("multi")]
    public async Task<IActionResult> Upload([FromForm] MultiFileForm filesForm) => Ok(await _fileService.Upload(filesForm));

    [HttpGet]
    public async Task<IActionResult> Test()
    {
        string result = await RunIpConfig();
        return Ok(result);
    }

    private async Task<string> RunIpConfig()
    {
        var processInfo = new ProcessStartInfo("ls")
        {
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using (var process = new Process())
        {
            process.StartInfo = processInfo;
            process.Start();

            string output = await process.StandardOutput.ReadToEndAsync();
            string error = await process.StandardError.ReadToEndAsync();

            process.WaitForExit();

            if (process.ExitCode == 0)
            {
                return output;
            }
            else
            {
                return $"Error: {error}";
            }
        }
    }
}