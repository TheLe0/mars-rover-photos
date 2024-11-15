using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MarsRoverPhotos.Web.Models;
using MarsRoverPhotos.Application.Services;

namespace MarsRoverPhotos.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IPhotoService _photoService;

    public HomeController(ILogger<HomeController> logger, IPhotoService photoService)
    {
        _logger = logger;
        _photoService = photoService;
    }

    public async Task<IActionResult> Index(int pageNumber = 1)
    {
        var photoContainer = await _photoService.GetAllAsync(pageNumber);

        ViewBag.TotalPages = (int)Math.Ceiling(photoContainer.TotalSize / (double)photoContainer.PageSize);

        return View(photoContainer.Photos);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}