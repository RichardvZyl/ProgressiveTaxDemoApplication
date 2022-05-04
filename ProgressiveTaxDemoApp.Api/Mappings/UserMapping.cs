using AutoMapper;
using ProgressiveTaxDemoApp.Domain;
using ProgressiveTaxDemoApp.Models;
using ProgressiveTaxDemoApp.EndPoints.Extensions;

namespace ProgressiveTaxDemoApp.Api;

public class UserMapping : Profile
{
    public UserMapping()
        => CreateMap<User, UserModel>()
            .ForMember(user => user.BrutoSalary, userModel => userModel.MapFrom(x => x.Salary))
            .AfterMap<AddTaxToUserModel>();
}
