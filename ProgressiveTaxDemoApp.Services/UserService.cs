using Abstractions.Generics;
using Abstractions.Results;
using AutoMapper;
using ProgressiveTaxDemoApp.Domain;
using ProgressiveTaxDemoApp.Models;
using ProgressiveTaxDemoApplication.DAL;

namespace ProgressiveTaxDemoApp.Framework;

public interface IUserService : IGenericService<User, UserModel, Guid>
{
    Task<IResult<UserModel>> GetByEmailAsync(string email);
}

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly ITaxCalculationService _taxCalculationService;
    private readonly IMapper _autoMapper;

    public UserService
    (
        IUserRepository repository,
        ITaxCalculationService updateService,
        IMapper autoMapper
    )
    {
        _repository = repository;
        _taxCalculationService = updateService;
        _autoMapper = autoMapper;
    }

    public async Task<IResult<Guid>> CreateAsync(UserModel model) // did not have time to implement factory pattern (yet)
        => await Result<Guid>.SuccessAsync(await _repository.CreateAsync(new(model.Email, model.PostalCode, model.BrutoSalary)));

    public async Task<IResult<UserModel>> GetAsync(Guid id)
         => await Result<UserModel>.SuccessAsync(_autoMapper.Map<UserModel>(await _repository.GetByIdAsync(id)));

    public async Task<IResult<IEnumerable<UserModel>>> ListAsync()
        => await Result<IEnumerable<UserModel>>.SuccessAsync(_autoMapper.Map<IEnumerable<UserModel>>(await _repository.ListAsync()));

    public async Task<IResult> UpdateAsync(UserModel model)
    {
        var user = await _repository.GetByIdAsync(model.Id);

        if (user is null)
            return await Result<IEnumerable<TaxCalculationType>>.FailAsync($"Could not find {nameof(User)} with ID {model.Id}", 204);

        user.Update(model.PostalCode, model.BrutoSalary);

        var result = await _repository.UpdateAsync(user)
            ? await Result<IEnumerable<TaxCalculationType>>.SuccessAsync()
            : await Result<IEnumerable<TaxCalculationType>>.FailAsync();

        if (result.Succeeded)
            await _taxCalculationService.CalculateTax(user.Id);

        return result;
    }

    public async Task<IResult> DeleteAsync(Guid id)
        => await _repository.DeleteAsync(id)
            ? await Result.SuccessAsync()
            : await Result.FailAsync();

    public Task<IResult<UserModel>> GetByEmailAsync(string email) => throw new NotImplementedException();

    public class AddTaxToUserModel : IMappingAction<User, UserModel>
    {
        private readonly ITaxCalculationService _taxCalculationService;

        public AddTaxToUserModel(ITaxCalculationService taxCalculationService) => _taxCalculationService = taxCalculationService;

        public async void Process(User source, UserModel destination, ResolutionContext context)
        {
            destination.TaxOnSalary = await _taxCalculationService.CalculateTax(source.Id);
        }
    }
}
