using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace AATM.Libraries.GlobalFuncNSub
{
    public static class Extensions
    {
        // Declarations will typically be in a separate module.

        public static object Right(this string stringValue, int noOfCharacters)
        {
            int strLength = stringValue.Length;
            return stringValue.Substring(strLength - noOfCharacters);
        }

        public static string Interpolate(this string template, params Expression<Func<object, string>>[] values)
        {
            string result = template;
            values.ToList().ForEach(x =>
            {
                MemberExpression member = x.Body as MemberExpression;
                string oldValue = string.Format("{0}{1}{2}", "{", Strings.Left(member.Member.Name, 10) == "$VB$Local_" ? Strings.Mid(member.Member.Name, 11) : member.Member.Name, "}");
                string newValue = x.Compile().Invoke(null).ToString();
                result = Strings.Replace(result, oldValue, newValue, 1, -1, CompareMethod.Text);
            });
            return result;
        }

        public static string ReplaceValues(this string template, string[] variables)
        {
            string result = template;
            string oldValue;
            string newValue;
            for (int i = 0, loopTo = variables.Count() - 1; i <= loopTo; i += 2)
            {
                oldValue = "{" + variables[i] + "}";
                newValue = variables[i + 1];
                result = Strings.Replace(result, oldValue, newValue, 1, -1, CompareMethod.Text);
            }

            return result;
        }

        public static DateTime TrimMilliseconds(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, 0, dt.Kind);
        }

        public static string ToMoney(this decimal number, short noOfDigits)
        {
            string cFormat = "C" + noOfDigits.ToString();
            return number.ToString(cFormat, new CultureInfo(GlobalFuncNSub.GlobalVariables.AppCurrentCultureInfo.Name));
        }

        public static string ToMoney(this float number, short noOfDigits)
        {
            string cFormat = "C" + noOfDigits.ToString();
            return number.ToString(cFormat, new CultureInfo(GlobalFuncNSub.GlobalVariables.AppCurrentCultureInfo.Name));
        }

        public static string ToMoney(this float number)
        {
            return number.ToString("C", new CultureInfo(GlobalFuncNSub.GlobalVariables.AppCurrentCultureInfo.Name));
        }

        // <Extension()>
        public static string ToMoney(double number)
        {
            return number.ToString("C", new CultureInfo(GlobalFuncNSub.GlobalVariables.AppCurrentCultureInfo.Name));
        }

        public static short ToInt16Number(this string numberString)
        {
            if (numberString is object && !string.IsNullOrEmpty(numberString.Trim()))
            {
                return Convert.ToInt16(NumParser<short>(ref numberString));
            }
            else
            {
                return 0;
            }
        }

        public static int ToInt32Number(this string numberString)
        {
            if (numberString is object && !string.IsNullOrEmpty(numberString.Trim()))
            {
                return Convert.ToInt32(NumParser<int>(ref numberString));
            }
            else
            {
                return 0;
            }
        }

        public static long ToInt64Number(this string numberString)
        {
            if (numberString is object && !string.IsNullOrEmpty(numberString.Trim()))
            {
                return Convert.ToInt64(NumParser<long>(ref numberString));
            }
            else
            {
                return 0L;
            }
        }

        public static byte ToByteNumber(this string numberString)
        {
            if (numberString is object && !string.IsNullOrEmpty(numberString.Trim()))
            {
                return Convert.ToByte(NumParser<byte>(ref numberString));
            }
            else
            {
                return (byte)0m;
            }
        }

        public static decimal ToDecimalNumber(this string numberString, NumberFormatInfo nfi)
        {
            if (numberString is object && !string.IsNullOrEmpty(numberString.Trim()))
            {
                return Convert.ToDecimal((object)NumParser<decimal>(ref numberString), nfi);
            }
            else
            {
                return 0m;
            }
        }

        public static float ToSingleNumber(this string numberString, NumberFormatInfo nfi)
        {
            if (numberString is object && !string.IsNullOrEmpty(numberString.Trim()))
            {
                return Convert.ToSingle((object)NumParser<float>(ref numberString), nfi);
            }
            else
            {
                return 0f;
            }
        }

        public static double ToDoubleNumber(this string numberString, NumberFormatInfo nfi)
        {
            if (numberString is object && !string.IsNullOrEmpty(numberString.Trim()))
            {
                return Convert.ToDouble((object)NumParser<double>(ref numberString), nfi);
            }
            else
            {
                return 0d;
            }
        }

        public static string SplitCamelCase(this string str)
        {
            return Regex.Replace(Regex.Replace(str, @"(\P{Ll})(\P{Ll}\p{Ll})", "$1 $2"), @"(\p{Ll})(\P{Ll})", "$1 $2");
        }

        // <Extension()>
        // Public Function IgnoreAllNonExisting(Of TSource, TDestination)(ByVal expression As IMappingExpression(Of TSource, TDestination)) As IMappingExpression(Of TSource, TDestination)
        // Dim sourceType = GetType(TSource)
        // Dim destinationType = GetType(TDestination)
        // Dim allTypes = GlobalVariables.Mapper.ConfigurationProvider.GetAllTypeMaps()
        // Dim existingMaps = allTypes.First(Function(x) (x.SourceType Is sourceType) AndAlso (x.DestinationType Is destinationType))

        // For Each [property] In existingMaps.GetUnmappedPropertyNames()
        // expression.ForMember([property], Sub(opt) opt.Ignore())
        // Next

        // Return expression
        // End Function

        // <Extension()>
        // Public Function AddBusinessDays(ByVal startDate As DateTime, ByVal days As Integer) As DateTime
        // Dim sign As Double = Convert.ToDouble(Math.Sign(days))
        // Dim unsignedDays As Integer = Math.Sign(days) * days

        // For i As Integer = 0 To unsignedDays - 1

        // Do
        // startDate = startDate.AddDays(sign)
        // Loop While startDate.DayOfWeek = DayOfWeek.Saturday OrElse startDate.DayOfWeek = DayOfWeek.Sunday
        // Next

        // Return startDate
        // End Function

        public static string GetAttribute<T>(this object enumerationValue) where T : struct
        {
            var type = enumerationValue.GetType();
            if (!type.IsEnum)
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            var memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo is object && memberInfo.Length > 0)
            {
                var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs is object && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return enumerationValue.ToString();
        }

        public static T GetAttributeOfType<T>(this Enum enumVal) where T : Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return attributes.Length > 0 ? (T)attributes[0] : null;
        }
    }
}

// Public Function MakePlural( noun As String) As String
// Dim pluralName As String
// Dim lastLetter = noun.Right(1).ToLower()
// Select Case lastLetter
// Case "a","b","c","d","g","i","j","k","l","m","n","p","q","r","t","u","v","w"
// pluralName = noun + "s"
// Case "o"
// pluralName = noun + "es"
// Case Else

// End Select

// If lastTwoLetters
// noun = noun.Substring(0,noun.Length-1) + "ie"
// pluralname = noun + "s"
// Elseif noun.Right(1).ToLower() = "s" Then
// noun = noun.Substring(0,noun.Length-1) + "e"
// pluralname = noun + "s"
// End If
// Return noun
// End Function