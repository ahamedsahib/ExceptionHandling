using ExceptionHandling;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        MoodAnalyser moodAnalyser;
        
        [TestMethod]
        public void GetHappyMoodStatus()
        {
            //AAA method
            string message = "I am in happy mood";
            moodAnalyser = new MoodAnalyser(message);
            string expected = "happy";

            string actual=moodAnalyser.AnalyseMood();

            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void GetSadMoodStatus()
        {
            //AAA method
            string message = "I am in Sad mood";
            moodAnalyser = new MoodAnalyser(message);
            string expected = "sad";

            string actual = moodAnalyser.AnalyseMood();

            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void GetNullException()
        {
            string message = null;
            moodAnalyser = new MoodAnalyser(message);
            string expected = "Happy";

            string actual = moodAnalyser.AnalyseMood();

            Assert.AreEqual(actual, expected);

        }
    }
}
