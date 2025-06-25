using System.Diagnostics;
using MooGame.App;

namespace MooGame.Tests;

//TODO Command, Number, Name validation

[TestClass]
[TestCategory("UserInputHandlerTests")]
public class UserInputHandlerTests
{
    private static HashSet<string> _mockCommands = new (["y", "n", "0", "1"]);
    
    [TestMethod]
    [DataRow("12345678912345678912123456")]
    public void Validate_InputIsTooLong_ThrowException(string input)
    {
        var validator = new UserInputHandler(_mockCommands);
        
        Assert.ThrowsException<ArgumentException>(() => validator.Validate(input));
    }
    
    [TestMethod]
    [DataRow("")]
    public void Validate_InputIsEmptyString_ThrowException(string input)
    {
        var validator = new UserInputHandler(_mockCommands);
        
        Assert.ThrowsException<ArgumentException>(() => validator.Validate(input));
    }

    [TestMethod]
    public void Validate_NotValidCommand_ThrowException()
    {
        var validator = new UserInputHandler(_mockCommands);
        
        Assert.ThrowsException<ArgumentException>(() => validator.Validate(""));
    }
}