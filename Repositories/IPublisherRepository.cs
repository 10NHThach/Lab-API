using LabAPI.Models.Domain;
using LabAPI.Models.DTO;
using static LabAPI.Models.DTO.PublishersDTO;

namespace LabAPI.Repositories
{
    public interface IPublisherRepository
    {
        List<PublisherDTO> GetAllPublishers();
        PublisherNoIdDTO GetPublisherById(int id);
        AddPublishers AddPublisher(AddPublishers addPublisherRequestDTO);
        PublisherNoIdDTO UpdatePublisherById(int id, PublisherNoIdDTO publisherNoIdDTO);
        Publishers? DeletePublisherById(int id);
    }
}
