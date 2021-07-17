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
            catch (CustomMoodAnalyserException e)
            {
                expected = "Mood can't be Null";
                Assert.AreEqual(expected, e.Message);

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
        [TestMethod]
        [TestCategory("DefaultConstructorReflection")]
        public void ObjectCreationUsingDeafultConstructor()
        {
          ///<summary>
          ///TC1 Class Name and Constructor Name should be same
          ///</summary>  

            MoodAnalyser expected = new MoodAnalyser();
            Object obj = null;
            //AAA method
            try
            {
                MoodAnalyseFactory moodAnalyse = new MoodAnalyseFactory();
                obj=moodAnalyse.CreateMoodAnalyserObject("ExceptionHandling.MoodAnalyser", "MoodAnalyser");
  
            }
            catch (CustomMoodAnalyserException e)
            {
                throw new Exception(e.Message);
            }
            obj.Equals(expected);

        }
        [TestMethod]
        [TestCategory("DefaultConstructorReflection")]
        public void ObjectCreationUsingDeafultConstructorReturnClassException()
        {
            ///<summary>
            ///TC2 Class Name and Constructor Name should be differnet
            ///</summary>  

            MoodAnalyser expected = new MoodAnalyser();
            Object obj = null;
            //AAA method
            try
            {
                MoodAnalyseFactory moodAnalyse = new MoodAnalyseFactory();
                obj = moodAnalyse.CreateMoodAnalyserObject("ExceptionHandling.MoodAnalyse", "MoodAnalyse");

            }
            catch (CustomMoodAnalyserException e)
            {
                throw new Exception(e.Message);
            }
            obj.Equals(expected);

        }
        [TestMethod]
        [TestCategory("DefaultConstructorReflection")]
        public void ObjectCreationUsingDeafultConstructoReturnConstructorException()
        {
            ///<summary>
            ///TC3 Class Name Not Found
            ///</summary>  

            MoodAnalyser expected = new MoodAnalyser();
            Object obj = null;
            //AAA method
            try
            {
                MoodAnalyseFactory moodAnalyse = new MoodAnalyseFactory();
                obj = moodAnalyse.CreateMoodAnalyserObject("ExceptionHandling.MoodAnalyse", "MoodAnalyser");

            }
            catch (CustomMoodAnalyserException e)
            {
                throw new Exception(e.Message);
            }
            obj.Equals(expected);
        }
        [TestMethod]
        [TestCategory("ParameterizedConstructorReflection")]
        public void GetReflectionReturnparameterizedConstructor()
        {
            ///<summary>
            ///TC1 Class Name and Constructor Name should be same
            ///</summary>  
            //AAA method
            Object obj = null;
            string message = "I am in a happy mood";
            MoodAnalyser expected = new MoodAnalyser(message);
            try
            {
                MoodAnalyseFactory moodAnalyse = new MoodAnalyseFactory();
                obj = moodAnalyse.CreateMoodAnalyserParameterizedObject("ExceptionHandling.MoodAnalyser", "MoodAnalyser", "I am in a happy mood");
            }
            catch (CustomMoodAnalyserException e)
            {
                throw new Exception(e.Message);
            }
            obj.Equals(expected);
        }
        [TestMethod]
        [TestCategory("ParameterizedConstructorReflection")]
        public void GetClassNotFoundExceptionUsingParameterizedConstructorReflection()
        {  ///<summary>
           ///TC2 Class Name Not Found
           ///</summary>  
            //AAA method
            //AAA method
            Object obj = null;
            string message = "I am in a happy mood";
            MoodAnalyser expected = new MoodAnalyser(message);
            try
            {
                MoodAnalyseFactory moodAnalyse = new MoodAnalyseFactory();
                obj = moodAnalyse.CreateMoodAnalyserParameterizedObject("ExceptionHandling.MoodAnalyse", "MoodAnalyse", "I am in a happy mood");
            }
            catch (CustomMoodAnalyserException e)
            {
                throw new Exception(e.Message);
            }
            obj.Equals(expected);
        }
        [TestMethod]
        [TestCategory("ParameterizedConstructorReflection")]
        public void GetConstructorNotFoundExceptionUsingParameterizedConstructorReflection()
        {
            ///<summary>
            ///TC3 Class Name and Constructor Name should be Differnet
            ///</summary>  
            //AAA method
            //AAA method
            Object obj = null;
            string message = "I am in a happy mood";
            MoodAnalyser expected = new MoodAnalyser(message);
            try
            {
                MoodAnalyseFactory moodAnalyse = new MoodAnalyseFactory();
                obj = moodAnalyse.CreateMoodAnalyserParameterizedObject("ExceptionHandling.MoodAnalyser", "MoodVerifier", "I am in a happy mood");
            }
            catch (CustomMoodAnalyserException e)
            {                throw new Exception(e.Message);
            }
            obj.Equals(expected);
        }
        [TestMethod]
        [TestCategory("InvokeMethodReflection")]
        public void InvokeMethodUsingDynamicObject()
        {
            ///<summary>
            ///TC1 Method Found and Invoked by object
            ///</summary>  
            //AAA method
            //AAA method
            string actual;
            string message = "I am in a happy mood";
            string methodName = "AnalyseMood";
            string expected = "happy";
            
            try
            {
                MoodAnalyseFactory moodAnalyse = new MoodAnalyseFactory();
                actual = moodAnalyse.InvokeMethod(methodName, message);
            }
            catch (CustomMoodAnalyserException e)
            {
                throw new Exception(e.Message);
            }
            actual.Equals(expected);
        }
        [TestMethod]
        [TestCategory("InvokeMethodReflection")]
        public void InvokeMethodUsingDynamicObjectReturnMthodNotFoundException()
        {
            ///<summary>
            ///TC1 Method Found and Invoked by object
            ///</summary>  
            //AAA method
            //AAA method
            string actual;
            string message = "I am in a happy mood";
            string methodName = "Analyse";
            string expected = "happy";

            try
            {
                MoodAnalyseFactory moodAnalyse = new MoodAnalyseFactory();
                actual = moodAnalyse.InvokeMethod(methodName, message);
            }
            catch (CustomMoodAnalyserException e)
            {
                throw new Exception(e.Message);
            }
            actual.Equals(expected);
        }
    }
}
