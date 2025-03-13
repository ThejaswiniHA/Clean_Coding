using Moq;
using PredictionEngine;
namespace PredictionEngine.Tests;

public class PredictionEngineTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("How are y","y")]
    [TestCase("How are you doing","doing")]
    [TestCase("", "")]
    public void ShouldPassForUniGram(string inputString, string lastWord)
    {
        var mock = new Mock<ILanguageModelAlgo>();
        PredictionEngine predictionEngine = new PredictionEngine(mock.Object);
        string predictedWord = predictionEngine.predict(inputString);
        mock.Verify(p => p.predictUsingMonogram(lastWord), Times.Once());
    }

    [TestCase("How are you ","you")]
    [TestCase(" ","")]
    public void ShouldPassForBiGram(string inputString, string lastWord)
    {
        var mock = new Mock<ILanguageModelAlgo>();
        PredictionEngine predictionEngine = new PredictionEngine(mock.Object);
        string predictedWord = predictionEngine.predict(inputString);
        mock.Verify(p => p.predictUsingBigram(lastWord), Times.Once());
    }
}
