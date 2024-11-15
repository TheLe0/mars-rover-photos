using AutoMapper;
using MarsRoverPhotos.Application.DTO;
using MarsRoverPhotos.Configuration;
using MarsRoverPhotos.Data.Repositories;

namespace MarsRoverPhotos.Application.Services;

public class PhotoService : IPhotoService
{ 
    private readonly AppConfiguration _configuration;
    private readonly IPhotoRepository _photoRepository;
    private readonly IMapper _mapper;

    public PhotoService(AppConfiguration configuration, IPhotoRepository photoRepository, IMapper mapper)
    {
        _configuration = configuration;
        _photoRepository = photoRepository;
        _mapper = mapper;
    }

    public async Task<PhotoContainerResponse> GetAllAsync(int pageNumber)
    {
        var photos = await _photoRepository.GetAllAsync(pageNumber, _configuration.PageSize);
        var totalRecords = await _photoRepository.GetTotalRecordsAsync();
        var photosResponse = _mapper.Map<IEnumerable<PhotoResponse>>(photos);

        var photoContainer = new PhotoContainerResponse
        {
            Photos = photosResponse,
            TotalSize = totalRecords,
            NextPage = pageNumber + 1,
            PageSize = _configuration.PageSize
        };

        return photoContainer;
    }
}
