using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Services;

namespace WebApplication1.Pages;

public class IndexModel : PageModel
{

    private readonly ILogger<IndexModel> _logger;
    private readonly ISystemTime _systemTime;
    public DateTime WhatTimeIsIt { get; private set; }
    public IndexModel(ILogger<IndexModel> logger, ISystemTime systemTime)
    {
        _logger = logger;
        _systemTime = systemTime;
    }

    public void OnGet()
    {
        WhatTimeIsIt = _systemTime.GetCurrent();
    }
}