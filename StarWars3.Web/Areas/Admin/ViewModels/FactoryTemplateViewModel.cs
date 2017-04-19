using AutoMapper;
using StarWars3.Infrastructure.Mapping;
using StarWars3.Models;
using StarWars3.Web.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarWars3.Web.Areas.Admin.ViewModels
{
    public class FactoryTemplateViewModel: IMapFrom<FactoryTemplate>, IMapTo<FactoryTemplate>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public FactoryType FactoryType { get; set; }

        public HttpPostedFileBase ImageFromView { get; set; }

        public string ImageToView { get; set; }

        public int Health { get; set; }
        public int Shield { get; set; }
        public int Level { get; set; }
        public int? Income { get; set; }

        public int? MetalCost { get; set; }
        public int? GasCost { get; set; }
        public int? MineralsCost { get; set; }
        public int? TimeCost { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<FactoryTemplateViewModel, FactoryTemplate>()
                .ForMember(x => x.Image, opt => opt.MapFrom(x => x.ImageFromView.ToByteArrayImage()));

            configuration.CreateMap<FactoryTemplate, FactoryTemplateViewModel>()
            .ForMember(x => x.ImageToView, opt => opt.MapFrom(x => x.Image.ToStringImage()));
        }
    }
}