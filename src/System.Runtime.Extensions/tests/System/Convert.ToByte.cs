//
// Copyright (c) Microsoft Corporation. All rights reserved.
// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
//
// Convert_ToByte_all.cs
//
// Summary:
// Tests Convert.ToByte().
//
// \qa\clr\testsrc\CoreMangLib\BCL\System\Convert:
// Co6054ToByte_all.cs
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
using CoreFXTestLibrary;
using System;

namespace Test
{
    [ContractsRequired("System.Runtime, System.Runtime.Extensions")]
    public class Co6054ToByte_all
    {
        [TestMethod]
        public static void runTest()
        {
            ///////////////////////////////////////////// Byte Convert.ToByte( Boolean )

            //[] ToByte( Boolean ) - true
            //[] ToByte( Boolean ) - false

            //// Setup Boolean Test
            Boolean[] boolArray = { true, false, };
            Byte[] boolResults = { 1, 0, 0, };

            //// Vanilla Tests
            for (int i = 0; i < boolArray.Length; i++)
            {
                Byte result = Convert.ToByte(boolArray[i]);
                Assert.AreEqual(boolResults[i], result, " Expected = '" + boolResults[i] + "' ... Received = '" + result + "'.");
            }

            ///////////////////////////////////////////// Byte Convert.ToByte( SByte )

            //[] ToByte( SByte ) - (SByte) 10
            //[] ToByte( SByte ) - (SByte) 0

            //// Setup SByte Test

            SByte[] SByteArray = { ((SByte)10), ((SByte)0), };
            Byte[] SByteResults = { (Byte)10, (Byte)0, };

            //// Vanilla Tests
            for (int i = 0; i < SByteArray.Length; i++)
            {
                Byte result = Convert.ToByte(SByteArray[i]);
                Assert.AreEqual(SByteResults[i], result, " Expected = '" + SByteResults[i] + "' ... Received = '" + result + "'.");
            }

            ///////////////////////////////////////////// Byte Convert.ToByte( Double )

            //[] ToByte( Double ) - (Double)Byte.MinValue
            //[] ToByte( Double ) - (Double)Byte.MaxValue
            //[] ToByte( Double ) - 0.0
            //[] ToByte( Double ) - 100.0
            //[] ToByte( Double ) - 254.9

            //// Setup Double Test
            Double[] doubArray = { (Double)Byte.MinValue, (Double)Byte.MaxValue, 0.0, 100.0, 254.9, };
            Byte[] doubResults = { Byte.MinValue, Byte.MaxValue, 0, 100, 255 };
            //// Vanilla Tests
            for (int i = 0; i < doubArray.Length; i++)
            {
                Byte result = Convert.ToByte(doubArray[i]);
                Assert.AreEqual(doubResults[i], result, " Expected = '" + doubResults[i] + "' ... Received = '" + result + "'.");
            }


            ///////////////////////////////////////////// Byte Convert.ToByte( Single )

            //[] ToByte( Single ) - (Single)Byte.MaxValue
            //[] ToByte( Single ) - (Single)Byte.MinValue
            //[] ToByte( Single ) - 254.01f

            //// Setup Single Test
            Single[] singArray = { (Single)Byte.MaxValue, (Single)Byte.MinValue, 254.01f, };
            Byte[] singResults = { Byte.MaxValue, Byte.MinValue, 254, };
            //// Vanilla Tests
            for (int i = 0; i < singArray.Length; i++)
            {
                Byte result = Convert.ToByte(singArray[i]);
                Assert.AreEqual(singResults[i], result, " Expected = '" + singResults[i] + "' ... Received = '" + result + "'.");
            }

            ///////////////////////////////////////////// Byte Convert.ToByte( Int32 )

            //[] Byte Convert.ToByte( Int32 ) - 10
            //[] Byte Convert.ToByte( Int32 ) - 0
            //[] Byte Convert.ToByte( Int32 ) - 100
            //[] Byte Convert.ToByte( Int32 ) - 255

            //// Setup Int32 Test
            Int32[] int3Array = { 10, 0, 100, 255, };
            Byte[] int3Results = { 10, 0, 100, 255, };
            //// Vanilla Tests
            for (int i = 0; i < int3Array.Length; i++)
            {
                Byte result = Convert.ToByte(int3Array[i]);
                Assert.AreEqual(int3Results[i], result, " Expected = '" + int3Results[i] + "' ... Received = '" + result + "'.");
            }

            ///////////////////////////////////////////// Byte Convert.ToByte( Int64 )

            //[] ToByte( Int64 ) - 10
            //[] ToByte( Int64 ) - 100

            //// Setup Int64 Test

            Int64[] int6Array = { 10, 100, };
            Byte[] int6Results = { (Byte)10, (Byte)100, };

            //// Vanilla Tests
            for (int i = 0; i < int6Array.Length; i++)
            {
                Byte result = Convert.ToByte(int6Array[i]);
                Assert.AreEqual(int6Results[i], result, " Expected = '" + int6Results[i] + "' ... Received = '" + result + "'.");
            }

            ///////////////////////////////////////////// Byte Convert.ToByte( Int16 )

            //[] ToByte( Int16 ) - 0
            //[] ToByte( Int16 ) - 255
            //[] ToByte( Int16 ) - 100
            //[] ToByte( Int16 ) - 2
            //// Setup Int16 Test

            Int16[] int1Array = { 0, 255, 100, 2, };
            Byte[] int1Results = { 0, 255, 100, 2, };
            //// Vanilla Tests
            for (int i = 0; i < int1Array.Length; i++)
            {
                Byte result = Convert.ToByte(int1Array[i]);
                Assert.AreEqual(int1Results[i], result, " Expected = '" + int1Results[i] + "' ... Received = '" + result + "'.");
            }

            ///////////////////////////////////////////// Byte Convert.ToByte( Decimal )

            //[] ToByte( Decimal ) - (Decimal)Byte.MaxValue
            //[] ToByte( Decimal ) - (Decimal)Byte.MinValue
            //[] ToByte( Decimal ) - new Decimal( 254.01 ),
            //[] ToByte( Decimal ) - (Decimal)(Byte.MaxValue/2 ),

            //// Setup Decimal Test
            Decimal[] deciArray = { (Decimal)Byte.MaxValue, (Decimal)Byte.MinValue, new Decimal(254.01), (Decimal)(Byte.MaxValue / 2), };
            Byte[] deciResults = { Byte.MaxValue, Byte.MinValue, 254, Byte.MaxValue / 2, };

            //// Vanilla Tests
            for (int i = 0; i < deciArray.Length; i++)
            {
                Byte result = Convert.ToByte(deciArray[i]);
                Assert.AreEqual(deciResults[i], result, " Expected = '" + deciResults[i] + "' ... Received = '" + result + "'.");
            }

            ///////////////////////////////////////////// Byte Convert.ToByte( String )

            //[] ToByte( String ) - Byte.MaxValue.ToString()
            //[] ToByte( String ) - Byte.MinValue.ToString()

            //// Setup String Test
            String[] striArray = { Byte.MaxValue.ToString(), Byte.MinValue.ToString(), };
            Byte[] striResults = { Byte.MaxValue, Byte.MinValue, };

            //// Vanilla Tests
            for (int i = 0; i < striArray.Length; i++)
            {
                Byte result = Convert.ToByte(striArray[i]);
                Assert.AreEqual(striResults[i], result, " Expected = '" + striResults[i] + "' ... Received = '" + result + "'.");
            }
            // Exception test
            //[] ToByte( String ) - null string

            String[] dummy = { null, };

            Byte result2 = Convert.ToByte(dummy[0]);
            Assert.AreEqual(0, result2, " Wrong result. ");

            //[] ToByte( String, IFormatProvider ) - null string

            result2 = Convert.ToByte(dummy[0], new TestFormatProvider());
            Assert.AreEqual(0, result2, " Wrong result. ");

            ///////////////////////////////////////////// Byte Convert.ToByte( String, Int32 )

            //[] ToByte( String, Int32 ) - "10",10
            //[] ToByte( String, Int32 ) - "100",10
            //[] ToByte( String, Int32 ) - "1011",2
            //[] ToByte( String, Int32 ) - "ff",16
            //[] ToByte( String, Int32 ) - "0xff",16
            //[] ToByte( String, Int32 ) - "77",8
            //[] ToByte( String, Int32 ) - "11",2
            //[] ToByte( String, Int32 ) - "11111111",2

            //// Setup String Test

            striArray = new string[] { "10", "100", "1011", "ff", "0xff", "77", "11", "11111111", };
            Int32[] striBase = { 10, 10, 2, 16, 16, 8, 2, 2, };
            striResults = new byte[] { 10, 100, 11, 255, 255, 63, 3, 255, };

            //// Vanilla Tests
            for (int i = 0; i < striArray.Length; i++)
            {
                Byte result = Convert.ToByte(striArray[i], striBase[i]);
                Assert.AreEqual(striResults[i], result, " Expected = '" + striResults[i] + "' ... Received = '" + result + "'.");
            }

            // Exception test
            //[] Exception test: ToByte( String, Int32 ) - null,10

            dummy = new string[] { null, };

            Assert.AreEqual(0, Convert.ToByte(dummy[0], 10), "Different results.");
            Assert.AreEqual(0, Convert.ToByte(dummy[0], 2), "Different results.");
            Assert.AreEqual(0, Convert.ToByte(dummy[0], 8), "Different results.");
            Assert.AreEqual(0, Convert.ToByte(dummy[0], 16), "Different results.");



            ///////////////////////////////////////////// Byte Convert.ToByte( Byte )

            //[] ToByte( Byte ) - Byte.MinValue
            //[] ToByte( Byte ) - Byte.MaxValue
            //[] ToByte( Byte ) - (Byte) 10
            //[] ToByte( Byte ) - (Byte) 100

            //// Setup UInt16 Test
            UInt16[] UInt3216Array = { Byte.MinValue, Byte.MaxValue, (Byte)10, (Byte)100, };
            Byte[] UInt3216Results = { 0, 255, 10, 100, };
            //// Vanilla Tests

            for (int i = 0; i < UInt3216Array.Length; i++)
            {
                Byte result = Convert.ToByte(UInt3216Array[i]);
                Assert.AreEqual(UInt3216Results[i], result, " Expected = '" + UInt3216Results[i] + "' ... Received = '" + result + "'.");
            }


            /// Adding UInt Tests

            ///////////////////////////////////////////// Byte Convert.ToByte( UInt16 )

            //[] ToByte( UInt16 ) - (UInt16)10
            //[] ToByte( UInt16 ) - (UInt16)0
            //[] ToByte( UInt16 ) - (UInt16)100
            //[] ToByte( UInt16 ) - (UInt16)255

            //// Setup UInt16 Test

            UInt3216Array = new UInt16[] { (UInt16)10, (UInt16)0, (UInt16)100, (UInt16)255, };
            UInt3216Results = new Byte[] { 10, 0, 100, 255, };
            //// Vanilla Tests
            for (int i = 0; i < UInt3216Array.Length; i++)
            {
                Byte result = Convert.ToByte(UInt3216Array[i]);
                Assert.AreEqual(UInt3216Results[i], result, " Expected = '" + UInt3216Results[i] + "' ... Received = '" + result + "'.");
            }

            ///////////////////////////////////////////// Byte Convert.ToByte( UInt32 )

            //[] ToByte( UInt32 ) - (UInt32)10

            //[] ToByte( UInt32 ) - (UInt32)0

            //[] ToByte( UInt32 ) - (UInt32)100

            //[] ToByte( UInt32 ) - (UInt32)255

            //// Setup UInt32 Test
            UInt32[] UInt3232Array = { (UInt32)10, (UInt32)0, (UInt32)100, (UInt32)255, };
            Byte[] UInt3232Results = { 10, 0, 100, 255, };
            //// Vanilla Tests
            for (int i = 0; i < UInt3232Array.Length; i++)
            {
                Byte result = Convert.ToByte(UInt3232Array[i]);
                Assert.AreEqual(UInt3232Results[i], result, " Expected = '" + UInt3232Results[i] + "' ... Received = '" + result + "'.");
            }

            ///////////////////////////////////////////// Byte Convert.ToByte( UInt64 )

            //[] ToByte( UInt64 ) - (UInt64)10

            //[] ToByte( UInt64 ) - (UInt64)0

            //[] ToByte( UInt64 ) - (UInt64)100

            //[] ToByte( UInt64 ) - (UInt64)255

            //// Setup UInt64 Test
            UInt64[] UInt3264Array = { (UInt64)10, (UInt64)0, (UInt64)100, (UInt64)255, };
            Byte[] UInt3264Results = { 10, 0, 100, 255, };
            //// Vanilla Tests
            for (int i = 0; i < UInt3264Array.Length; i++)
            {
                Byte result = Convert.ToByte(UInt3264Array[i]);
                Assert.AreEqual(UInt3264Results[i], result, " Expected = '" + UInt3264Results[i] + "' ... Received = '" + result + "'.");
            }

            ////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////// Int32 Convert.ToByte( Char )

            //[] ToByte( Char ) - 'A'

            //[] ToByte( Char ) - Char.MinValue

            // Setup Char Test
            Char[] testValues = { 'A', Char.MinValue, };
            Byte[] expectedValues = { (Byte)'A', (Byte)Char.MinValue, };
            // Vanila Test Cases
            for (int i = 0; i < testValues.Length; i++)
            {
                Byte result = Convert.ToByte(testValues[i]);
                Assert.AreEqual(expectedValues[i], result, " Expected = '" + expectedValues[i] + "' ... Received = '" + result + "'.");
            }

            //[] ToByte( Object ) - obj = null
            Assert.AreEqual(0, Convert.ToByte((Object)null), " wrong value returned.  expected 0, got something else.");

            //[] ToByte( Object, IFP ) - obj = null
            Assert.AreEqual(0, Convert.ToByte((Object)null, new TestFormatProvider()), " wrong value returned.  expected 0, got something else.");
        }
        [TestMethod]
        public static void runTest_Negative()
        {

            // Exception test
            //[] Exception test: ToByte( SByte ) - (SByte) -100
            Assert.Throws<OverflowException>(() => { Byte result = Convert.ToByte((SByte)(-100)); }, " No Exception Thrown.");

            // Exception test
            //[] Exception test: ToByte( Double ) - (Double) -100        

            Assert.Throws<OverflowException>(() => { Byte result = Convert.ToByte((Double)(-100)); }, " No Exception Thrown.");

            // Exception test
            //[] Exception test: ToByte( Double ) - (Double) 1000        
            Assert.Throws<OverflowException>(() => { Byte result = Convert.ToByte((Double)1000); }, " No Exception Thrown.");

            // Exception test
            //[] Exception test: ToByte( Single ) - (Single(-100))
            Assert.Throws<OverflowException>(() => { Byte result = Convert.ToByte((Single)(-100)); }, " No Exception Thrown.");

            // Exception test
            //[] Exception test: ToByte( Single ) - (Single(1000))
            Assert.Throws<OverflowException>(() => { Byte result = Convert.ToByte((Single)1000); }, " No Exception Thrown.");

            // Exception test
            //[] Exception test: Byte Convert.ToByte( Int32 ) - -100
            Assert.Throws<OverflowException>(() => { Byte result = Convert.ToByte(-100); }, " No Exception Thrown.");

            // Exception test
            //[] Exception test: Byte Convert.ToByte( Int32 ) - 1000
            Assert.Throws<OverflowException>(() => { Byte result = Convert.ToByte(1000); }, " No Exception Thrown.");

            // Exception test
            //[] Exception test: ToByte( Int64 ) - -100
            Assert.Throws<OverflowException>(() => { Byte result = Convert.ToByte((Int64)(-100)); }, " No Exception Thrown.");

            // Exception test
            //[] Exception test: ToByte( Int64 ) - 1000
            Assert.Throws<OverflowException>(() => { Byte result = Convert.ToByte((Int64)1000); }, " No Exception Thrown.");

            // Exception test
            //[] Exception test: ToByte( Int16 ) - -100
            Assert.Throws<OverflowException>(() => { Byte result = Convert.ToByte((Int16)(-100)); }, " No Exception Thrown.");

            // Exception test
            //[] Exception test: ToByte( Int16 ) - 1000
            Assert.Throws<OverflowException>(() => { Byte result = Convert.ToByte((Int16)1000); }, " No Exception Thrown.");

            // Exception test
            //[] Exception test: ToByte( Decimal ) - (Decimal) -100
            Assert.Throws<OverflowException>(() => { Byte result = Convert.ToByte((Decimal)(-100)); }, " No Exception Thrown.");

            // Exception test
            //[] Exception test: ToByte( Decimal ) - (Decimal) 1000
            Assert.Throws<OverflowException>(() => { Byte result = Convert.ToByte((Decimal)(1000)); }, " No Exception Thrown.");

            // Exception test
            //[] Exception test: ToByte( String ) - "256"
            Assert.Throws<OverflowException>(() => { Byte result = Convert.ToByte("256"); }, " No Exception Thrown.");

            // Exception test
            //[] Exception test: ToByte( String ) - "-1"
            Assert.Throws<OverflowException>(() => { Byte result = Convert.ToByte("-1"); }, " No Exception Thrown.");

            // Exception test
            //[] Exception test: ToByte( String ) - "!56"
            Assert.Throws<FormatException>(() => { Byte result = Convert.ToByte("!56"); }, " No Exception Thrown.");

            // Exception test
            //[] Exception test: ToByte( String, Int32 ) - null,11
            string[] dummy = new string[] { null, };
            Assert.Throws<ArgumentException>(() => { Byte result = Convert.ToByte(dummy[0], 11); }, " No Exception Thrown.");

            // Exception test
            //[] Exception test: ToByte( String, Int32 ) - "256",10
            Assert.Throws<OverflowException>(() => { Byte result = Convert.ToByte("256", 10); }, " No Exception Thrown.");

            // Exception test
            //[] Exception test: ToByte( String, Int32 ) - "111111111",2
            Assert.Throws<OverflowException>(() => { Byte result = Convert.ToByte("111111111", 2); }, " No Exception Thrown.");

            // Exception test
            //[] Exception test: ToByte( String, Int32 ) - "ffffe",16
            Assert.Throws<OverflowException>(() => { Byte result = Convert.ToByte("ffffe", 16); }, " No Exception Thrown.");

            // Exception test
            //[] Exception test: ToByte( String, Int32 ) - "7777777",8
            Assert.Throws<OverflowException>(() => { Byte result = Convert.ToByte("7777777", 8); }, " No Exception Thrown.");

            // Exception test
            //[] Exception test: ToByte( String, Int32 ) - "fffg",16
            Assert.Throws<FormatException>(() => { Byte result = Convert.ToByte("fffg", 16); }, " No Exception Thrown.");

            // Exception test
            //[] Exception test: ToByte( String, Int32 ) - "0xxfff",16
            Assert.Throws<FormatException>(() => { Byte result = Convert.ToByte("0xxfff", 16); }, " No Exception Thrown.");

            // Exception test
            //[] Exception test: ToByte( String, Int32 ) - "8",8
            Assert.Throws<FormatException>(() => { Byte result = Convert.ToByte("8", 8); }, " No Exception Thrown.");
            // Exception test
            //[] Exception test: ToByte( String, Int32 ) - "112",2
            Assert.Throws<FormatException>(() => { Byte result = Convert.ToByte("112", 2); }, " No Exception Thrown.");

            // Exception test
            //[] Exception test: ToByte( String, Int32 ) - "-1",10
            Assert.Throws<OverflowException>(() => { Byte result = Convert.ToByte("-1", 10); }, " No Exception Thrown.");

            // Exception test
            //[] Exception test: ToByte( String, Int32 ) - "!56",10
            Assert.Throws<FormatException>(() => { Byte result = Convert.ToByte("!56", 10); }, " No Exception Thrown.");

            // Exception test
            //[] Exception test: ToByte( UInt16 ) - (UInt16)-100
            Assert.Throws<OverflowException>(() => { Byte result = Convert.ToByte((-100)); }, " No Exception Thrown.");

            // Exception test
            //[] Exception test: ToByte( UInt16 ) - (UInt16)256
            Assert.Throws<OverflowException>(() => { Byte result = Convert.ToByte((UInt16)256); }, " No Exception Thrown.");

            //[] Exception test: ToByte( UInt32 ) - (UInt32)1000
            Assert.Throws<OverflowException>(() => { Byte result = Convert.ToByte(1000); }, " No Exception Thrown.");

            // Exception test
            //[] Exception test: ToByte( UInt32 ) - (UInt32)256
            Assert.Throws<OverflowException>(() => { Byte result = Convert.ToByte((UInt32)256); }, " No Exception Thrown.");

            // Exception test
            //[] Exception test: ToByte( UInt64 ) - (UInt64)1000
            Assert.Throws<OverflowException>(() => { Byte result = Convert.ToByte(1000); }, " No Exception Thrown.");

            // Exception test
            //[] Exception test: ToByte( UInt64 ) - (UInt64)256
            Assert.Throws<OverflowException>(() => { Byte result = Convert.ToByte((UInt64)256); }, " No Exception Thrown.");

            // Exception test
            //[] Exception test: ToByte( Char ) - Char.MaxValue
            Assert.Throws<OverflowException>(() => { Byte result = Convert.ToByte(Char.MaxValue); }, " No Exception Thrown.");

            ///////////////////////////////////////////// Byte Convert.ToByte( Object )
            //[] ToByte( Object ) - Exception Case (Object that does not implement IConvertible) 
            Assert.Throws<InvalidCastException>(() => { Byte bTest = Convert.ToByte(new Object()); }, " No Exception Thrown.");
        }
    }
}
