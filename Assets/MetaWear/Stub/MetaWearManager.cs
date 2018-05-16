using System;
using MetaWear.Sensors;

namespace MetaWear.Stub
{
    public class MetaWearManager : IMetaWearManager
    {
        public void Init (Action initializedCallback)
        {
            initializedCallback ();
        }

        public IBoard GetBoard (BluetoothDevice bluetoothDevice)
        {
            return new Board ();
        }

        public IBoard GetBoard (string macAddress)
        {
            return new Board ();
        }

        public void ConnectoToTheBoard (IBoard board)
        {
        }

        public IAccelerometer GetAccelerometer (IBoard board)
        {
            return new Accelerometer ();
        }

        public IMagnetometer GetMagnetometer (IBoard board)
        {
            return new Magnetometer ();
        }

        public IGyro GetGyro (IBoard board)
        {
            return new Gyro ();
        }

        public ILight GetLight (IBoard board)
        {
            return new Light ();
        }
    }
}