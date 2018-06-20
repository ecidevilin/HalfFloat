using System;
using Chaos;

public struct Half : IFormattable, IComparable, IComparable<Half>, IEquatable<Half>
{
    public static readonly Half NegativeInfinity = new Half() {_value = 0xFFFF};
    public static readonly Half PositiveInfinity = new Half() { _value = 0x7FFF };
    ushort _value;

    public static explicit operator Half(float f)
    {
        uint u = (FloatUint)f;
        if (u == 0)
        {
            return new Half() {_value =  0};
        }
        if (u == 0x80000000)
        {
            return new Half() {_value = 0x8000};
        }
        return new Half() {_value = (ushort)(((u >> 16) & 0x8000) | ((((u & 0x7f800000) - 0x38000000) >> 13) & 0x7c00) | ((u >> 13) & 0x03ff))};
    }

    public static implicit operator float(Half h)
    {
        ushort s = h._value;
        if (s == 0)
        {
            return 0;
        }
        if (s == 0x8000)
        {
            return (FloatUint)0x80000000;
        }
        return (FloatUint)(uint)(((s & 0x8000) << 16) | (((s & 0x7c00) + 0x1C000) << 13) | ((s & 0x03FF) << 13));
    }

    
    public static Half operator +(Half a, Half b)
    {
        return (Half)((float) a + (float) b);
    }

    
    public static Half operator -(Half a, Half b)
    {
        return (Half)((float)a - (float)b);
    }
    
    public static Half operator *(Half a, Half b)
    {
        return (Half)((float)a * (float)b);
    }

    
    public static Half operator /(Half a, Half b)
    {
        return (Half)((float)a / (float)b);
    }

    
    public static bool operator >(Half a, Half b)
    {
        return (float)a > (float)b;
    }
    
    public static bool operator <(Half a, Half b)
    {
        return (float)a < (float)b;
    }
    
    public static bool operator >=(Half a, Half b)
    {
        return (float)a >= (float)b;
    }
    
    public static bool operator <=(Half a, Half b)
    {
        return (float)a <= (float)b;
    }

    public static bool operator ==(Half a, Half b)
    {
        return a._value == b._value;
    }
    public static bool operator !=(Half a, Half b)
    {
        return a._value != b._value;
    }

    public override string ToString()
    {
        return ((float) this).ToString();
    }

    public string ToString(string format, IFormatProvider formatProvider)
    {
        return ((float) this).ToString(format, formatProvider);
    }

    public int CompareTo(object obj)
    {
        return CompareTo((Half)obj);
    }

    public int CompareTo(Half h)
    {
        return this == h ? 0 : (this > h ? 1 : -1);
    }

    public bool Equals(Half other)
    {
        return this == other;
    }
}
