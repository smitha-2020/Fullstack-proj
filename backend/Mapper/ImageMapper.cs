using backend.src.DTOs;
using backend.src.DTOs.DTOResponse;
using backend.src.Models;

namespace backend.Mapper;

public class ImageMapper : BaseMapper
{
    public ImageMapper()
    {
      CreateMap<DTOImage,Image>();
      CreateMap<Image,DTOImageResponse>();
      CreateMap<Image,DTOImage>();
      CreateMap<DTOUpdateImage,Image>();
    }
}