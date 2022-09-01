using Microsoft.AspNetCore.Mvc;
using RestEase;

namespace FridgeAPI.Interfaces;

[Header("Root-Agent", "RestEase")]
public interface IRootApi
{
    [Get("api")]
    IActionResult GetRoot([Header("Accept")] string mediaType);
}