using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DotNetAwsProfileCreds.Models;
using Amazon.S3;
using Amazon.S3.Model;

namespace DotNetAwsProfileCreds.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> logger;
    private readonly IAmazonS3 amazonS3;
    private readonly IConfiguration configuration;

    public HomeController(ILogger<HomeController> logger, IAmazonS3 amazonS3, IConfiguration configuration)
    {
        this.logger = logger;
        this.amazonS3 = amazonS3;
        this.configuration = configuration;
    }

    public async Task<IActionResult> Index()
    {
        var result = await amazonS3.GetObjectAsync(new GetObjectRequest()
        {
            BucketName = configuration.GetValue<string>("Bucket:Documents:bucketName"),
            Key = "examples/disposition-form-2019-20.doc",
        });
        logger.LogInformation($"Result key is {result.Key}");
        ViewData["Filename"] = result.Key;
        return View();
    }
}
