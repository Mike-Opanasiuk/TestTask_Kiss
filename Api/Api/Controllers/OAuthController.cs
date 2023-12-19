using Api.Services;
using Api.UnitOfWork.Abstract;
using Microsoft.AspNetCore.Mvc;
using static Api.AppConstant;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OAuthController : ControllerBase
{
    private readonly ISha256Service sha256Service;
    private readonly IOAuthService oauthService;
    private readonly IUnitOfWork unitOfWork;

    public OAuthController(ISha256Service sha256Service, IOAuthService oauthService, IUnitOfWork unitOfWork)
    {
        this.sha256Service = sha256Service;
        this.oauthService = oauthService;
        this.unitOfWork = unitOfWork;
    }

    [HttpGet("login")]
    public IActionResult RedirectOnOAuthServer()
    {
        var codeVerifier = Guid.NewGuid().ToString();
        var codeChellange = sha256Service.ComputeHash(codeVerifier);

        HttpContext.Session.SetString(General.PkceSessionKey, codeVerifier);

        var url = oauthService.GenerateOAuthRequestUrl(AppConstant.Url.RedirectUrl, codeChellange);
        return Redirect(url);
    }

    [HttpGet("resolve-code")]
    public async Task<IActionResult> CodeAsync(string code)
    {
        var codeVerifier = HttpContext.Session.GetString(General.PkceSessionKey);

        var tokenResult = await oauthService.ExchangeCodeOnTokenAsync(code, codeVerifier!, AppConstant.Url.RedirectUrl);

        Response.Cookies.Append("access_token", tokenResult.AccessToken);

        var user = await oauthService.GetUserAsync(tokenResult.AccessToken);

        var foundUser = unitOfWork.Users.Get().Where(u => u.Email == user.Email).FirstOrDefault();

        if(foundUser == null)
        {
            await unitOfWork.Users.InsertAsync(new Entities.UserEntity()
            {
                Email = user.Email
            });

            await unitOfWork.SaveChangesAsync();
        }

        return Redirect(AppConstant.Url.ClientUrl);
    }
}
