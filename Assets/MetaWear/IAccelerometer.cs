namespace MetaWear
{
    public interface IAccelerometer
    {
        void Start (IAccelerometerHandler handler);
        void Stop ();
    }
}