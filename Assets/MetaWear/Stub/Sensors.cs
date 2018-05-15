using MetaWear.Sensors;

namespace MetaWear.Stub
{
    public class Sensor<THandler> : ISensor<THandler>
    {
        public void Start (THandler handler)
        {
        }

        public void Stop ()
        {
        }
    }

    public class Accelerometer : Sensor<IAccelerometerHandler>, IAccelerometer
    {
    }

    public class Magnetometer : Sensor<IMagnetometerHandler>, IMagnetometer
    {
    }

    public class Gyro : Sensor<IGyroHandler>, IGyro
    {
    }

    public class Light : Sensor<ILightHandler>, ILight
    {
    }
}