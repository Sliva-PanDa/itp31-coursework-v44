using Microsoft.AspNetCore.Mvc;
using PortalNauchnyhPublikatsiy.Application.DTO;
using PortalNauchnyhPublikatsiy.Application.Services;

namespace PortalNauchnyhPublikatsiy.Web.Controllers
{
    public class PublicationsController : Controller
    {
        private readonly IPublicationService _publicationService;

        public PublicationsController(IPublicationService publicationService)
        {
            _publicationService = publicationService;
        }

        // Этот метод будет вызываться, когда пользователь перейдет по адресу /Publications/Index
        public async Task<IActionResult> Index()
        {
            // 1. Обращаемся к сервису за списком всех публикаций (в виде DTO)
            var publications = await _publicationService.GetAllPublicationsAsync();

            return View(publications);
        }
        // GET: Publications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Publications/Create
        [HttpPost]
        [ValidateAntiForgeryToken] // Защита от CSRF-атак
        public async Task<IActionResult> Create(CreatePublicationDto publicationDto)
        {
            if (ModelState.IsValid) // Проверяем, прошли ли данные валидацию
            {
                await _publicationService.CreatePublicationAsync(publicationDto);
                return RedirectToAction(nameof(Index)); 
            }

            return View(publicationDto);
        }
    }
}