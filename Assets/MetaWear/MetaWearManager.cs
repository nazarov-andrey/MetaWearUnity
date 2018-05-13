using UnityEngine;

namespace MetaWear
{
    public class MetaWearManager : IMetaWearManager
    {
        private IMetaWearManager metaWearManager;

        public MetaWearManager ()
        {
            if (Application.platform == RuntimePlatform.Android)
                metaWearManager = new Android.MetaWearManager ();
            else
                metaWearManager = new Stub.MetaWearManager();
        }

        public void ScanDevices (IDeviceHandler deviceHandler, long timeout = 10000)
        {
            metaWearManager.ScanDevices (deviceHandler, timeout);
        }

        public IBoard GetBoard (BluetoothDevice bluetoothDevice)
        {
            return metaWearManager.GetBoard (bluetoothDevice);
        }

        public IBoard GetBoard (string macAddress)
        {
            return metaWearManager.GetBoard (macAddress);    
        }

        public void ConnectoToTheBoard (IBoard board)
        {
            metaWearManager.ConnectoToTheBoard (board);
        }

        public IAccelerometer GetAccelerometer (IBoard board)
        {
            return metaWearManager.GetAccelerometer (board);
        }
    }
}