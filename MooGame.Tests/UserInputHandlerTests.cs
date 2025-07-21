using MooGame.App;

namespace MooGame.Tests;

//TODO Command, Number, Name validation

[TestClass]
[TestCategory("UserInputHandlerTests")]
public class UserInputHandlerTests
{
    
    [TestMethod]
    [DataRow("12345678912345678912123456")]
    public void IsValidChars_InputIsTooLong_ThrowException(string input)
    {
        
        Assert.ThrowsException<ArgumentException>(() => UserInputHandler.IsValidChars(input));
    }
    
    [TestMethod]
    [DataRow("")]
    [DataRow(null)]
    public void IsValidChars_InputIsEmptyString_ThrowException(string input)
    {
        Assert.ThrowsException<ArgumentException>(() => UserInputHandler.IsValidChars(input));
    }

    [TestMethod]
    public void IsValidChars_NotValidChar_ThrowException()
    {
        Assert.ThrowsException<ArgumentException>(() => UserInputHandler.IsValidChars("你"));
    }
}