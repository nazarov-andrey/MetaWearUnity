namespace MetaWear.Sensors
{
    public interface ISensor<IHandler>
    {
        void Start (IHandler handler);
        void Stop ();
    }
}