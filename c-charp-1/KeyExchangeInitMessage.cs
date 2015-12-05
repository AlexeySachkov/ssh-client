using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_charp_1.messages
{
    class KeyExchangeInitMessage: BinaryProtocolMessage
    {
        Byte[] cookie;

        public KeyExchangeInitMessage(byte[] data): base(data)
        {
            
        }

    }
}
