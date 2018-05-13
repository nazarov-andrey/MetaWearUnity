namespace MetaWear
{
    public interface IMetaWearManager
    {
        void ScanDevices (IDeviceHandler deviceHandler, long timeout);
        IBoard GetBoard (BluetoothDevice bluetoothDevice);
        IBoard GetBoard (string macAddress);
        void ConnectoToTheBoard (IBoard board);
        
        IAccelerometer GetAccelerometer (IBoard board);
    }
}