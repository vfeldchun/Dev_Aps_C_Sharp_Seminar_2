

using System.Text;

namespace HW_Seminar2
{
    public class Bits : IGetBitable
    {
        public Bits(byte b)
        {
            this.Value = b;
            this.Size = sizeof(byte);
        }

        public Bits(int b)
        {
            this.Value = b;
            this.Size = sizeof(int);
        }

        public Bits(long b)
        {
            this.Value = b;
            this.Size = sizeof(long);
        }

        public long Value { get; private set; }
        public int Size { get; private set; }
        public bool this[int index]
        {
            get => GetBitByIndex(index);
            set => SetBitByIndex(index, value);
        }

        public static implicit operator byte(Bits b) => (byte)b.Value;
        public static implicit operator int(Bits b) => (int)b.Value;
        public static implicit operator long(Bits b) => b.Value;
        public static explicit operator Bits(byte b) => new Bits(b);
        public static explicit operator Bits(int b) => new Bits(b);
        public static explicit operator Bits(long b) => new Bits(b);

        public bool GetBitByIndex(int index)
        {
            if (index > (this.Size * 8 - 1) || index < 0)
                return false;
            return ((this.Value >> index) & 1) == 1;
        }

        public void SetBitByIndex(int index, bool value)
        {
            if (index > (this.Size * 8 - 1) || index < 0) return;
            if (value == true)
            {
                switch (this.Size)
                {
                    case 1:
                        this.Value = (byte)(this.Value | (1 << index));
                        break;
                    case 4:
                        this.Value = (int)(this.Value | (1 << index));
                        break;
                    case 8:
                        this.Value = (long)(this.Value | (1 << index));
                        break;
                }
            }
            else
            {
                switch (this.Size)
                {
                    case 1:
                        var bMask = (byte)(1 << index);
                        bMask = (byte)(0xff ^ bMask);
                        this.Value &= (byte)(this.Value & bMask);
                        break;
                    case 4:
                        var iMask = (int)(1 << index);
                        iMask = (int)(int.MaxValue ^ iMask);
                        this.Value &= (int)(this.Value & iMask);
                        break;
                    case 8:
                        var lMask = (long)(1 << index);
                        lMask = (long)(long.MaxValue ^ lMask);
                        this.Value &= (long)(this.Value & lMask);
                        break;
                }
            }
        }

        public string ToStringOfBits() 
        {
            var result = new StringBuilder();
            int separatorCounter = 0;

            for (int i = this.Size * 8 - 1; i >= 0; i--)
            {
                result.Append(this[i] ? "1" : "0");
                separatorCounter++;
                if(separatorCounter % 8 == 0)
                    result.Append(" ");
            }
                
            
           
            return result.ToString();
        }

    }
}
