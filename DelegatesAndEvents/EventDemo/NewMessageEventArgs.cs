using System;

namespace EventDemo
{
    class NewMessageEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}
