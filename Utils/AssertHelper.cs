using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTestingNUnit.Utils
{
    public class AssertHelper
    {
       /**************************************************************************************************************
       * Method for asserting two values and printing value for debug purposes.
       **************************************************************************************************************/
        public static void AssertStringEqualAndLog(string expected, string actual, string? message = null)
        {
            if (message != null)
            {
                TestContext.WriteLine($"Expected value: {expected}, Actual Value: {actual}, {message}");
            }
            else
            {
                TestContext.WriteLine($"Expected value: {expected}, Actual Value: {actual}");
                Assert.That(expected == actual);
            }
        }

        /**************************************************************************************************************
        * Method for asserting bolean value and printing value for debug purposes.
        **************************************************************************************************************/
        public static void AssertAndLog(bool condition, string? message = null)
        {
            if (message != null)
            {
                TestContext.WriteLine($"{message} condition is: {condition}");
                Assert.That(condition);
            }
            else
            {
                TestContext.WriteLine($"Condition is: {condition}");
                Assert.That(condition);
            }
        }

       /**************************************************************************************************************
       * Method for asserting two int values and printing value for debug purposes.
       **************************************************************************************************************/
        public static void AssertIntEqualAndLog(int expected, int actual, string? message = null)
        {
            if (message != null)
            {
                TestContext.WriteLine($"Expected value: {expected}, Actual Value: {actual}, {message}");
            }
            else
            {
                TestContext.WriteLine($"Expected value: {expected}, Actual Value: {actual}");
                Assert.That(expected == actual);
            }
        }
    }
}
