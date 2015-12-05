using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_charp_1
{
    class ByteBuffer
    {
        protected Byte[] _buffer;
        Int32 pos;

        public ByteBuffer()
        {
            this._buffer = null;
            this.pos = 0;
        }

        public ByteBuffer(Byte[] buffer)
        {
            this._buffer = new byte[buffer.Length];
            Array.Copy(buffer, this._buffer, buffer.Length);
            this.pos = 0;
        }

        public void append(Byte[] additionalBuffer)
        {
            if (this._buffer == null)
            {
                this._buffer = new byte[additionalBuffer.Length];
                Array.Copy(additionalBuffer, this._buffer, additionalBuffer.Length);
            }
            else
            {
                byte[] tmpBuf = new byte[this._buffer.Length + additionalBuffer.Length];
                Array.Copy(this._buffer, tmpBuf, this._buffer.Length);
                Array.Copy(additionalBuffer, 0, tmpBuf, this._buffer.Length, additionalBuffer.Length);
                this._buffer = tmpBuf;
            }
        }

        public UInt32 readUInt32()
        {
            if (this._buffer == null)
            {
                throw new NullReferenceException();
            }
            else if (this.pos + 4 < this._buffer.Length)
            {
                UInt32 res = (uint)(this._buffer[this.pos] << 24 | this._buffer[this.pos + 1] << 16 | this._buffer[this.pos + 2] << 8 | this._buffer[this.pos + 3]);
                this.pos += 4;

                return res;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public Byte readByte()
        {
            if (this._buffer == null)
            {
                throw new NullReferenceException();
            }
            else if (this.pos < this._buffer.Length)
            {
                Byte res = this._buffer[this.pos];
                ++this.pos;

                return res;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public Byte[] readBytes(int length)
        {
            if (this._buffer == null)
            {
                throw new NullReferenceException();
            }
            else if (this.pos + length < this._buffer.Length)
            {
                Byte[] res = new Byte[length];
                Array.Copy(this._buffer, 0, res, 0, length);

                return res;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public String[] readNameList()
        {
            if (this._buffer == null)
            {
                throw new NullReferenceException();
            }
            else if (this.pos < this._buffer.Length)
            {
                UInt32 length = this.readUInt32();

                if (length == 0)
                {
                    return null;
                }
                else
                {
                    String tmp = Encoding.ASCII.GetString(this.readBytes((Int32)length));

                    return tmp.Split(',');
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void skipBytes(Int32 n)
        {
            if (this._buffer == null)
            {
                throw new NullReferenceException();
            }
            else if (this.pos + n < this._buffer.Length)
            {
                this.pos += n;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public Boolean readBoolean()
        {
            if (this._buffer == null)
            {
                throw new NullReferenceException();
            }
            else if (this.pos < this._buffer.Length)
            {
                Byte res = this._buffer[this.pos];
                ++this.pos;

                return (res != 0);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void reset()
        {
            if (this._buffer == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                this.pos = 0;
            }
        }

        public String toString(Encoding encoding)
        {
            if (this._buffer == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                return encoding.GetString(this._buffer);
            }
        }

        public static ByteBuffer fromString(String str, Encoding encoding)
        {
            return new ByteBuffer(encoding.GetBytes(str));
        }

        public Int32 length()
        {
            if (this._buffer == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                return this._buffer.Length;
            }
        }

        public Boolean isEmtpy()
        {
            if (this._buffer == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                return (this._buffer.Length == 0);
            }
        }
    }
}
