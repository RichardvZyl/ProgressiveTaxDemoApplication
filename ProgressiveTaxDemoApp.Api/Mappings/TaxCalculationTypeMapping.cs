using AutoMapper;
using ProgressiveTaxDemoApp.Domain;
using ProgressiveTaxDemoApp.Models;

namespace ProgressiveTaxDemoApp.Api;

public class TaxCalculationTypeMapping : Profile
{
    public TaxCalculationTypeMapping() => CreateMap<TaxCalculationType, TaxCalculationTypeModel>();
}
