namespace MetaWear.Sensors
{
    public interface IMagnetometerHandler
    {
        void OnNewValue (float x, float y, float z);   
    }
}