using System;
using Chaos;

public struct Half : IFormattable, IComparable, IComparable<Half>, IEquatable<Half>
{
    ushort _value;

    public static explicit operator Half(float f)
    {
        uint u = (FloatUint)f;
        Half ret = new Half() {_value = (ushort)(((u >> 16) & 0x8000) | ((((u & 0x7f800000) - 0x38000000) >> 13) & 0x7c00) | ((u >> 13) & 0x03ff))};
        return ret;
    }

    public static implicit operator float(Half h)
    {
        ushort s = h._value;
        uint u = (uint)(((s & 0x8000) << 16) | (((s & 0x7c00) + 0x1C000) << 13) | ((s & 0x03FF) << 13));
        float ret = (FloatUint)u;
        return ret;
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
        return a._value == b._value;
    }

    public string ToString(string format, IFormatProvider formatProvider)
    {
        return ((float) this).ToString(format, formatProvider);
    }

    public int CompareTo(object obj)
    {
        Half h = (Half)obj;
        return CompareTo(h);
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
