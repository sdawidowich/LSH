namespace LSH
{
    public static class BinaryOperations
    {
        public static uint GetBit(uint val, int index)
        {
            return (val >> index) % 2;
        }

        public static uint BytesToInt(byte[] bytes)
        {
            // If the system architecture is little-endian (that is, little end first),
            // reverse the byte array.
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);

            return BitConverter.ToUInt32(bytes, 0);
        }

        public static uint HammingDistance(uint hash1, uint hash2)
        {
            uint xor = hash1 ^ hash2;

            uint setBits = 0;
            while (xor > 0)
            {
                setBits += xor % 2;
                xor = xor >> 1;
            }

            return setBits;
        }
    }
}
