namespace MetaWear
{
    public struct BluetoothDevice
    {
        public readonly string MacAddress;
        public readonly string Name;

        public BluetoothDevice (string macAddress, string name)
        {
            MacAddress = macAddress;
            Name = name;
        }

        public override string ToString ()
        {
            return $"{nameof (MacAddress)}: {MacAddress}, {nameof (Name)}: {Name}";
        }
    }
}