using MooGame.App;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.ExceptionServices;

namespace MooGame.Tests;



[TestClass]
public sealed class AppTest
{
    [TestMethod]
    [TestCategory("Not Implemented")]
    public void TestIfControllerGetsInputs()
    {

        //Arrange

        Queue<string> queue = new Queue<string>();
        queue.Enqueue("lucas");
        queue.Enqueue("42");
        queue.Enqueue("");



        var mockIO = new MockIO(queue);
        var controller = new AppController(mockIO);


        //Act

        controller.Run();

        //Assert

        //Assert.AreEqual();

    }
}

internal class MockIO : IInputOutput
{
    Queue<string> _mockInputs { get; set; }
   
    public MockIO(Queue<string> mockInputs)
    {
        _mockInputs = mockInputs;
    }

    public string ReadInput() => _mockInputs.Count > 0 ? _mockInputs.Dequeue() : string.Empty;

    public void WriteOutput(string output) => Debug.WriteLine(output);
}