using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using RestEase;

namespace FridgeAPI.Interfaces;

[Header("Authentication-Agent", "RestEase")]
public interface IAuthenticationApi
{
    [Post("api/authentication")]
    Task<IActionResult> RegisterUser([Body] UserForRegistrationDto userForRegistration);

    [Post("api/authentication/login")]
    Task<IActionResult> Authenticate([Body] UserForAuthenticationDto user);
}