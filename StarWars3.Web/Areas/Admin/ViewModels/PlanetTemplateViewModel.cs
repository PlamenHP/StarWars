
namespace StarWars3.Web.Areas.Admin.ViewModels
{
    using AutoMapper;
    using Extensions;
    using Infrastructure.Mapping;
    using Models;
    using Services.ServicesDTO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class PlanetTemplateViewModel: IMapFrom<PlanetTemplate>, IMapTo<PlanetTemplate>, IHaveCustomMappings
    {
        public PlanetTemplateViewModel()
        {
            Locations = new HashSet<CellViewModel>();
        }

        public int Id { get; set; }

        public bool IsTaken { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public HttpPostedFileBase ImageFromView { get; set; }

        public string ImageToView { get; set; }

        public virtual ICollection<CellViewModel> Locations { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<PlanetTemplateViewModel, PlanetTemplate>()
                .ForMember(x => x.Image, opt => opt.MapFrom(x => x.ImageFromView.ToByteArrayImage()));

            configuration.CreateMap<PlanetTemplate, PlanetTemplateViewModel>()
            .ForMember(x => x.ImageToView, opt => opt.MapFrom(x => x.Image.ToStringImage()));
        }
    }
}
