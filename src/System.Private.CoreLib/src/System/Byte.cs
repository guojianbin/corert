// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

/*============================================================
**
**
**
** Purpose: This class will encapsulate a byte and provide an
**          Object representation of it.
**
** 
===========================================================*/

using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Diagnostics.Contracts;

namespace System
{
    // The Byte class extends the Value class and 
    // provides object representation of the byte primitive type. 
    // 
    [System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
    [Serializable]
    [System.Runtime.CompilerServices.TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
    public struct Byte : IComparable, IFormattable, IComparable<Byte>, IEquatable<Byte>, IConvertible
    {
        private byte m_value; // Do not rename (binary serialization)

        // The maximum value that a Byte may represent: 255.
        public const byte MaxValue = (byte)0xFF;

        // The minimum value that a Byte may represent: 0.
        public const byte MinValue = 0;


        // Compares this object to another object, returning an integer that
        // indicates the relationship. 
        // Returns a value less than zero if this  object
        // null is considered to be less than any instance.
        // If object is not of type byte, this method throws an ArgumentException.
        // 
        public int CompareTo(Object value)
        {
            if (value == null)
            {
                return 1;
            }
            if (!(value is Byte))
            {
                throw new ArgumentException(SR.Arg_MustBeByte);
            }

            return m_value - (((Byte)value).m_value);
        }

        public int CompareTo(Byte value)
        {
            return m_value - value;
        }

        // Determines whether two Byte objects are equal.
        public override bool Equals(Object obj)
        {
            if (!(obj is Byte))
            {
                return false;
            }
            return m_value == ((Byte)obj).m_value;
        }

        [NonVersionable]
        public bool Equals(Byte obj)
        {
            return m_value == obj;
        }

        // Gets a hash code for this instance.
        public override int GetHashCode()
        {
            return m_value;
        }


        [Pure]
        public static byte Parse(String s)
        {
            return Parse(s, NumberStyles.Integer, null);
        }

        [Pure]
        public static byte Parse(String s, NumberStyles style)
        {
            UInt32.ValidateParseStyleInteger(style);
            return Parse(s, style, null);
        }

        [Pure]
        public static byte Parse(String s, IFormatProvider provider)
        {
            return Parse(s, NumberStyles.Integer, provider);
        }


        // Parses an unsigned byte from a String in the given style.  If
        // a NumberFormatInfo isn't specified, the current culture's 
        // NumberFormatInfo is assumed.
        [Pure]
        public static byte Parse(String s, NumberStyles style, IFormatProvider provider)
        {
            UInt32.ValidateParseStyleInteger(style);

            int i = 0;
            try
            {
                i = FormatProvider.ParseInt32(s, style, provider);
            }
            catch (OverflowException e)
            {
                throw new OverflowException(SR.Overflow_Byte, e);
            }

            if (i < MinValue || i > MaxValue) throw new OverflowException(SR.Overflow_Byte);
            return (byte)i;
        }

        public static bool TryParse(String s, out Byte result)
        {
            return TryParse(s, NumberStyles.Integer, null /* NumberFormatInfo.CurrentInfo */, out result);
        }

        public static bool TryParse(String s, NumberStyles style, IFormatProvider provider, out Byte result)
        {
            UInt32.ValidateParseStyleInteger(style);

            result = 0;
            int i;
            if (!FormatProvider.TryParseInt32(s, style, provider, out i))
            {
                return false;
            }
            if (i < MinValue || i > MaxValue)
            {
                return false;
            }
            result = (byte)i;
            return true;
        }

        [Pure]
        public override String ToString()
        {
            Contract.Ensures(Contract.Result<String>() != null);
            return FormatProvider.FormatInt32(m_value, null, null);
        }

        [Pure]
        public String ToString(String format)
        {
            Contract.Ensures(Contract.Result<String>() != null);
            return FormatProvider.FormatInt32(m_value, format, null);
        }

        [Pure]
        public String ToString(IFormatProvider provider)
        {
            Contract.Ensures(Contract.Result<String>() != null);
            // if (provider == null)
            // throw new ArgumentNullException("provider");

            return FormatProvider.FormatInt32(m_value, null, provider);
        }

        [Pure]
        public String ToString(String format, IFormatProvider provider)
        {
            Contract.Ensures(Contract.Result<String>() != null);

            // if (provider == null)
            // throw new ArgumentNullException("provider");

            return FormatProvider.FormatInt32(m_value, format, provider);
        }

        //
        // IConvertible implementation
        // 
        [Pure]
        public TypeCode GetTypeCode()
        {
            return TypeCode.Byte;
        }


        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            return Convert.ToBoolean(m_value);
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(m_value);
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(m_value);
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return m_value;
        }

        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(m_value);
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(m_value);
        }

        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(m_value);
        }

        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(m_value);
        }

        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(m_value);
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(m_value);
        }

        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(m_value);
        }

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble(m_value);
        }

        Decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(m_value);
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            throw new InvalidCastException(String.Format(SR.InvalidCast_FromTo, "Byte", "DateTime"));
        }

        Object IConvertible.ToType(Type type, IFormatProvider provider)
        {
            return Convert.DefaultToType((IConvertible)this, type, provider);
        }
    }
}
