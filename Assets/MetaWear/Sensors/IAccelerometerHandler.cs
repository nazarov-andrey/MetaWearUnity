namespace MetaWear.Sensors
{
    public interface IAccelerometerHandler
    {
        void OnNewValue (float x, float y, float z);
    }
}