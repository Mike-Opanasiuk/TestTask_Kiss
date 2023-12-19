using Api.Entities;
using Api.Models;
using Api.Services;
using Api.UnitOfWork.Abstract;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Api.AppConstant;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IImageService imageService;
        private readonly IHttpClientService httpClientService;
        private readonly IOAuthService oAuthService;

        public ImagesController(IUnitOfWork unitOfWork, IImageService imageService, IHttpClientService httpClientService, IOAuthService oAuthService)
        {
            this.unitOfWork = unitOfWork;
            this.imageService = imageService;
            this.httpClientService = httpClientService;
            this.oAuthService = oAuthService;
        }

        [HttpPost("load-image")]
        public async Task LoadImageAsync([FromBody] string imageUrl)
        {
            var localPath = await imageService.LoadImageAsync(imageUrl);

            await unitOfWork.Images.InsertAsync(new ImageEntity()
            {
                LocalUrl = localPath,
                SourceUrl = imageUrl
            });

            await unitOfWork.SaveChangesAsync();
        }

        [HttpGet]
        public ImagesResponseDto GetImages(
            int page,
            int perPage,
            [FromServices] IAppUtils utils,
            [FromServices] IMapper mapper)
        {
            var images = utils.Paginate(
                unitOfWork.Images.Get().OrderByDescending(i => i.CreatedOn),
                perPage == default ? General.DefaultPerPage : perPage,
                page == default ? General.DefaultPage : page,
                out int totalPages);

            return new ImagesResponseDto()
            {
                Images = mapper.Map<IEnumerable<ImageDto>>(images),
                TotalCount = unitOfWork.Images.Get().Count()
            };
        }

        [HttpPost("visit-image")]
        public async Task<IActionResult> VisitImage([FromBody] string imageUrl)
        {
            var token = HttpContext.Request.Headers.Authorization.FirstOrDefault();
            if (token == null) return Unauthorized();

            var user = await oAuthService.GetUserAsync(token);

            var dbUser = unitOfWork.Users
                .Get()
                .Include(u => u.VisitedImages)
                .FirstOrDefault(u => u.Email == user.Email);

            if (dbUser == null)
                return BadRequest("User does not exist");

            var imageToVisit = unitOfWork.Images.Get().Where(i => i.LocalUrl == imageUrl).FirstOrDefault();

            if (imageToVisit == null)
                return BadRequest("Image does not exist");

            if (!dbUser.VisitedImages.Contains(imageToVisit))
            {
                dbUser.VisitedImages.Add(imageToVisit);

                await unitOfWork.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpGet("visited-images")]
        public async Task<IActionResult> GetVisitedImagesAsync (
            int page,
            int perPage,
            [FromServices] IAppUtils utils,
            [FromServices] IMapper mapper)
        {
            var token = HttpContext.Request.Headers.Authorization.FirstOrDefault();
            if (token == null) return Unauthorized();

            var user = await oAuthService.GetUserAsync(token);

            var dbUser = unitOfWork.Users
                .Get()
                .Include(u => u.VisitedImages)
                .FirstOrDefault(u => u.Email == user.Email);

            if (dbUser == null)
                return BadRequest("User does not exist");

            var images = utils.Paginate(
                dbUser.VisitedImages.OrderByDescending(i => i.CreatedOn).AsQueryable(),
                perPage == default ? General.DefaultPerPage : perPage,
                page == default ? General.DefaultPage : page,
                out int totalPages);

            return Ok(new ImagesResponseDto()
            {
                Images = mapper.Map<IEnumerable<ImageDto>>(images),
                TotalCount = dbUser.VisitedImages.Count()
            });
        }
    }
}
