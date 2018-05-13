using System;

namespace MetaWear.Stub
{
    public class Board : IBoard
    {
        public bool IsConnected { get; }
        public event EventHandler<EventArgs> Connected;
        public event EventHandler<EventArgs> Failed;
        public event EventHandler<EventArgs> UnexpectedDisconnect;
    }
}