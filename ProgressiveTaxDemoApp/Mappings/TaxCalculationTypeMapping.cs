using AutoMapper;
using ProgressiveTaxDemoApp.Domain;
using ProgressiveTaxDemoApp.Models;

namespace ProgressiveTaxDemoApp.Web.Mappings;

public class TaxCalculationTypeMapping : Profile
{
    public TaxCalculationTypeMapping() => CreateMap<TaxCalculationTypeModel, TaxCalculationType>().ReverseMap();
}
