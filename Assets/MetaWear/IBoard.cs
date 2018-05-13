using System;

namespace MetaWear
{
    public interface IBoard
    {
        bool IsConnected { get; }

        event EventHandler<EventArgs> Connected;
        event EventHandler<EventArgs> Failed;
        event EventHandler<EventArgs> UnexpectedDisconnect;
    }
}