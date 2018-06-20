using Chaos;

public struct Half
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
}
