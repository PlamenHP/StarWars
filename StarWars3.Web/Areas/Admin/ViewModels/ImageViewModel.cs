
namespace StarWars3.Web.Areas.Admin.ViewModels
{
    using AutoMapper;
    using Infrastructure.Mapping;
    using Models;
    using System.ComponentModel.DataAnnotations;
    using Extensions;
    using System.Web;

    public class ImageViewModel: IMapFrom<Image>, IMapTo<Image>, IHaveCustomMappings
    {

        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public HttpPostedFileBase ImageFromView { get; set; }

        public string ImageToView { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<ImageViewModel, Image>()
                .ForMember(x => x.Container, opt => opt.MapFrom(x => x.ImageFromView.ToByteArrayImage()));
            configuration.CreateMap<Image, ImageViewModel>()
            .ForMember(x => x.ImageToView, opt => opt.MapFrom(x => x.Container.ToStringImage()));
        }
    }
}