using System;
using MetaWear.Sensors;

namespace MetaWear
{
    public interface IMetaWearManager
    {
        void Init (Action initializedCallback);
        
        IBoard GetBoard (BluetoothDevice bluetoothDevice);
        IBoard GetBoard (string macAddress);
        void ConnectoToTheBoard (IBoard board);
        
        IAccelerometer GetAccelerometer (IBoard board);
        IMagnetometer GetMagnetometer (IBoard board);
        IGyro GetGyro (IBoard board);
        ILight GetLight (IBoard board);
    }
}