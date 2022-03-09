﻿namespace PopStudio.Image.Xnb
{
    internal class XnbHead
    {
        static byte[] xnbmagic = new byte[0x6] { 0x58, 0x4E, 0x42, 0x6D, 0x05, 0x00 };
        static byte[] xnbinfo = new byte[0x9D] { 0x01, 0x94, 0x01, 0x4D, 0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x2E, 0x58, 0x6E, 0x61, 0x2E, 0x46, 0x72, 0x61, 0x6D, 0x65, 0x77, 0x6F, 0x72, 0x6B, 0x2E, 0x43, 0x6F, 0x6E, 0x74, 0x65, 0x6E, 0x74, 0x2E, 0x54, 0x65, 0x78, 0x74, 0x75, 0x72, 0x65, 0x32, 0x44, 0x52, 0x65, 0x61, 0x64, 0x65, 0x72, 0x2C, 0x20, 0x4D, 0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x2E, 0x58, 0x6E, 0x61, 0x2E, 0x46, 0x72, 0x61, 0x6D, 0x65, 0x77, 0x6F, 0x72, 0x6B, 0x2E, 0x47, 0x72, 0x61, 0x70, 0x68, 0x69, 0x63, 0x73, 0x2C, 0x20, 0x56, 0x65, 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x3D, 0x34, 0x2E, 0x30, 0x2E, 0x30, 0x2E, 0x30, 0x2C, 0x20, 0x43, 0x75, 0x6C, 0x74, 0x75, 0x72, 0x65, 0x3D, 0x6E, 0x65, 0x75, 0x74, 0x72, 0x61, 0x6C, 0x2C, 0x20, 0x50, 0x75, 0x62, 0x6C, 0x69, 0x63, 0x4B, 0x65, 0x79, 0x54, 0x6F, 0x6B, 0x65, 0x6E, 0x3D, 0x38, 0x34, 0x32, 0x63, 0x66, 0x38, 0x62, 0x65, 0x31, 0x64, 0x65, 0x35, 0x30, 0x35, 0x35, 0x33, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01 };
        static int format = 1;

        public int xnbSize;
        public int width;
        public int height;
        public int texturesize;

        public XnbHead Read(BinaryStream bs)
        {
            bs.IdBytes(xnbmagic);
            xnbSize = bs.ReadInt32();
            bs.IdBytes(xnbinfo);
            bs.IdInt32(0);
            width = bs.ReadInt32();
            height = bs.ReadInt32();
            bs.IdInt32(format);
            texturesize = bs.ReadInt32();
            return this;
        }

        public void Write(BinaryStream bs)
        {
            if (xnbSize == 0) xnbSize = (int)bs.Length;
            if (texturesize == 0) texturesize = (width * height) << 2;
            bs.WriteBytes(xnbmagic);
            bs.WriteInt32(xnbSize);
            bs.WriteBytes(xnbinfo);
            bs.WriteInt32(0);
            bs.WriteInt32(width);
            bs.WriteInt32(height);
            bs.WriteInt32(format);
            bs.WriteInt32(texturesize);
        }
    }
}
