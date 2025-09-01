using MooGame.App.Helper;

namespace MooGame.Tests;

//TODO Command, Number, Name validation

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
    
    // [TestMethod]
    // [DataRow("")]
    // [DataRow(null)]
    // public void IsValidChars_InputIsEmptyString_ThrowException(string input)
    // {
    //     Assert.ThrowsException<ArgumentException>(() => UserInputHandler.IsValidChars(input));
    // }
    //
    // [TestMethod]
    // public void IsValidChars_NotValidChar_ThrowException()
    // {
    //     Assert.ThrowsException<ArgumentException>(() => UserInputHandler.IsValidChars("你"));
    // }
}