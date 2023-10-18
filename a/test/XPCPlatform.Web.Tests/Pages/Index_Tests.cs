using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace XPCPlatform.Pages;

public class Index_Tests : XPCPlatformWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
