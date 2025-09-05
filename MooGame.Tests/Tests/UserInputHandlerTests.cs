using MooGame.App.Helper;

namespace MooGame.Tests.Tests;

[TestClass]
[TestCategory("UserInputHandlerTests")]
public class UserInputHandlerTests
{
    
    [TestMethod]
    [DataRow(new[] {"12345678901234567890123456: error state", "valid state"})]
    public void GetInput_InputIsTooLong_AssertErrorStateAndRetry(string[] dataRow)
    {
        var mockIo = new MockIO(new Queue<string>(dataRow));

        var inputHandler = new UserInputHandler(mockIo);

        var validOutput = inputHandler.GetInput();
        
        Assert.AreEqual("Input length larger than 25 characters.", mockIo.Outputs[0]);
        Assert.AreEqual("valid state", validOutput);
    }
}