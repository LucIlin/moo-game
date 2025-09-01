// using MooGame.App;
// using MooGame.Tests.Mocks;
//
// namespace MooGame.Tests;
//
//
//
// [TestClass]
// public sealed class AppControllerTests
// {
//     [TestMethod]
//     [TestCategory("Integration")]
//     public void Test_InputPrompts_AreDisplayedCorrectly()
//     {
//         var inputs = new Queue<string>(new[] { "luke", "1234", "n" });
//         var mockIO = new MockIO(inputs);
//         var mockGen = new MockNumberGenerator("1234");
//         var controller = new AppController(mockIO, mockGen);
//
//         controller.Run();
//
//         Assert.IsTrue(mockIO.Outputs.Contains("Enter your user name:\n"));
//         Assert.IsTrue(mockIO.Outputs.Contains("New game:\n"));
//     }
//
//     [TestMethod]
//     [TestCategory("Integration")]
//     public void Test_Game_GivesCorrectFeedback()
//     {
//         var inputs = new Queue<string>(new[] { "luke", "1230", "1234", "n" });
//         var mockIO = new MockIO(inputs);
//         var mockGen = new MockNumberGenerator("1234");
//         var controller = new AppController(mockIO, mockGen);
//
//         controller.Run();
//
//         Assert.IsTrue(mockIO.Outputs.Contains("BBB,\n")); // 1230 guess
//         Assert.IsTrue(mockIO.Outputs.Contains("BBBB,\n")); // 1234 guess
//     }
//
//     [TestMethod]
//     [TestCategory("Integration")]
//     public void Test_Game_ShowsCorrectFinalMessage()
//     {
//         var inputs = new Queue<string>(new[] { "luke", "1230", "1234", "n" });
//         var mockIO = new MockIO(inputs);
//         var mockGen = new MockNumberGenerator("1234");
//         var controller = new AppController(mockIO, mockGen);
//
//         controller.Run();
//
//         Assert.IsTrue(mockIO.Outputs.Contains("Correct, it took 2 guesses\nContinue?"));
//     }
// }