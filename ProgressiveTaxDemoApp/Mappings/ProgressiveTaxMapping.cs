using AutoMapper;
using ProgressiveTaxDemoApp.Domain;
using ProgressiveTaxDemoApp.Models;

namespace ProgressiveTaxDemoApp.Web;

public class ProgressiveTaxMapping : Profile
{
    public ProgressiveTaxMapping() => CreateMap<ProgressiveTaxModel, ProgressiveTax>().ReverseMap();
}
