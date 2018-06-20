

using System.Runtime.InteropServices;

namespace Chaos {

    [StructLayout(LayoutKind.Explicit)]
    public struct FloatUint
    {
        [FieldOffset(0)]
        uint _uint;
        [FieldOffset(0)]
        float _float;

        public static implicit operator FloatUint(float f)
        {
            FloatUint fu = new FloatUint() {_float = f};
            return fu;
        }

        public static implicit operator FloatUint(uint u)
        {
            FloatUint fu = new FloatUint() {_uint = u};
            return fu;
        }

        public static implicit operator float(FloatUint fu)
        {
            return fu._float;
        }

        public static implicit operator uint(FloatUint fu)
        {
            return fu._uint;
        }
    }
}
