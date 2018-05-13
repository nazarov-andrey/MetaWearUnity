namespace MetaWear.Stub
{
    public class MetaWearManager : IMetaWearManager
    {
        public void ScanDevices (IDeviceHandler deviceHandler, long timeout)
        {
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
    }
}