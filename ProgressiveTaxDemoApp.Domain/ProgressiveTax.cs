using Abstractions.Domain;

namespace ProgressiveTaxDemoApp.Domain;

public sealed class ProgressiveTax : Entity<int>
{
    public ProgressiveTax(int rate, int from)
    {
        Rate = rate;
        From = from;
    }

    public int Rate { get; private set; }
    public int From { get; private set; }

    public void Update(int rate, int from)
    {
        this.Rate = rate;
        this.From = from;
        this.LastUpdated = DateTime.UtcNow;
    }
}
