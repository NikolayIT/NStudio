/*
 * --------------------------------------------------------------------------------
 * Copyright (c) 2006 Mark Gwilliam (aka MarkGwilliam.com)
 * 
 * --------------------------------------------------------------------------------
 * Licensed under the MIT license
 * 
 * See http://opensource.org/licenses/mit-license.php
 * 
 * --------------------------------------------------------------------------------
 * Permission is hereby granted, free of charge, to any person obtaining a copy of 
 * this software and associated documentation files (the "Software"), to deal in 
 * the Software without restriction, including without limitation the rights to 
 * use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies 
 * of the Software, and to permit persons to whom the Software is furnished to do 
 * so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all 
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS 
 * FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR 
 * COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER 
 * IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN 
 * CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 * 
 * --------------------------------------------------------------------------------
*/

using System;
using System.Text;

namespace NStudio
{
    #region Enums
    /// <summary>
    /// Indicates numbering scheme to use for number bases
    /// </summary>
    public enum NumberingSchemes
    {
        /// <summary>
        /// Alphabet based, from A to Z. 
        /// i.e. ABCDEFGHIJKLMNOPQRSTUVWXYZ.
        /// Not commonly used
        /// </summary>
        AToZ,

        /// <summary>
        /// Alphanumeric, from 0-9 then A-Z. 
        /// i.e. 0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ.
        /// Used in most bases including binary, octal, decimal and hexadecimal
        /// </summary>
        ZeroToZ
    }

    /// <summary>
    /// Common number bases used for conversions
    /// </summary>
    public enum NumberBases
    {
        /// <summary>
        /// Binary, base 2
        /// </summary>
        Binary = 2,

        /// <summary>
        /// Octal, base 8
        /// </summary>
        Octal = 8,

        /// <summary>
        /// Decimal, base 10
        /// </summary>
        Decimal = 10,

        /// <summary>
        /// Hexadecimal, base 16
        /// </summary>
        Hexadecimal = 16
    }

    #endregion

    /// <summary>
    /// Utility class to convert between number bases
    /// </summary>
    /// <example>
    /// Shows how to use the built in converters to convert from Hexadecimal
    /// to decimal:
    /// <code>
    /// string dec = Converter.HexToDec.Convert("FFFF");
    /// </code>
    /// Shows how to create a <see cref="Converter"/> instance to convert from
    /// Base 3 to Decimal using a zero based numbering system:
    /// <code>
    /// Converter o = Converter.Create(3);
    /// string value = o.Convert("210");
    /// </code>
    /// </example>
    /// <remarks>See unit tests for more examples</remarks>
    public class Converter
    {
        #region Fields & constants
        /// <summary>
        /// Number base to convert from
        /// </summary>
        private int _fromRadix;

        /// <summary>
        /// Numbering scheme to convert from
        /// </summary>
        private string _fromNumberingScheme;

        /// <summary>
        /// Number base to convert to
        /// </summary>
        private int _toRadix;

        /// <summary>
        /// Numbering scheme to convert to
        /// </summary>
        private string _toNumberingScheme;

        /// <summary>
        /// Maximum character allowed in numbering scheme converting from
        /// </summary>
        private int _maxFromSchemeCharacter;

        // static helper objects
        private static Converter _binToOct = new Converter(2, NumberingSchemes.ZeroToZ, 8, NumberingSchemes.ZeroToZ);
        private static Converter _binToDec = new Converter(2, NumberingSchemes.ZeroToZ, 10, NumberingSchemes.ZeroToZ);
        private static Converter _binToHex = new Converter(2, NumberingSchemes.ZeroToZ, 16, NumberingSchemes.ZeroToZ);
        private static Converter _octToBin = new Converter(8, NumberingSchemes.ZeroToZ, 2, NumberingSchemes.ZeroToZ);
        private static Converter _octToDec = new Converter(8, NumberingSchemes.ZeroToZ, 10, NumberingSchemes.ZeroToZ);
        private static Converter _octToHex = new Converter(8, NumberingSchemes.ZeroToZ, 16, NumberingSchemes.ZeroToZ);
        private static Converter _decToBin = new Converter(10, NumberingSchemes.ZeroToZ, 2, NumberingSchemes.ZeroToZ);
        private static Converter _decToOct = new Converter(10, NumberingSchemes.ZeroToZ, 8, NumberingSchemes.ZeroToZ);
        private static Converter _decToHex = new Converter(10, NumberingSchemes.ZeroToZ, 16, NumberingSchemes.ZeroToZ);
        private static Converter _hexToBin = new Converter(16, NumberingSchemes.ZeroToZ, 2, NumberingSchemes.ZeroToZ);
        private static Converter _hexToOct = new Converter(16, NumberingSchemes.ZeroToZ, 8, NumberingSchemes.ZeroToZ);
        private static Converter _hexToDec = new Converter(16, NumberingSchemes.ZeroToZ, 10, NumberingSchemes.ZeroToZ);

        #endregion

        #region Factory methods & constructors
        /// <summary>
        /// Factory method.
        /// Returns a new <see cref="Converter"/> to convert between a specified 
        /// number base and decimal using a zero based numbering scheme
        /// from
        /// <para>
        /// Assumes the numbering base to convert to decimal
        /// </para>
        /// </summary>
        /// <param name="fromRadix">Number base to convert from (1 to 36)</param>
        /// <returns>New instance</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if unsupported number base is specified for <paramref name="fromRadix"/>
        /// </exception>
        /// <example>
        /// Shows how to create a <see cref="Converter"/> instance to convert from
        /// Base 3 to Decimal using a zero based numbering system
        /// <code>
        /// Converter o = Converter.Create(3);
        /// string value = o.Convert("210");
        /// </code>
        /// </example>
        /// <remarks>This method should be used to create a <see cref="Converter"/> that is
        /// to be used many times by client code. For ad-hoc conversions, use the static class
        /// conversion methods</remarks>
        public static Converter Create(int fromRadix)
        {
            return new Converter(fromRadix, NumberingSchemes.ZeroToZ, 10, NumberingSchemes.ZeroToZ);
        }

        /// <summary>
        /// Factory method.
        /// Returns a new <see cref="Converter"/> to convert between a specified 
        /// number base and decimal using a zero based numbering scheme
        /// from
        /// <para>
        /// Assumes the numbering base to convert to decimal
        /// </para>
        /// </summary>
        /// <param name="fromRadix">Number base to convert from</param>
        /// <returns>New instance</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if unsupported number base is specified for <paramref name="fromRadix"/>
        /// </exception>
        /// <example>
        /// Shows how to create a <see cref="Converter"/> instance to convert from
        /// Base Octal to Decimal using a zero based numbering system
        /// <code>
        /// Converter o = Converter.Create(NumberBases.Octal);
        /// string value = o.Convert("210");
        /// </code>
        /// </example>
        /// <remarks>This method should be used to create a <see cref="Converter"/> that is
        /// to be used many times by client code. For ad-hoc conversions, use the static class
        /// conversion methods</remarks>
        public static Converter Create(NumberBases fromRadix)
        {
            return new Converter((int)fromRadix, NumberingSchemes.ZeroToZ, 10, NumberingSchemes.ZeroToZ);
        }

        /// <summary>
        /// Factory method.
        /// Returns a new <see cref="Converter"/> to convert between two different
        /// number bases both using a zero based numbering scheme
        /// </summary>
        /// <param name="fromRadix">Number base to convert from</param>
        /// <param name="toRadix">Number base to convert to</param>
        /// <returns>New instance</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if unsupported number bases are specified for <paramref name="fromRadix"/> or
        /// <paramref name="toRadix"/>
        /// </exception>
        /// <example>
        /// Shows how to create a <see cref="Converter"/> instance to convert from
        /// Decimal to Hexadecimal using zero based numbering schemes
        /// <code>
        /// Converter o = Converter.Create(NumberBases.Decimal, NumberBases.Hexadecimal);
        /// string value = o.Convert("9801");
        /// </code>
        /// </example>
        /// <remarks>This method should be used to create a <see cref="Converter"/> that is
        /// to be used many times by client code. For ad-hoc conversions, use the static class
        /// conversion methods</remarks>
        public static Converter Create(NumberBases fromRadix, NumberBases toRadix)
        {
            return new Converter((int)fromRadix, NumberingSchemes.ZeroToZ, (int)toRadix, NumberingSchemes.ZeroToZ);
        }

        /// <summary>
        /// Factory method.
        /// Returns a new <see cref="Converter"/> to convert between two different
        /// number bases both using a zero based numbering scheme
        /// </summary>
        /// <param name="fromRadix">Number base to convert from (1 to 36)</param>
        /// <param name="toRadix">Number base to convert to (1 to 36)</param>
        /// <returns>New instance</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if unsupported number bases are specified for <paramref name="fromRadix"/> or
        /// <paramref name="toRadix"/>
        /// </exception>
        /// <example>
        /// Shows how to create a <see cref="Converter"/> instance to convert from
        /// Decimal to Hexadecimal using zero based numbering schemes
        /// <code>
        /// Converter o = Converter.Create(10, 16);
        /// string value = o.Convert("9801");
        /// </code>
        /// </example>
        /// <remarks>This method should be used to create a <see cref="Converter"/> that is
        /// to be used many times by client code. For ad-hoc conversions, use the static class
        /// conversion methods</remarks>
        public static Converter Create(int fromRadix, int toRadix)
        {
            return new Converter(fromRadix, NumberingSchemes.ZeroToZ, toRadix, NumberingSchemes.ZeroToZ);
        }

        /// <summary>
        /// Factory method.
        /// Returns a new <see cref="Converter"/> to convert between two different
        /// number bases using the specified numbering schemes
        /// </summary>
        /// <param name="fromRadix">Number base to convert from</param>
        /// <param name="fromScheme">Numbering scheme to convert from</param>
        /// <param name="toRadix">Number base to convert to</param>
        /// <param name="toScheme">Numbering scheme to convert to</param>
        /// <returns>New instance</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if unsupported number bases are specified for <paramref name="fromRadix"/> or
        /// <paramref name="toRadix"/>
        /// </exception>
        /// <example>
        /// Shows how to create a <see cref="Converter"/> instance to convert from
        /// Base 8 to Hexadecimal using numbering schemes 0-9 and 0-Z respectively
        /// <code>
        /// Converter o = Converter.Create(NumberBases.Octal, NumberingSchemes.ZeroToZ, 
        ///     NumberBases.Binary, NumberingSchemes.ZeroToZ);
        /// string value = o.Convert("4321");
        /// </code>
        /// </example>
        /// <remarks>This method should be used to create a <see cref="Converter"/> that is
        /// to be used many times by client code. For ad-hoc conversions, use the static class
        /// conversion methods</remarks>
        public static Converter Create(NumberBases fromRadix, NumberingSchemes fromScheme, NumberBases toRadix, NumberingSchemes toScheme)
        {
            return new Converter((int)fromRadix, fromScheme, (int)toRadix, toScheme);
        }

        /// <summary>
        /// Factory method.
        /// Returns a new <see cref="Converter"/> to convert between two different
        /// number bases using the specified numbering schemes
        /// </summary>
        /// <param name="fromRadix">Number base to convert from (1 to 36)</param>
        /// <param name="fromScheme">Numbering scheme to convert from</param>
        /// <param name="toRadix">Number base to convert to (1 to 36)</param>
        /// <param name="toScheme">Numbering scheme to convert to</param>
        /// <returns>New instance</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if unsupported number bases are specified for <paramref name="fromRadix"/> or
        /// <paramref name="toRadix"/>
        /// </exception>
        /// <example>
        /// Shows how to create a <see cref="Converter"/> instance to convert from
        /// Base 5 to Hexadecimal using numbering schemes 0-9 and 0-Z respectively
        /// <code>
        /// Converter o = Converter.Create(5, NumberingSchemes.ZeroToZ, 16, NumberingSchemes.ZeroToZ);
        /// string value = o.Convert("4321");
        /// </code>
        /// </example>
        /// <remarks>This method should be used to create a <see cref="Converter"/> that is
        /// to be used many times by client code. For ad-hoc conversions, use the static class
        /// conversion methods</remarks>
        public static Converter Create(int fromRadix, NumberingSchemes fromScheme, int toRadix, NumberingSchemes toScheme)
        {
            return new Converter(fromRadix, fromScheme, toRadix, toScheme);
        }

        /// <summary>
        /// Factory method.
        /// Returns a new <see cref="Converter"/> to convert between two different
        /// number bases using the specified numbering schemes
        /// </summary>
        /// <param name="fromRadix">Number base to convert from (1 to 36)</param>
        /// <param name="fromScheme">Numbering scheme to convert from</param>
        /// <param name="toRadix">Number base to convert to</param>
        /// <param name="toScheme">Numbering scheme to convert to</param>
        /// <returns>New instance</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if unsupported number bases are specified for <paramref name="fromRadix"/> or
        /// <paramref name="toRadix"/>
        /// </exception>
        /// <example>
        /// Shows how to create a <see cref="Converter"/> instance to convert from
        /// Base 5 to Hexadecimal using numbering schemes 0-9 and 0-Z respectively
        /// <code>
        /// Converter o = Converter.Create(5, NumberingSchemes.ZeroToZ, 
        ///     NumberBases.Hexadecimal, NumberingSchemes.ZeroToZ);
        /// string value = o.Convert("4321");
        /// </code>
        /// </example>
        /// <remarks>This method should be used to create a <see cref="Converter"/> that is
        /// to be used many times by client code. For ad-hoc conversions, use the static class
        /// conversion methods</remarks>
        public static Converter Create(int fromRadix, NumberingSchemes fromScheme, NumberBases toRadix, NumberingSchemes toScheme)
        {
            return new Converter(fromRadix, fromScheme, (int)toRadix, toScheme);
        }

        /// <summary>
        /// Factory method.
        /// Returns a new <see cref="Converter"/> to convert between two different
        /// number bases using the specified numbering schemes
        /// </summary>
        /// <param name="fromRadix">Number base to convert from</param>
        /// <param name="fromScheme">Numbering scheme to convert from</param>
        /// <param name="toRadix">Number base to convert to (1 to 36)</param>
        /// <param name="toScheme">Numbering scheme to convert to</param>
        /// <returns>New instance</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if unsupported number bases are specified for <paramref name="fromRadix"/> or
        /// <paramref name="toRadix"/>
        /// </exception>
        /// <example>
        /// Shows how to create a <see cref="Converter"/> instance to convert from
        /// Base 8 to Hexadecimal using numbering schemes 0-9 and 0-Z respectively
        /// <code>
        /// Converter o = Converter.Create(NumberBases.Octal, NumberingSchemes.ZeroToZ, 
        ///     16, NumberingSchemes.ZeroToZ);
        /// string value = o.Convert("4321");
        /// </code>
        /// </example>
        /// <remarks>This method should be used to create a <see cref="Converter"/> that is
        /// to be used many times by client code. For ad-hoc conversions, use the static class
        /// conversion methods</remarks>
        public static Converter Create(NumberBases fromRadix, NumberingSchemes fromScheme, int toRadix, NumberingSchemes toScheme)
        {
            return new Converter((int)fromRadix, fromScheme, toRadix, toScheme);
        }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="fromRadix">Number base to convert from</param>
        /// <param name="fromScheme">Numbering scheme to convert from</param>
        /// <param name="toRadix">Number base to convert to</param>
        /// <param name="toScheme">Numbering scheme to convert to</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if unsupported number bases are specified for <paramref name="fromRadix"/> or
        /// <paramref name="toRadix"/>
        /// </exception>
        private Converter(int fromRadix, NumberingSchemes fromScheme, int toRadix, NumberingSchemes toScheme)
        {
            #region Validate arguments
            if (fromRadix < 2 || fromRadix > 36)
                throw new ArgumentOutOfRangeException("fromRadix", "Radix can be from 2 to 36 inclusive");
            if (toRadix < 2 || toRadix > 36)
                throw new ArgumentOutOfRangeException("toRadix", "Radix can be from 2 to 36 inclusive");
            if (fromRadix > 26 && fromScheme == NumberingSchemes.AToZ)
                throw new ArgumentOutOfRangeException("fromRadix", "Invalid numbering scheme for specified number base");
            if (toRadix > 26 && fromScheme == NumberingSchemes.AToZ)
                throw new ArgumentOutOfRangeException("toRadix", "Invalid numbering scheme for specified number base");

            #endregion

            _fromRadix = fromRadix;
            _fromNumberingScheme = GetCharactersForNumberingScheme(fromScheme);

            _toRadix = toRadix;
            _toNumberingScheme = GetCharactersForNumberingScheme(toScheme);

            // determine max character allowed in numbering scheme
            _maxFromSchemeCharacter = (fromScheme == NumberingSchemes.ZeroToZ) ? fromRadix : fromRadix + 1;
        }

        #endregion

        #region Public interface
        #region Class helpers
        /// <summary>
        /// Convert a number from the specified number base to decimal 
        /// using a zero based numbering scheme
        /// </summary>
        /// <param name="fromRadix">Number base to convert from</param>
        /// <param name="value">Value to convert</param>
        /// <returns>Converted value</returns>
        /// <exception cref="ArgumentNullException">Thrown for null arguments</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if unsupported number base is specified for <paramref name="fromRadix"/>
        /// </exception>
        /// <exception cref="FormatException">
        /// Thrown if the <paramref name="value"/> provided is in an invalid format for the
        /// specified number base to convert from</exception>
        /// <remarks>This method should for ad-hoc conversions. Use the 
        /// factory methods to create an instance for multiple conversions</remarks>
        public static string Convert(NumberBases fromRadix, string value)
        {
            return Convert((int)fromRadix, 10, value);
        }

        /// <summary>
        /// Convert a number from the specified number base to decimal 
        /// using a zero based numbering scheme
        /// </summary>
        /// <param name="fromRadix">Number base to convert from (1 to 36)</param>
        /// <param name="value">Value to convert</param>
        /// <returns>Converted value</returns>
        /// <exception cref="ArgumentNullException">Thrown for null arguments</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if unsupported number base is specified for <paramref name="fromRadix"/>
        /// </exception>
        /// <exception cref="FormatException">
        /// Thrown if the <paramref name="value"/> provided is in an invalid format for the
        /// specified number base to convert from</exception>
        /// <remarks>This method should for ad-hoc conversions. Use the 
        /// factory methods to create an instance for multiple conversions</remarks>
        public static string Convert(int fromRadix, string value)
        {
            return Convert(fromRadix, 10, value);
        }

        /// <summary>
        /// Convert a number from the specified number base to the specified number base
        /// using a zero based numbering scheme
        /// </summary>
        /// <param name="fromRadix">Number base to convert from</param>
        /// <param name="toRadix">Number base to convert to</param>
        /// <param name="value">Value to convert</param>
        /// <returns>Converted value</returns>
        /// <exception cref="ArgumentNullException">Thrown for null arguments</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if unsupported number bases are specified for <paramref name="fromRadix"/> or
        /// <paramref name="toRadix"/>
        /// </exception>
        /// <exception cref="FormatException">
        /// Thrown if the <paramref name="value"/> provided is in an invalid format for the
        /// specified number base to convert from</exception>
        /// <remarks>This method should for ad-hoc conversions. Use the 
        /// factory methods to create an instance for multiple conversions</remarks>
        public static string Convert(NumberBases fromRadix, NumberBases toRadix, string value)
        {
            return Convert((int)fromRadix, NumberingSchemes.ZeroToZ, (int)toRadix, NumberingSchemes.ZeroToZ, value);
        }

        /// <summary>
        /// Convert a number from the specified number base to the specified number base
        /// using a zero based numbering scheme
        /// </summary>
        /// <param name="fromRadix">Number base to convert from</param>
        /// <param name="toRadix">Number base to convert to (1 to 36)</param>
        /// <param name="value">Value to convert</param>
        /// <returns>Converted value</returns>
        /// <exception cref="ArgumentNullException">Thrown for null arguments</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if unsupported number bases are specified for <paramref name="fromRadix"/> or
        /// <paramref name="toRadix"/>
        /// </exception>
        /// <exception cref="FormatException">
        /// Thrown if the <paramref name="value"/> provided is in an invalid format for the
        /// specified number base to convert from</exception>
        /// <remarks>This method should for ad-hoc conversions. Use the 
        /// factory methods to create an instance for multiple conversions</remarks>
        public static string Convert(NumberBases fromRadix, int toRadix, string value)
        {
            return Convert((int)fromRadix, NumberingSchemes.ZeroToZ, toRadix, NumberingSchemes.ZeroToZ, value);
        }

        /// <summary>
        /// Convert a number from the specified number base to the specified number base
        /// using a zero based numbering scheme
        /// </summary>
        /// <param name="fromRadix">Number base to convert from (1 to 36)</param>
        /// <param name="toRadix">Number base to convert to (1 to 36)</param>
        /// <param name="value">Value to convert</param>
        /// <returns>Converted value</returns>
        /// <exception cref="ArgumentNullException">Thrown for null arguments</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if unsupported number bases are specified for <paramref name="fromRadix"/> or
        /// <paramref name="toRadix"/>
        /// </exception>
        /// <exception cref="FormatException">
        /// Thrown if the <paramref name="value"/> provided is in an invalid format for the
        /// specified number base to convert from</exception>
        /// <remarks>This method should for ad-hoc conversions. Use the 
        /// factory methods to create an instance for multiple conversions</remarks>
        public static string Convert(int fromRadix, int toRadix, string value)
        {
            return Convert(fromRadix, NumberingSchemes.ZeroToZ, toRadix, NumberingSchemes.ZeroToZ, value);
        }

        /// <summary>
        /// Convert a number from the specified number base to the specified number base using the 
        /// specified numbering schemes
        /// </summary>
        /// <param name="fromRadix">Number base to convert from</param>
        /// <param name="fromScheme">Numbering scheme to convert from</param>
        /// <param name="toRadix">Number base to convert to</param>
        /// <param name="toScheme">Numbering scheme to convert to</param>
        /// <param name="value">Value to convert</param>
        /// <returns>Converted value</returns>
        /// <exception cref="ArgumentNullException">Thrown for null arguments</exception>
        /// <remarks>This method should for ad-hoc conversions. Use the 
        /// factory methods to create an instance for multiple conversions</remarks>
        public static string Convert(NumberBases fromRadix, NumberingSchemes fromScheme, NumberBases toRadix, NumberingSchemes toScheme, string value)
        {
            return Convert((int)fromRadix, fromScheme, (int)toRadix, toScheme, value);
        }

        /// <summary>
        /// Convert a number from the specified number base to the specified number base using the 
        /// specified numbering schemes
        /// </summary>
        /// <param name="fromRadix">Number base to convert from (1 to 36)</param>
        /// <param name="fromScheme">Numbering scheme to convert from</param>
        /// <param name="toRadix">Number base to convert to</param>
        /// <param name="toScheme">Numbering scheme to convert to</param>
        /// <param name="value">Value to convert</param>
        /// <returns>Converted value</returns>
        /// <exception cref="ArgumentNullException">Thrown for null arguments</exception>
        /// <remarks>This method should for ad-hoc conversions. Use the 
        /// factory methods to create an instance for multiple conversions</remarks>
        public static string Convert(NumberBases fromRadix, NumberingSchemes fromScheme, int toRadix, NumberingSchemes toScheme, string value)
        {
            return Convert((int)fromRadix, fromScheme, toRadix, toScheme, value);
        }

        /// <summary>
        /// Convert a number from the specified number base to the specified number base using the 
        /// specified numbering schemes
        /// </summary>
        /// <param name="fromRadix">Number base to convert from</param>
        /// <param name="fromScheme">Numbering scheme to convert from</param>
        /// <param name="toRadix">Number base to convert to (1 to 36)</param>
        /// <param name="toScheme">Numbering scheme to convert to</param>
        /// <param name="value">Value to convert</param>
        /// <returns>Converted value</returns>
        /// <exception cref="ArgumentNullException">Thrown for null arguments</exception>
        /// <remarks>This method should for ad-hoc conversions. Use the 
        /// factory methods to create an instance for multiple conversions</remarks>
        public static string Convert(int fromRadix, NumberingSchemes fromScheme, NumberBases toRadix, NumberingSchemes toScheme, string value)
        {
            return Convert(fromRadix, fromScheme, (int)toRadix, toScheme, value);
        }

        /// <summary>
        /// Convert a number from the specified number base to the specified number base using the 
        /// specified numbering schemes
        /// </summary>
        /// <param name="fromRadix">Number base to convert from (1 to 36)</param>
        /// <param name="fromScheme">Numbering scheme to convert from</param>
        /// <param name="toRadix">Number base to convert to (1 to 36)</param>
        /// <param name="toScheme">Numbering scheme to convert to</param>
        /// <param name="value">Value to convert</param>
        /// <returns>Converted value</returns>
        /// <exception cref="ArgumentNullException">Thrown for null arguments</exception>
        /// <remarks>This method should for ad-hoc conversions. Use the 
        /// factory methods to create an instance for multiple conversions</remarks>
        public static string Convert(int fromRadix, NumberingSchemes fromScheme, int toRadix, NumberingSchemes toScheme, string value)
        {
            // note, arguments are validated elsewhere

            Converter converter = new Converter(fromRadix, fromScheme, toRadix, toScheme);

            return converter.Convert(value);
        }

        #endregion

        #region Class properties
        /// <summary>
        /// <see cref="Converter"/> for converting between
        /// Binary and Octal
        /// </summary>
        public static Converter BinToOct
        {
            get { return _binToOct; }
        }

        /// <summary>
        /// <see cref="Converter"/> for converting between
        /// Binary and Decimal
        /// </summary>
        public static Converter BinToDec
        {
            get { return _binToDec; }
        }

        /// <summary>
        /// <see cref="Converter"/> for converting between
        /// Binary and Hexadecimal
        /// </summary>
        public static Converter BinToHex
        {
            get { return _binToHex; }
        }

        /// <summary>
        /// <see cref="Converter"/> for converting between
        /// Octal and Binary
        /// </summary>
        public static Converter OctToBin
        {
            get { return _octToBin; }
        }

        /// <summary>
        /// <see cref="Converter"/> for converting between
        /// Octal and Decimal
        /// </summary>
        public static Converter OctToDec
        {
            get { return _octToDec; }
        }

        /// <summary>
        /// <see cref="Converter"/> for converting between
        /// Octal and Hexadecimal
        /// </summary>
        public static Converter OctToHex
        {
            get { return _octToHex; }
        }

        /// <summary>
        /// <see cref="Converter"/> for converting between
        /// Decimal and Binary 
        /// </summary>
        public static Converter DecToBin
        {
            get { return _decToBin; }
        }

        /// <summary>
        /// <see cref="Converter"/> for converting between
        /// Decimal and Octal
        /// </summary>
        public static Converter DecToOct
        {
            get { return _decToOct; }
        }

        /// <summary>
        /// <see cref="Converter"/> for converting between
        /// Binary and Hexadecimal
        /// </summary>
        public static Converter DecToHex
        {
            get { return _decToHex; }
        }

        /// <summary>
        /// <see cref="Converter"/> for converting between
        /// Hexadecimal and Binary 
        /// </summary>
        public static Converter HexToBin
        {
            get { return _hexToBin; }
        }

        /// <summary>
        /// <see cref="Converter"/> for converting between
        /// Hexadecimal and Octal
        /// </summary>
        public static Converter HexToOct
        {
            get { return _hexToOct; }
        }

        /// <summary>
        /// <see cref="Converter"/> for converting between
        /// Hexadecimal and Decimal
        /// </summary>
        public static Converter HexToDec
        {
            get { return _hexToDec; }
        }

        #endregion

        #region Instance helpers
        /// <summary>
        /// Converts the specified value between the number bases specified
        /// when creating this converter
        /// </summary>
        /// <param name="value">Number in the <see cref="Converter.From"/> number 
        /// base format</param>
        /// <returns>Converted value</returns>
        /// <exception cref="ArgumentNullException">Thrown for null arguments</exception>
        /// <exception cref="FormatException">
        /// Thrown if the <paramref name="value"/> provided is in an invalid format 
        /// for the specified number base and numbering system to convert from
        /// </exception>
        public string Convert(string value)
        {
            #region Validate arguments
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("value");

            #endregion

            long temp = ConvertToBase10(value, _fromRadix, _fromNumberingScheme, _maxFromSchemeCharacter);

            // if converting to base 10 bail out now
            if (_toRadix == 10)
                return temp.ToString();
            else
                return ConvertFromBase10(temp, _toRadix, _toNumberingScheme);
        }

        #endregion

        #region Instance properties
        /// <summary>
        /// Number base this converter converts from
        /// </summary>
        public int From
        {
            get { return _fromRadix; }
        }

        /// <summary>
        /// Number base this converter converts from
        /// </summary>
        public int To
        {
            get { return _toRadix; }
        }

        #endregion

        #endregion

        #region Helpers
        /// <summary>
        /// Returns characters to be used in the specified numbering scheme
        /// </summary>
        /// <param name="scheme">Numbering scheme to return</param>
        /// <returns>String of characters</returns>
        private static string GetCharactersForNumberingScheme(NumberingSchemes scheme)
        {
            string characters;

            switch (scheme)
            {
                case NumberingSchemes.AToZ:
                    characters = "_ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    break;

                case NumberingSchemes.ZeroToZ:
                    characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    break;

                default:
                    throw new ArgumentOutOfRangeException("scheme");
            }

            return characters;
        }

        /// <summary>
        /// Converts the specified value to base 10
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="fromBase">Base to convert from</param>
        /// <param name="characters">Characters used in specified number base</param>
        /// <param name="maxFromSchemeCharacter">Maximum character allowed in 
        /// numbering scheme converting from</param>
        /// <returns>Converted value in base 10</returns>
        /// <exception cref="OverflowException">Thrown if the number passed in
        /// is too large to be converted to a <see cref="long"/></exception>
        private static long ConvertToBase10(string value, int fromBase, string characters, int maxFromSchemeCharacter)
        {
            StringBuilder fromValue = new StringBuilder(value);

            int power = 0;
            long result = 0;

            while (fromValue.Length > 0)
            {
                int index = Array.IndexOf<char>(characters.ToCharArray(), fromValue[fromValue.Length - 1]);

                // check if character not in numbering scheme
                if (index < 0)
                    throw new FormatException("Unsupported character in value string");

                // check if character is legal for number base and numbering scheme
                if (index >= maxFromSchemeCharacter)
                    throw new FormatException("Value contains character not valid for number base");

                result += (index * (long)Math.Pow(fromBase, power));

                // overflow check
                if (result < 0)
                    throw new OverflowException();

                fromValue.Length--;

                power++;
            }

            return result;
        }

        /// <summary>
        /// Converts from base 10 to the specified base using the specified characters
        /// </summary>
        /// <param name="value">Base 10 value to convert from</param>
        /// <param name="toBase">Base to convert to</param>
        /// <param name="characters">Characters used in specified number base</param>
        /// <returns>Converted value in the specified number base</returns>
        private static string ConvertFromBase10(long value, int toBase, string characters)
        {
            StringBuilder builder = new StringBuilder();

            while (value > 0)
            {
                int remainder = (int)(value % toBase);

                builder.Insert(0, characters[remainder]);

                value /= toBase;
            }

            return builder.ToString();
        }

        #endregion

    }

}
