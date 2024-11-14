using MarsRoverPhotos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverPhotos.Data.Storage;

public interface IPhotoLoader
{
    IEnumerable<Photo> LoadPhotos();
}
