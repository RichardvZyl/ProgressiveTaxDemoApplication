using AutoMapper;
using ProgressiveTaxDemoApp.Domain;
using ProgressiveTaxDemoApp.Framework;
using ProgressiveTaxDemoApp.Models;

namespace ProgressiveTaxDemoApp.Web;

public class UserMapping : Profile
{
    public UserMapping() 
        => CreateMap<User, UserModel>()
            .ForMember(user => user.BrutoSalary, userModel => userModel.MapFrom(x => x.Salary))
            .AfterMap<UserService.AddTaxToUserModel>();
}
