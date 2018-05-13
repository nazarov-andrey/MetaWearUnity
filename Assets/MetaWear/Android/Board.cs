using System;
using UnityEngine;

namespace MetaWear.Android
{
    public class Board : AndroidJavaProxy, IBoard
    {
        public Board (AndroidJavaObject nativeBoard) : base ("de.horizont.metawearunity.IBoardConnectionHandler")
        {
            NativeBoard = nativeBoard;
        }

        public void OnConnected ()
        {
            IsConnected = true;
            Connected?.Invoke (this, EventArgs.Empty);
        }

        public void OnFailed ()
        {
            IsConnected = false;
            Failed?.Invoke (this, EventArgs.Empty);
        }

        public void OnUnexpectedDisconnect ()
        {
            IsConnected = false;
            UnexpectedDisconnect?.Invoke (this, EventArgs.Empty);
        }

        public AndroidJavaObject NativeBoard { get; }
        public bool IsConnected { private set; get; }
        public event EventHandler<EventArgs> Connected;
        public event EventHandler<EventArgs> Failed;
        public event EventHandler<EventArgs> UnexpectedDisconnect;
    }
}