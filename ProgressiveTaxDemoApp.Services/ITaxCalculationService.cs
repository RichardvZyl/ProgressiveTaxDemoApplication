namespace ProgressiveTaxDemoApp.Framework;

public interface ITaxCalculationService
{
    Task<decimal> CalculateTax(Guid userId);
}