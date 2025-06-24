using MooGame.App;

namespace MooGame.Tests;

[TestCategory("Not Implemented")]
[TestClass]
public sealed class AppControllerTest
{
    [TestMethod]
    public void TestIfRunIsExecutable()
    {

        //Arrange

        var controller = new AppController();

        //Act

        controller.Run();

        //Assert

        Assert.IsFalse();
    }
}
