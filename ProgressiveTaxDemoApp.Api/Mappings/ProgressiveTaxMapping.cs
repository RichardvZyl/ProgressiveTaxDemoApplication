using AutoMapper;
using ProgressiveTaxDemoApp.Domain;
using ProgressiveTaxDemoApp.Models;

namespace ProgressiveTaxDemoApp.Api;

public class ProgressiveTaxMapping : Profile
{
    public ProgressiveTaxMapping() => CreateMap<ProgressiveTax, ProgressiveTaxModel>();
}
