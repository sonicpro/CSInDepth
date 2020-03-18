using System;

namespace EventDemo
{
    // The signature of the single method resemble System.EventHandler signature.
    class ClassWithMethodsMatchingEventTypes
    {
        public void DoNothing(object sender, EventArgs e)
        {
        }

        public void LogEventToConsole(object sender, NewMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
