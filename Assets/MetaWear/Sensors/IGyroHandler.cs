namespace MetaWear.Sensors
{
    public interface IGyroHandler
    {
        void OnNewValue (float x, float y, float z);
    }
}