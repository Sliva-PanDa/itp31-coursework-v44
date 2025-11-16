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
        // GET: Publications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Если id не передан, возвращаем ошибку 404
            }

            var publicationDto = await _publicationService.GetPublicationByIdAsync(id.Value);

            if (publicationDto == null)
            {
                return NotFound(); // Если публикация с таким id не найдена, возвращаем 404
            }

            return View(publicationDto);
        }
        // GET: Publications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicationDto = await _publicationService.GetPublicationByIdAsync(id.Value);
            if (publicationDto == null)
            {
                return NotFound();
            }

            // Преобразуем PublicationDto в UpdatePublicationDto для передачи в форму
            var updateDto = new PortalNauchnyhPublikatsiy.Application.DTO.UpdatePublicationDto
            {
                Id = publicationDto.Id,
                Title = publicationDto.Title,
                Type = publicationDto.Type,
                Year = publicationDto.Year,
                // JournalConferenceId нужно будет получить отдельно или добавить в PublicationDto
                // Пока что оставим 0, позже улучшим
                JournalConferenceId = 0,
                DOI = publicationDto.DOI
            };

            return View(updateDto);
        }

        // POST: Publications/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdatePublicationDto publicationDto)
        {
            if (id != publicationDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _publicationService.UpdatePublicationAsync(publicationDto);
                return RedirectToAction(nameof(Index));
            }
            return View(publicationDto);
        }
    }
}