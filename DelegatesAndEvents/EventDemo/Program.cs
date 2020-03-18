using System;

namespace EventDemo
{
    class Program
    {
        // "Longhand" event declaration officially called "Event property".
        public event EventHandler MyEvent
        {
            // For simplicity we ignore the delegate instance passed to both "add" and "remove" methods.
            add
            {
                Console.WriteLine("add operation");
            }

            remove
            {
                Console.WriteLine("remove operation");
            }
        }

        static void Main(string[] args)
        {
            var classWithMethodsMatchingEventTypes = new ClassWithMethodsMatchingEventTypes();

            // 1. Demonstrate how do "add" and "remove" accessors of event property work.
            var p = new Program();
            p.MyEvent += new EventHandler(classWithMethodsMatchingEventTypes.DoNothing);
            p.MyEvent -= null; // It does not matter that we are passing null, "remove" accessor code is executed.

            // 2. Attach the handler to an event declared using "shorthand" notation.
            var classWithTheShorthandEventProp = new ShorthandEventAndBackingDelegateDeclaration();
            classWithTheShorthandEventProp.NewMessage += new EventHandler<NewMessageEventArgs>
                (classWithMethodsMatchingEventTypes.LogEventToConsole);
            NewMessageEventArgs eventArgs = new NewMessageEventArgs { Message = "Hello! It's a brand new message" };

            // Raise the event.
            classWithTheShorthandEventProp.OnNewMessage(eventArgs);
        }
    }
}
