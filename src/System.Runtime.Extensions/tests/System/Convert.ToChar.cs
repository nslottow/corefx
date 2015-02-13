//
// Copyright (c) Microsoft Corporation. All rights reserved.
// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
//
// Convert_ToChar_all.cs
//
// Summary:
// Tests Convert.ToChar().
//
// \qa\clr\testsrc\CoreMangLib\BCL\System\Convert:
// Co6055ToChar_all.cs
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
using CoreFXTestLibrary;
using System;

namespace Test
{
    [ContractsRequired("System.Runtime, System.Runtime.Extensions")]
    public class Co6055ToChar_all
    {
        [TestMethod]
        public static void runTest()
        {
            ///////////////////////////////////////////// Char Convert.ToChar( Int32 )

            //[] ToChar(Int32) - Vanilla Cases ((Int32)Char.MaxValue,(Int32)Char.MinValue)

            // Setup Int32 Test
            {
                Int32[] testValues = { (Int32)Char.MaxValue, (Int32)Char.MinValue, };
                Char[] expectedValues = { Char.MaxValue, Char.MinValue, };
                // Vanila Test Cases
                for (int i = 0; i < testValues.Length; i++)
                {
                    Char result = Convert.ToChar(testValues[i]);
                    Assert.AreEqual(expectedValues[i], result, " Expected = '" + expectedValues[i] + "' ... Received = '" + result + "'.");
                }
            }

            ////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////// Char Convert.ToChar( String )

            //[] ToChar(String) - Vanilla Cases ("a","T","z","a")

            // Setup String Test
            {
                String[] testValues = { "a", "T", "z", "a", };
                Char[] expectedValues = { 'a', 'T', 'z', 'a', };
                // Vanila Test Cases
                for (int i = 0; i < testValues.Length; i++)
                {
                    Char result = Convert.ToChar(testValues[i]);
                    Assert.AreEqual(expectedValues[i], result, " Expected = '" + expectedValues[i] + "' ... Received = '" + result + "'.");
                }
            }
            ///////////////////////////////////////////// Char Convert.ToChar( String, IFormatPRovider ) - IFP is ignored here

            //[] ToChar(String) - Vanilla Cases ("a","T","z","a")

            // Setup String Test
            {
                String[] testValues = { "a", "T", "z", "a", };
                Char[] expectedValues = { 'a', 'T', 'z', 'a', };
                // Vanila Test Cases
                for (int i = 0; i < testValues.Length; i++)
                {
                    Char result = Convert.ToChar(testValues[i], new TestFormatProvider());
                    Assert.AreEqual(expectedValues[i], result, " Expected = '" + expectedValues[i] + "' ... Received = '" + result + "'.");
                }
            }

            ///////////////////////////////////////////// Char Convert.ToChar( Int16 )

            //[] ToChar(Int16) - Vanilla Cases (Int16.MaxValue ,0)

            // Setup Int16 Test
            {

                Int16[] testValues = { Int16.MaxValue, 0, };
                Char[] expectedValues = { (Char)Int16.MaxValue, (Char)0, };
                // Vanila Test Cases
                for (int i = 0; i < testValues.Length; i++)
                {
                    Char result = Convert.ToChar(testValues[i]);
                    Assert.AreEqual(expectedValues[i], result, " Expected = '" + expectedValues[i] + "' ... Received = '" + result + "'.");
                }
            }

            ///////////////////////////////////////////// Char Convert.ToChar( Byte )

            //[] ToChar(Byte) - Vanilla Cases (Byte.MaxValue ,Byte.MinValue)

            // Setup Byte Test
            {
                // (unused) 
                Byte[] testValues = { Byte.MaxValue, Byte.MinValue, };
                Char[] expectedValues = { (Char)Byte.MaxValue, (Char)Byte.MinValue, };
                // Vanila Test Cases
                for (int i = 0; i < testValues.Length; i++)
                {
                    Char result = Convert.ToChar(testValues[i]);
                    Assert.AreEqual(expectedValues[i], result, " Expected = '" + expectedValues[i] + "' ... Received = '" + result + "'.");
                }
            }

            ///////////////////////////////////////////// Char Convert.ToChar( SByte )

            //[] ToChar(SByte) - Vanilla Cases (SByte.MaxValue, 0)

            // Setup SByte Test
            {
                SByte[] testValues = { SByte.MaxValue, 0, };
                Char[] expectedValues = { (Char)SByte.MaxValue, (Char)0, };
                // Vanila Test Cases
                for (int i = 0; i < testValues.Length; i++)
                {
                    Char result = Convert.ToChar(testValues[i]);
                    Assert.AreEqual(expectedValues[i], result, " Expected = '" + expectedValues[i] + "' ... Received = '" + result + "'.");
                }
            }

            ///////////////////////////////////////////// Char Convert.ToChar( UInt32 )

            //[] ToChar(UInt32) - Vanilla Cases (UInt16.MaxValue, 0)

            // Setup UInt32 Test

            {
                UInt32[] testValues = { UInt16.MaxValue, 0, };
                Char[] expectedValues = { (Char)UInt16.MaxValue, (Char)0, };
                // Vanila Test Cases
                for (int i = 0; i < testValues.Length; i++)
                {
                    Char result = Convert.ToChar(testValues[i]);
                    Assert.AreEqual(expectedValues[i], result, " Expected = '" + expectedValues[i] + "' ... Received = '" + result + "'.");
                }
            }


            ///////////////////////////////////////////// Char Convert.ToChar( Char )

            //[] ToChar(Char) - Vanilla Cases (Char.MaxValue, Char.MinValue, Char.Empty, 'b')

            // Setup Char Test
            {

                Char[] testValues = { Char.MaxValue, Char.MinValue, 'b' };
                Char[] expectedValues = { Char.MaxValue, Char.MinValue, 'b' };

                // Vanila Test Cases
                for (int i = 0; i < testValues.Length; i++)
                {
                    Char result = Convert.ToChar(testValues[i]);
                    Assert.AreEqual(expectedValues[i], result, " Expected = '" + expectedValues[i] + "' ... Received = '" + result + "'.");
                }
            }

            ///////////////////////////////////////////// Char Convert.ToChar( UInt16 )

            //[] ToChar(UInt16) - Vanilla Cases (0, 98, UInt16.MaxValue)

            // Setup Char Test
            {
                UInt16[] testValues = { 0, 98, UInt16.MaxValue };
                Char[] expectedValues = { (Char)0, 'b', Char.MaxValue };

                // Vanila Test Cases
                for (int i = 0; i < testValues.Length; i++)
                {
                    Char result = Convert.ToChar(testValues[i]);
                    Assert.AreEqual(expectedValues[i], result, " Expected = '" + expectedValues[i] + "' ... Received = '" + result + "'.");
                }
            }

            ///////////////////////////////////////////// Char Convert.ToChar( Int64 )

            //[] ToChar(Int64) - Vanilla Cases (0, 98, (Int64) UInt16.MaxValue)

            // Setup Char Test

            {

                Int64[] testValues = { 0, 98, UInt16.MaxValue };
                Char[] expectedValues = { (Char)0, 'b', Char.MaxValue };

                // Vanila Test Cases
                for (int i = 0; i < testValues.Length; i++)
                {
                    Char result = Convert.ToChar(testValues[i]);
                    Assert.AreEqual(expectedValues[i], result, " Expected = '" + expectedValues[i] + "' ... Received = '" + result + "'.");
                }
            }

            ///////////////////////////////////////////// Char Convert.ToChar( UInt64 )

            //[] ToChar(UInt64) - Vanilla Cases (0, 98, (UInt64) UInt16.MaxValue)

            // Setup Char Test
            {

                UInt64[] testValues = { 0, 98, UInt16.MaxValue };
                Char[] expectedValues = { (Char)0, 'b', Char.MaxValue };

                // Vanila Test Cases
                for (int i = 0; i < testValues.Length; i++)
                {
                    Char result = Convert.ToChar(testValues[i]);
                    Assert.AreEqual(expectedValues[i], result, " Expected = '" + expectedValues[i] + "' ... Received = '" + result + "'.");
                }
            }

            ///////////////////////////////////////////// Char Convert.ToChar( Object )
            //[] ToChar( Object ) - obj = null
            {
                Char bTest = Convert.ToChar((Object)null);
                Assert.AreEqual('\0', bTest, " wrong value returned.  expected '\\0', got " + bTest);
            }
            ///////////////////////////////////////////// []Char Convert.ToChar( Object, IFormatProvider )

            //[] ToChar( Object, IFP ) - obj = null
            {
                Char bTest = Convert.ToChar((Object)null, new TestFormatProvider());
                Assert.AreEqual('\0', bTest, " wrong value returned.  expected '\\0', got " + bTest);
            }

        }

        [TestMethod]
        public static void runTest_Negative()
        {
            // Exception Test Case
            //[] ToChar(Int32) - Exception Cases (Int32.MaxValue)
            Assert.Throws<OverflowException>(() => { Char result = Convert.ToChar(Int32.MaxValue); }, " Exception not Thrown!");

            // Exception Test Case
            //[] ToChar(Int32) - Exception Cases (-1000)
            Assert.Throws<OverflowException>(() => { Char result = Convert.ToChar(-1000); }, " Exception not Thrown!");
            // Exception Test Case
            //[] ToChar(String) - Exception Cases (null)
            Assert.Throws<ArgumentNullException>(() => { Char result = Convert.ToChar(null); }, " Exception not Thrown!");

            // Exception Test Case
            //[] ToChar(String) - Exception Cases ("")
            Assert.Throws<FormatException>(() => { Char result = Convert.ToChar(""); }, " Exception not Thrown!");// Exception Test Case

            //[] ToChar(String) - Exception Cases (null)
            Assert.Throws<ArgumentNullException>(() => { Char result = Convert.ToChar(null, new TestFormatProvider()); }, " Exception not Thrown!");

            // Exception Test Case
            //[] ToChar(String) - Exception Cases ("")
            Assert.Throws<FormatException>(() => { Char result = Convert.ToChar("", new TestFormatProvider()); }, " Exception not Thrown!");
            Assert.Throws<FormatException>(() => { Char result = Convert.ToChar("ab", new TestFormatProvider()); }, " Exception not Thrown!");// Exception Test Case

            //[] ToChar(Int16) - Exception Cases (Int16.MinValue)
            Assert.Throws<OverflowException>(() => { Char result = Convert.ToChar(Int16.MinValue); }, " Exception not Thrown!");

            // Exception Test Case
            //[] ToChar(Int16) - Exception Cases (-1000)
            Assert.Throws<OverflowException>(() => { Char result = Convert.ToChar((Int16)(-1000)); }, " Exception not Thrown!");// Exception Test Case

            //[] ToChar(SByte) - Exception Cases (SByte.MinValue)
            Assert.Throws<OverflowException>(() => { Char result = Convert.ToChar(SByte.MinValue); }, " Exception not Thrown!");

            // Exception Test Case
            //[] ToChar(SByte) - Exception Cases (-100)
            Assert.Throws<OverflowException>(() => { Char result = Convert.ToChar((SByte)(-100)); }, " Exception not Thrown!");

            // Exception Test Case
            //[] ToChar(SByte) - Exception Cases (-1)
            Assert.Throws<OverflowException>(() => { Char result = Convert.ToChar((SByte)(-1)); }, " Exception not Thrown!");

            // Exception Test Case
            //[] ToChar(UInt32) - Exception Cases (UInt32.MaxValue)
            Assert.Throws<OverflowException>(() => { Char result = Convert.ToChar(UInt32.MaxValue); }, " Exception not Thrown!");

            // Exception Test Case
            //[] ToChar(UInt32) - Exception Cases (UInt32.MaxValue)
            Assert.Throws<OverflowException>(() => { Char result = Convert.ToChar(UInt32.MaxValue); }, " Exception not Thrown!");

            // Exception Test Case
            //[] ToChar(Int64) - Exception Cases (UInt16.MaxValue + 1)
            Assert.Throws<OverflowException>(() => { Char result = Convert.ToChar((Int64)(UInt16.MaxValue + 1)); }, " Exception not Thrown!");

            // Exception Test Case
            //[] ToChar(Int64) - Exception Cases (-1)
            Assert.Throws<OverflowException>(() => { Char result = Convert.ToChar((Int64)(-1)); }, " Exception not Thrown!");

            // Exception Test Case
            //[] ToChar(UInt64) - Exception Cases (UInt16.MaxValue + 1)
            Assert.Throws<OverflowException>(() => { Char result = Convert.ToChar((UInt64)(UInt16.MaxValue + 1)); }, " Exception not Thrown!");

            ///////////////////////////////////////////// Char Convert.ToChar( Single )

            //[] ToChar(Single) - Exception Cases (0,Single.MaxValue,Single.MinValue)

            // Setup Char Test

            {
                // Exception Test Case
                Assert.Throws<InvalidCastException>(() => { Char result = Convert.ToChar((Single)(0)); }, " Exception not Thrown!");
                // Exception Test Case
                Assert.Throws<InvalidCastException>(() => { Char result = Convert.ToChar(Single.MinValue); }, " Exception not Thrown!");
                // Exception Test Case
                Assert.Throws<InvalidCastException>(() => { Char result = Convert.ToChar(Single.MaxValue); }, " Exception not Thrown!");
            }

            ///////////////////////////////////////////// Char Convert.ToChar( Double )

            //[] ToChar(Double) - Exception Cases (0,Double.MaxValue,Double.MinValue)

            // Setup Char Test
            {
                // Exception Test Case
                Assert.Throws<InvalidCastException>(() => { Char result = Convert.ToChar((Double)(0)); }, " Exception not Thrown!");

                // Exception Test Case
                Assert.Throws<InvalidCastException>(() => { Char result = Convert.ToChar(Double.MinValue); }, " Exception not Thrown!");

                // Exception Test Case
                Assert.Throws<InvalidCastException>(() => { Char result = Convert.ToChar(Double.MaxValue); }, " Exception not Thrown!");

            }

            ///////////////////////////////////////////// Char Convert.ToChar( Decimal )
            //[] ToChar(Decimal) - Exception Cases (0,Decimal.MaxValue,Decimal.MinValue)

            // Setup Char Test
            {
                // Exception Test Case
                Assert.Throws<InvalidCastException>(() => { Char result = Convert.ToChar((Decimal)(0)); }, " Exception not Thrown!");
                // Exception Test Case
                Assert.Throws<InvalidCastException>(() => { Char result = Convert.ToChar(Decimal.MinValue); }, " Exception not Thrown!");
                // Exception Test Case
                Assert.Throws<InvalidCastException>(() => { Char result = Convert.ToChar(Decimal.MaxValue); }, " Exception not Thrown!");
            }

            ///////////////////////////////////////////// []Char Convert.ToChar( DateTime )
            Assert.Throws<InvalidCastException>(() => { Char bTest = Convert.ToChar(DateTime.Now); }, " Exception not Thrown!");

            //[] ToChar( Object ) - Exception Case (Object that does not implement IConvertible) 
            Assert.Throws<InvalidCastException>(() => { Char bTest = Convert.ToChar(new Object()); }, " Exception not Thrown!");

            ///////////////////////////////////////////// []Char Convert.ToChar( Object, IFormatProvider )
            Assert.Throws<InvalidCastException>(() => { Char bTest = Convert.ToChar(new Object(), new TestFormatProvider()); }, " Exception not Thrown!");
        }
    }
}
