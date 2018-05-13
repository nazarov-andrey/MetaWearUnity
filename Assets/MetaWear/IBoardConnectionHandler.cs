namespace MetaWear
{
    public interface IBoardConnectionHandler
    {
        void OnConnected ();
        void OnFailed ();
        void OnUnexpectedDisconnect ();
    }
}