using BITS.DevOps.Service.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace BITS.DevOps.Service.Tests;

public class UnitTest1
{
    [Fact]
    public void Test_UserController_Get()
    {
        var controller = new UsersController();
        IActionResult result = controller.GetUserEmail("testUserId");
        Assert.True(result is BadRequestResult);
    }
}