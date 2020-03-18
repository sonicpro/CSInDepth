using System;

namespace EventDemo
{
    class ShorthandEventAndBackingDelegateDeclaration
    {
        // The same as the "longhand" event property declaration, but without the "body" part:
        public event EventHandler<NewMessageEventArgs> NewMessage;

        // The above is translated to the following in C# 1.1:
        // private EventHandler<NewMessageEventArgs> _newMessage;
        //
        // public event EventHandler<NewMessageEventArgs> NewMessage
        // {
        //      add
        //      {
        //          lock (this)
        //          {
        //              _newMessage += value;
        //          }
        //      }
        //      remove
        //      {
        //          lock (this)
        //          {
        //              _newMessage -= value;
        //          }
        //      }
        //  }

        /// <summary>
        /// Raises the NewMessage event.
        /// </summary>
        public virtual void OnNewMessage(NewMessageEventArgs e)
        {
            NewMessage?.Invoke(this, e);
        }
    }
}
