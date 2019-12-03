using System;
using System.Linq;
using System.Reflection;

namespace Rpg.Svn.Repository.Lib
{
    public static class Utils
    {
        public static bool IsPrimitive(this PropertyInfo p)
        {
            Type t = p.PropertyType;
            return new[] {
                typeof(string),
                typeof(String),
                typeof(char),
                typeof(byte),
                typeof(Byte),
                typeof(SByte),
                typeof(sbyte),
                typeof(ushort),
                typeof(short),
                typeof(Int16),
                typeof(UInt16),
                typeof(uint),
                typeof(int),
                typeof(Int32),
                typeof(UInt32),
                typeof(Int64),
                typeof(UInt64),
                typeof(ulong),
                typeof(long),
                typeof(float),
                typeof(double),
                typeof(Double),
                typeof(decimal),
                typeof(Decimal),
                typeof(DateTime),
                typeof(bool),
                typeof(Boolean),
                typeof(byte?),
                typeof(Byte?),
                typeof(SByte?),
                typeof(sbyte?),
                typeof(ushort?),
                typeof(short?),
                typeof(Int16?),
                typeof(UInt16?),
                typeof(uint?),
                typeof(int?),
                typeof(Int32?),
                typeof(UInt32?),
                typeof(Int64?),
                typeof(UInt64?),
                typeof(ulong?),
                typeof(long?),
                typeof(float?),
                typeof(double?),
                typeof(Double?),
                typeof(decimal?),
                typeof(Decimal?),
                typeof(DateTime?),
                typeof(bool?),
                typeof(Boolean?),
            }.Contains(t);
        }
    }
}
