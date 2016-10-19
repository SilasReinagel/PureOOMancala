using System;

namespace Mancala.Tests
{
    public static class ExceptionAssert
    {
        public static void AssertThrows<T>(Action action) where T : Exception
        {
            try
            {
                action();
                throw new ExceptionAssertFailed(
                    string.Format("Expected exception of type {0}, but no exception was thrown.", typeof (T).Name));
            }
            catch (T) { }
            catch (Exception ex)
            {
                throw new ExceptionAssertFailed(
                    string.Format("Expected exception type: {0}. Actual: {1}", typeof(T).Name, ex.GetType().Name));
            }
        }

        public class ExceptionAssertFailed : Exception
        {
            public ExceptionAssertFailed(string message) : base(message)
            {
            }
        }
    }
}
