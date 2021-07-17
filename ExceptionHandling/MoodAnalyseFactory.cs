using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ExceptionHandling
{
    public class MoodAnalyseFactory
    {
       public Object CreateMoodAnalyserObject(string className,string constructor)
        {
            string pattern =  constructor + "$";
            Match result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalysertype = assembly.GetType(className);
                    var newObject = Activator.CreateInstance(moodAnalysertype);
                    return newObject;
                }
                catch (Exception e)
                {
                    throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.CLASS_NOT_FOUND, "Class Not Found");
                }
            }
            else
            {
                throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "Constructor not Found");
            }



        }

       public object CreateMoodAnalyserParameterizedObject(string className, string constructor,string message)
        {
           
            Type type = typeof(MoodAnalyser);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructor))
                {

                    ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string) });
                    var obj = constructorInfo.Invoke(new object[] { message } ) ;
                    return obj;
                }
                else
                {
                    throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.CLASS_NOT_FOUND, "Class Not Found");
                }
            }
            else
            {
                throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "Constructor not Found");
            }
            
        }
        public string InvokeMethod(string methodName, string message)
        {
            try
            {
                Type type = typeof(MoodAnalyser);
                MethodInfo method = type.GetMethod(methodName);
                MoodAnalyseFactory factory = new MoodAnalyseFactory();
                object MoodAnalayserObject = factory.CreateMoodAnalyserParameterizedObject("MoodAnalyser", "MoodAnalyser", message);
                object MethodObject = method.Invoke(MoodAnalayserObject, null);
                return MethodObject.ToString();
            }
            catch( NullReferenceException e)
            {
                throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.NO_SUCH_METHOD, "No such Method Error");
            }
        }
    }
}
