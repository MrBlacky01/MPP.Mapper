using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperLibrary
{
    internal static class TypeChecker
    {
        public static bool Check(Type source, Type destination)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            var result = source == destination;

            if (result) return true;
            result = MemberPrimitevesChecker(source, destination);
            if (!result)
            {
                result = MembersRefferenceTypeChecker(source, destination);
            }

            return result;

        }
        private static bool MemberPrimitevesChecker(Type source, Type destination)
        {
            var result = false;
            if (source.IsValueType && source.IsPrimitive &&
                destination.IsValueType && destination.IsPrimitive )
            {
                result = MembersCompatibilityChecker(source,destination);
            }
            return result;

        }
        private static bool MembersRefferenceTypeChecker(Type source, Type destination)
        {
            var result = false;
            if (source.IsClass && !source.IsAbstract && destination.IsClass && !destination.IsAbstract)
            {
                result = destination.IsAssignableFrom(source);
            }
            return result;

        }

        private static bool MembersCompatibilityChecker(Type source, Type destination)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

            var sourceTypeCode = Type.GetTypeCode(source);
            var destTypeCode = Type.GetTypeCode(destination);
            switch (sourceTypeCode)
            {
                case TypeCode.Char:
                    switch (destTypeCode)
                    {
                        case TypeCode.UInt16:
                        case TypeCode.Int32:
                        case TypeCode.UInt32:
                        case TypeCode.Int64:
                        case TypeCode.UInt64:
                        case TypeCode.Single:
                        case TypeCode.Double:
                        case TypeCode.Decimal:
                            return true;
                    }
                    return false;

                case TypeCode.SByte:
                    switch (destTypeCode)
                    {
                        case TypeCode.Int16:
                        case TypeCode.Int32:
                        case TypeCode.Int64:
                        case TypeCode.Single:
                        case TypeCode.Double:
                        case TypeCode.Decimal:
                            return true;
                    }
                    break;

                case TypeCode.Byte:
                    switch (destTypeCode)
                    {
                        case TypeCode.Int16:
                        case TypeCode.UInt16:
                        case TypeCode.Int32:
                        case TypeCode.UInt32:
                        case TypeCode.Int64:
                        case TypeCode.UInt64:
                        case TypeCode.Single:
                        case TypeCode.Double:
                        case TypeCode.Decimal:
                            return true;
                    }
                    return false;

                case TypeCode.Int16:
                    switch (destTypeCode)
                    {
                        case TypeCode.Int32:
                        case TypeCode.Int64:
                        case TypeCode.Single:
                        case TypeCode.Double:
                        case TypeCode.Decimal:
                            return true;
                    }
                    return false;

                case TypeCode.UInt16:
                    switch (destTypeCode)
                    {
                        case TypeCode.Int32:
                        case TypeCode.UInt32:
                        case TypeCode.Int64:
                        case TypeCode.UInt64:
                        case TypeCode.Single:
                        case TypeCode.Double:
                        case TypeCode.Decimal:
                            return true;
                    }
                    return false;

                case TypeCode.Int32:
                    switch (destTypeCode)
                    {
                        case TypeCode.Int64:
                        case TypeCode.Single:
                        case TypeCode.Double:
                        case TypeCode.Decimal:
                            return true;
                    }
                    return false;

                case TypeCode.UInt32:
                    switch (destTypeCode)
                    {
                        case TypeCode.UInt32:
                        case TypeCode.UInt64:
                        case TypeCode.Single:
                        case TypeCode.Double:
                        case TypeCode.Decimal:
                            return true;
                    }
                    return false;

                case TypeCode.Int64:
                case TypeCode.UInt64:
                    switch (destTypeCode)
                    {
                        case TypeCode.Single:
                        case TypeCode.Double:
                        case TypeCode.Decimal:
                            return true;
                    }
                    return false;

                case TypeCode.Single:
                    return (destTypeCode == TypeCode.Double);
                default:
                    return false;
            }
            return false;
        }
    }
}
