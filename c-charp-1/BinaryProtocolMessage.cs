using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_charp_1.messages
{
    class BinaryProtocolMessage
    {
        protected ByteBuffer _bytebuffer;
        protected ByteBuffer _payload;

        public UInt32 packetLength
        {
            get { return packetLength; }
            private set { packetLength = value; }
        }
        public UInt32 paddingLength
        {
            get { return paddingLength; }
            private set { paddingLength = value; }
        }

        public BinaryProtocolMessage(byte[] data)
        {
            this._bytebuffer = new ByteBuffer(data);
            this.packetLength = this._bytebuffer.readUInt32();
            this.paddingLength = this._bytebuffer.readByte();
            this._payload = new ByteBuffer(this._bytebuffer.readBytes((Int32)this.paddingLength));
        }

    }
}
