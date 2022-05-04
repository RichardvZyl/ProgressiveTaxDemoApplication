using NUnit.Framework;
using ProgressiveTaxDemoApp.Api;

namespace AutoMapper.tests;
public class MappingsTests
{
    [Test]
    public void AutoMapper_MappingTest()
    {
        var mapper = Extensions.MapperSetup.CreateMapper();

        mapper.ConfigurationProvider.AssertConfigurationIsValid();
    }
}
