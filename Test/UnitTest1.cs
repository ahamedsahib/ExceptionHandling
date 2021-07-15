using System;
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

            string actual = moodAnalyser.AnalyseMood();

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
        public void GetNullReturnCustomException()
        {
            string expected;
            //AAA method
            try
            {
                string message = message = null;
                moodAnalyser = new MoodAnalyser(message);
                string msg = moodAnalyser.AnalyseMood();
                
            }
            catch (NullReferenceException ex)
            {
                expected = "Mood can't be Null";
                Assert.AreEqual(expected, ex.Message);

            }
        }
        [TestMethod]
        public void GetEmptyReturnCustomException()
        {
            //AAA method
            try
            {
                string message = "";
                moodAnalyser = new MoodAnalyser(message);
               String msg= moodAnalyser.AnalyseMood();
               
            }
            catch (CustomMoodAnalyserException e)
            {
                string expected = "Mood can't be Empty";
                Assert.AreEqual(expected, e.Message);
            }

        }
    }
}
