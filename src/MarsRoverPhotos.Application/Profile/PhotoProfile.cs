using AutoMapper;
using MarsRoverPhotos.Application.DTO;
using MarsRoverPhotos.Domain;

public class PhotoProfile : Profile
{
    public PhotoProfile()
    {
        CreateMap<Photo, PhotoResponse>();
    }
}