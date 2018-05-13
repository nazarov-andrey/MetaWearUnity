using System.Collections.Generic;

namespace MetaWear
{
    public class BoardConnectionHandlersList : List<IBoardConnectionHandler>, IBoardConnectionHandler
    {
        public void OnConnected ()
        {
            ForEach (x => x.OnConnected ());
        }

        public void OnFailed ()
        {
            ForEach (x => x.OnFailed ());
        }

        public void OnUnexpectedDisconnect ()
        {
            ForEach (x => x.OnUnexpectedDisconnect ());
        }
    }
}