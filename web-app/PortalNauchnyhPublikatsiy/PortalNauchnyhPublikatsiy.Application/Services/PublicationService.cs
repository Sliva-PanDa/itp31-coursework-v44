using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalNauchnyhPublikatsiy.Application.DTO;
using PortalNauchnyhPublikatsiy.Application.Interfaces;

namespace PortalNauchnyhPublikatsiy.Application.Services
{
    public class PublicationService : IPublicationService
    {
        private readonly IPublicationRepository _publicationRepository;

        public PublicationService(IPublicationRepository publicationRepository)
        {
            _publicationRepository = publicationRepository;
        }

        public async Task<PublicationDto?> GetPublicationByIdAsync(int id)
        {
            var publication = await _publicationRepository.GetByIdAsync(id);

            if (publication == null)
            {
                return null;
            }

            // Преобразуем (маппим) доменную модель в DTO
            return new PublicationDto
            {
                Id = publication.Id,
                Title = publication.Title,
                Type = publication.Type,
                Year = publication.Year,
                JournalName = publication.JournalConference?.Name, // Безопасно получаем имя
                DOI = publication.DOI
            };
        }

        public async Task<IEnumerable<PublicationDto>> GetAllPublicationsAsync()
        {
            var publications = await _publicationRepository.GetAllAsync();

            return publications.Select(publication => new PublicationDto
            {
                Id = publication.Id,
                Title = publication.Title,
                Type = publication.Type,
                Year = publication.Year,
                JournalName = publication.JournalConference?.Name,
                DOI = publication.DOI
            });
        }
    }
}