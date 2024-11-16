using AutoMapper;
using MarsRoverPhotos.Application.DTO;
using MarsRoverPhotos.Application.Services;
using MarsRoverPhotos.Configuration;
using MarsRoverPhotos.Data.Repositories;
using MarsRoverPhotos.Fixture.Domain;
using MarsRoverPhotos.Fixture.DTO;
using Moq;

namespace MarsRoverPhotos.UnitTest.Services;

public class PhotoServiceTest
{
    private readonly Mock<IPhotoRepository> _photoRepository;
    private readonly Mock<IMapper> _mapper;
    private readonly AppConfiguration _configuration;
    private readonly IPhotoService _photoService;

    public PhotoServiceTest()
    {
        _mapper = new Mock<IMapper>();
        _photoRepository = new Mock<IPhotoRepository>();
        _configuration = new AppConfiguration();

        _photoService = new PhotoService(_configuration, _photoRepository.Object, _mapper.Object);
    }

    [Fact]
    public async Task GetAllAsync_Should_ReturnPhotos()
    {
        var photos = PhotoFixture.AutoGenerate(_configuration.PageSize);
        var photosDTO = PhotoDTOResponseFixture.AutoGenerate(_configuration.PageSize);

        _photoRepository
            .Setup(repository => repository.GetAllAsync(It.IsAny<int>(), _configuration.PageSize))
            .ReturnsAsync(photos);

        _photoRepository
            .Setup(repository => repository.GetTotalRecordsAsync())
            .ReturnsAsync(_configuration.PageSize);

        _mapper
            .Setup(mapper => mapper.Map<IEnumerable<PhotoResponse>>(photos))
            .Returns(photosDTO);

        var photoContainer = await _photoService.GetAllAsync(1);

        Assert.NotNull(photoContainer);
        Assert.Equal(_configuration.PageSize, photoContainer.TotalSize);
        Assert.Equal(_configuration.PageSize, photoContainer.PageSize);
        Assert.Equal(2, photoContainer.NextPage);
    }
}
