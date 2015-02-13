// Closed bugs: VSWhidbey #101520 (C++ compiler bug)
// Note: This testfile is a multi-method one. It tests Convert.ToString() and there are 13 methods in this. 9 methods
// are pretty straight forward and a variant array is used to test these. The methods that take the data tytpe and a base
// type (2,8,10,16) is a bit complex (there are 4 of these methods) and they are tested separately.
//
// Copyright (c) Microsoft Corporation. All rights reserved.
// +=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
//
// Convert_ToString_all.cpp
//
// Summary:
// Tests Convert.ToString().
//
// \qa\clr\testsrc\CoreMangLib\BCL\System\Convert:
// Cc3715ToString_all.cs
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
using CoreFXTestLibrary;
using System;
using System.Globalization;

// These are so tests won't get hit with EEType when converting ToString
// [assembly: System.Reflection.Consumption.EnableDynamicProgramming(typeof(Cc3715ToString_all))]
// [assembly: System.Reflection.Consumption.EnableDynamicProgramming(typeof(System.Globalization.NumberFormatInfo))]
// [assembly: System.Reflection.Consumption.EnableDynamicProgramming(typeof(Foo))]

class FooFormattable : IFormattable
{
    private int _value;
    public FooFormattable(int value) { _value = value; }

    public String ToString(String format, IFormatProvider formatProvider)
    {
        if (formatProvider != null)
        {
            return String.Format("{0}: {1}", formatProvider, _value);
        }
        else
        {
            return String.Format("FooFormattable: {0}", (_value));
        }
    }
}

class Foo
{
    private int _value;
    public Foo(int value) { _value = value; }

    public String ToString(IFormatProvider provider)
    {
        if (provider != null)
        {
            return String.Format("{0}: {1}", provider, _value);
        }
        else
        {
            return String.Format("Foo: {0}", _value);
        }
    }
}

[ContractsRequired("System.Globalization, System.Runtime, System.Runtime.Extensions")]
public class Cc3715ToString_all
{
    private const int iNormalArraySize = 66;
    private const int iBaseArraySize = 3;
    private const int iCharArraySize = 4;

    private static Object[] vArrInputs = new Object[iNormalArraySize];
    private static Char[] cArrInputs;

    private static Int32[] iArrBaseInputs;
    private static Int64[] lArrBaseInputs;
    private static Int16[] sArrBaseInputs;
    private static Byte[] uArrBaseInputs;

    private static String[] strArrExps = new String[iNormalArraySize];
    private static String[] strCArrExps;
    private static String[] strArrBaseExps;

    static String strResult;
    static int iBase;
    static Object vnt1;

    static Cc3715ToString_all() {
        //Vanila 9 test cases		
        FillNormalInputsAndRslts();

        // test for char
        strCArrExps = new String[iCharArraySize];
        cArrInputs = new Char[iCharArraySize];

        strArrBaseExps = new String[iBaseArraySize];
        iArrBaseInputs = new Int32[iBaseArraySize];

        sArrBaseInputs = new Int16[iBaseArraySize];

        FillBaseShortInputs();
        FillBase2ShortRslts();

        FillMoreNormalInputsAndRslts();

        lArrBaseInputs = new Int64[iBaseArraySize];

        FillBaseLongInputs();
        FillBase2LongRslts();

        uArrBaseInputs = new Byte[iBaseArraySize];

        FillBaseUCInputs();
        FillBase2UCRslts();

        FillBaseIntInputs();

    }

    [TestMethod]
    public static void convertTest1()
    {
        //Update: 2001/03/31 unfortuntaly, the il treats this as calls to Convert.ToString(Object)
        //We want these to be handled independently. Hence writing more code below to call each individual type separately.

        for (int i = 0; i < vArrInputs.Length; i++)
        {
            strResult = Convert.ToString(vArrInputs[i]);
            Assert.AreEqual(strArrExps[i], strResult, "Expected them to be the same.");
            strResult = Convert.ToString(vArrInputs[i], new NumberFormatInfo());
            Assert.AreEqual(strArrExps[i], strResult, "Expected to be the same.");
        }
    }

    [TestMethod]
    public static void convertTestChar()
    {
        for (int aa = 0; aa < cArrInputs.Length; aa++)
        {
            strResult = Convert.ToString(cArrInputs[aa]);
            Assert.AreEqual(strCArrExps[aa], strResult, "Expected the same results.");
            strResult = Convert.ToString(cArrInputs[aa], new NumberFormatInfo());
            Assert.AreEqual(strCArrExps[aa], strResult, "Expected the same results.");
        }
    }

    [TestMethod]
    public static void ConvertFromIntBase2()
    {
        //base 4 cases, base 2: GROAN, cant use Variant
        // So slog along, int, base 2
        FillBaseIntInputs();
        FillBase2IntRslts();
        iBase = 2;

        for (int aa = 0; aa < iArrBaseInputs.Length; aa++)
        {
            strResult = Convert.ToString(iArrBaseInputs[aa], iBase);

            Assert.AreEqual(strArrBaseExps[aa], strResult, "Should be the same");
        }
    }
    [TestMethod]
    public static void ConvertFromIntBase8()
    {
        // int, base 8
        FillBase8IntRslts();
        iBase = 8;

        for (int aa = 0; aa < iArrBaseInputs.Length; aa++)
        {
            strResult = Convert.ToString(iArrBaseInputs[aa], iBase);
            Assert.AreEqual(strArrBaseExps[aa], strResult, "Expected the same results.");
        }
    }
    [TestMethod]
    public static void ConvertFromIntBase10()
    {
        // int, base 10
        FillBase10IntRslts();
        iBase = 10;

        for (int aa = 0; aa < iArrBaseInputs.Length; aa++)
        {
            strResult = Convert.ToString(iArrBaseInputs[aa], iBase);
            Assert.AreEqual(strArrBaseExps[aa], strResult, "Expected the same results.");
        }
    }
    [TestMethod]
    public static void ConvertFromBase16()
    {
        // int, base 16
        FillBase16IntRslts();
        iBase = 16;

        for (int aa = 0; aa < iArrBaseInputs.Length; aa++)
        {
            strResult = Convert.ToString(iArrBaseInputs[aa], iBase);
            Assert.AreEqual(strArrBaseExps[aa], strResult, "Expected the same results.");
        }
    }
    [TestMethod]
    public static void ConvertFromLongBase2()
    {
        // So slog along, __int64, base 2
        lArrBaseInputs = new Int64[iBaseArraySize];

        FillBaseLongInputs();
        FillBase2LongRslts();
        iBase = 2;

        for (int aa = 0; aa < lArrBaseInputs.Length; aa++)
        {
            strResult = Convert.ToString(lArrBaseInputs[aa], iBase);
            Assert.AreEqual(strArrBaseExps[aa], strResult, "Expected the same results.");
        }
    }
    [TestMethod]
    public static void ConvertFromLongBase8()
    {
        // long, base 8
        FillBase8LongRslts();
        iBase = 8;

        for (int aa = 0; aa < lArrBaseInputs.Length; aa++)
        {
            strResult = Convert.ToString(lArrBaseInputs[aa], iBase);
            Assert.AreEqual(strArrBaseExps[aa], strResult, "Expected the same results.");
        }
    }
    [TestMethod]
    public static void ConvertFromLongBase10()
    {
        // long, base 10
        FillBase10LongRslts();
        iBase = 10;

        for (int aa = 0; aa < lArrBaseInputs.Length; aa++)
        {
            strResult = Convert.ToString(lArrBaseInputs[aa], iBase);
            Assert.AreEqual(strArrBaseExps[aa], strResult, "Expected the same results.");
        }
    }
    [TestMethod]
    public static void ConvertFromLongBase16()
    {
        // long, base 16
        FillBase16LongRslts();
        iBase = 16;
        for (int aa = 0; aa < lArrBaseInputs.Length; aa++)
        {
            strResult = Convert.ToString(lArrBaseInputs[aa], iBase);
            Assert.AreEqual(strArrBaseExps[aa], strResult, "Expected the same results.");
        }
    }
    [TestMethod]
    public static void ConvertFromShortBase2()
    {
        // So slog along, short, base 2
        sArrBaseInputs = new Int16[iBaseArraySize];

        FillBaseShortInputs();
        FillBase2ShortRslts();
        iBase = 2;

        for (int aa = 0; aa < sArrBaseInputs.Length; aa++)
        {
            strResult = Convert.ToString(sArrBaseInputs[aa], iBase);
            Assert.AreEqual(strArrBaseExps[aa], strResult, "Expected the same results.");
        }
    }
    [TestMethod]
    public static void ConvertFromShortBase8()
    {
        // short, base 8
        FillBase8ShortRslts();
        iBase = 8;

        for (int aa = 0; aa < sArrBaseInputs.Length; aa++)
        {
            strResult = Convert.ToString(sArrBaseInputs[aa], iBase);
            Assert.AreEqual(strArrBaseExps[aa], strResult, "Expected the same results.");
        }
    }

    [TestMethod]
    public static void ConvertFromShortBase10()
    {
        // short, base 10
        FillBase10ShortRslts();
        iBase = 10;

        for (int aa = 0; aa < sArrBaseInputs.Length; aa++)
        {
            strResult = Convert.ToString(sArrBaseInputs[aa], iBase);
            Assert.AreEqual(strArrBaseExps[aa], strResult, "Expected the same results.");
        }
    }
    [TestMethod]
    public static void ConvertFromShortBase16()
    {
        // short, base 16
        FillBase16ShortRslts();
        iBase = 16;

        for (int aa = 0; aa < sArrBaseInputs.Length; aa++)
        {
            strResult = Convert.ToString(sArrBaseInputs[aa], iBase);
            Assert.AreEqual(strArrBaseExps[aa], strResult, "Expected the same results.");
        }

    }
    [TestMethod]
    public static void ConvertFromUcharBase2()
    {
        // So slog along, unsigned char, base 2
        uArrBaseInputs = new Byte[iBaseArraySize];

        FillBaseUCInputs();
        FillBase2UCRslts();
        iBase = 2;

        for (int aa = 0; aa < uArrBaseInputs.Length; aa++)
        {
            strResult = Convert.ToString(uArrBaseInputs[aa], iBase);
            Assert.AreEqual(strArrBaseExps[aa], strResult, "Expected the same results.");
        }
    }
    [TestMethod]
    public static void ConvertFromUcharBase8()
    {
        // unsigned char, base 8
        FillBase8UCRslts();
        iBase = 8;

        for (int aa = 0; aa < uArrBaseInputs.Length; aa++)
        {
            strResult = Convert.ToString(uArrBaseInputs[aa], iBase);
            Assert.AreEqual(strArrBaseExps[aa], strResult, "Expected the same results.");
        }
    }
    [TestMethod]
    public static void ConvertFromUCharBase10()
    {
        // unsigned char, base 10
        FillBase10UCRslts();
        iBase = 10;

        for (int aa = 0; aa < uArrBaseInputs.Length; aa++)
        {
            strResult = Convert.ToString(uArrBaseInputs[aa], iBase);
            Assert.AreEqual(strArrBaseExps[aa], strResult, "Expected the same results.");
        }
    }
    [TestMethod]
    public static void ConvertFromUcharBase16()
    {
        uArrBaseInputs = new Byte[iBaseArraySize];

        FillBaseUCInputs();
        FillBase2UCRslts();

        // unsigned char, base 16
        FillBase16UCRslts();
        iBase = 16;

        for (int aa = 0; aa < uArrBaseInputs.Length; aa++)
        {
            strResult = Convert.ToString(uArrBaseInputs[aa], iBase);
            Assert.AreEqual(strArrBaseExps[aa], strResult, "Expected the same results.");
        }
    }
    [TestMethod]
    public static void ConvertFromObject()
    {
        //[] ToString(Object) - Vanilla Case
        vnt1 = new Cc3715ToString_all();
        strResult = Convert.ToString(vnt1);
        Assert.AreEqual("Cc3715ToString_all", strResult, "Expected to equal");
    }
    [TestMethod]
    public static void ConvertFromBoolean()
    {
        //[]Boolean
        {
            Boolean[] testValues = new[] { true, false };
            // Vanila Test Cases
            for (int i = 0; i < testValues.Length; i++)
            {
                string expected = testValues[i].ToString();
                string actual = Convert.ToString(testValues[i]);
                Assert.AreEqual(expected, actual, "Expected to be same");
                actual = Convert.ToString(testValues[i], new NumberFormatInfo());
                Assert.AreEqual(expected, actual, "Expected to be same");

            }
        }
    }
    [TestMethod]
    public static void ConvertFromSByte()
    {
        {
            //[]SByte
            // The following line was failing due to VSWhidbey #101520 (fixed)
            SByte[] testValues = new SByte[] { SByte.MinValue, -1, 0, 1, SByte.MaxValue };
            // Vanila Test Cases
            for (int i = 0; i < testValues.Length; i++)
            {
                String result = Convert.ToString(testValues[i]);
                Assert.AreEqual(testValues[i].ToString(), result, "Expected result to be the same as type.ToString()");
                result = Convert.ToString(testValues[i], new NumberFormatInfo());
                Assert.AreEqual(testValues[i].ToString(), result, "Expected result to be the same as type.ToString()");
            }
        }
    }
    [TestMethod]
    public static void ConvertFromByte()
    {
        //[]Byte
        {
            // The following line was failing due to VSWhidbey #101520 (fixed)
            Byte[] testValues = new Byte[] { Byte.MinValue, 0, 1, 100, Byte.MaxValue };
            // Vanila Test Cases
            for (int i = 0; i < testValues.Length; i++)
            {
                String result = Convert.ToString(testValues[i]);
                Assert.AreEqual(testValues[i].ToString(), result, "Expected result to be the same as type.ToString()");
                result = Convert.ToString(testValues[i], new NumberFormatInfo());
                Assert.AreEqual(testValues[i].ToString(), result, "Expected result to be the same as type.ToString()");
            }
        }
    }
    [TestMethod]
    public static void ConvertFromInt16Array()
    {
        //[]Int16
        {
            // The following line was failing due to VSWhidbey #101520 (fixed)
            Int16[] testValues = new Int16[] { Int16.MinValue, -1000, -1, 0, 1, 1000, Int16.MaxValue };
            // Vanila Test Cases
            for (int i = 0; i < testValues.Length; i++)
            {
                String result = Convert.ToString(testValues[i]);
                Assert.AreEqual(testValues[i].ToString(), result, "Expected result to be the same as type.ToString()");
                result = Convert.ToString(testValues[i], new NumberFormatInfo());
                Assert.AreEqual(testValues[i].ToString(), result, "Expected result to be the same as type.ToString()");
            }
        }
    }
    [TestMethod]
    public static void ConvertFromUInt16Array()
    {
        //[]UInt16
        {
            // The following line was failing due to VSWhidbey #101520 (fixed)
            UInt16[] testValues = new UInt16[] { UInt16.MinValue, 0, 1, 1000, UInt16.MaxValue };
            // Vanila Test Cases
            for (int i = 0; i < testValues.Length; i++)
            {
                String result = Convert.ToString(testValues[i]);
                Assert.AreEqual(testValues[i].ToString(), result, "Expected result to be the same as type.ToString()");
                result = Convert.ToString(testValues[i], new NumberFormatInfo());
                Assert.AreEqual(testValues[i].ToString(), result, "Expected result to be the same as type.ToString()");
            }
        }
    }
    [TestMethod]
    public static void ConvertFromInt32Array()
    {
        //[]Int32
        {
            // The following line was failing due to VSWhidbey #101520 (fixed)
            Int32[] testValues = new Int32[] { Int32.MinValue, -1000, -1, 0, 1, 1000, Int32.MaxValue };
            // Vanila Test Cases
            for (int i = 0; i < testValues.Length; i++)
            {
                String result = Convert.ToString(testValues[i]);
                Assert.AreEqual(testValues[i].ToString(), result, "Expected result to be the same as type.ToString()");
                result = Convert.ToString(testValues[i], new NumberFormatInfo());
                Assert.AreEqual(testValues[i].ToString(), result, "Expected result to be the same as type.ToString()");
            }
        }
    }
    [TestMethod]
    public static void ConvertFromUInt32Array()
    {
        //[]UInt32
        {
            // The following line was failing due to VSWhidbey #101520 (fixed)
            UInt32[] testValues = new UInt32[] { UInt32.MinValue, 0, 1, 1000, UInt32.MaxValue };
            // Vanila Test Cases
            for (int i = 0; i < testValues.Length; i++)
            {
                String result = Convert.ToString(testValues[i]);
                Assert.AreEqual(testValues[i].ToString(), result, "Expected result to be the same as type.ToString()");
                result = Convert.ToString(testValues[i], new NumberFormatInfo());
                Assert.AreEqual(testValues[i].ToString(), result, "Expected result to be the same as type.ToString()");
            }
        }
    }
    [TestMethod]
    public static void ConvertFromInt64Array()
    {
        //[]Int64
        {
            // The following line was failing due to VSWhidbey #101520 (fixed)
            Int64[] testValues = new Int64[] { Int64.MinValue, -1000, -1, 0, 1, 1000, Int64.MaxValue };
            // Vanila Test Cases
            for (int i = 0; i < testValues.Length; i++)
            {
                String result = Convert.ToString(testValues[i]);
                Assert.AreEqual(testValues[i].ToString(), result, "Expected result to be the same as type.ToString()");
                result = Convert.ToString(testValues[i], new NumberFormatInfo());
                Assert.AreEqual(testValues[i].ToString(), result, "Expected result to be the same as type.ToString()");
            }
        }
    }
    [TestMethod]
    public static void ConvertFromUInt64Array()
    {
        //[]UInt64
        {
            // The following line was failing due to VSWhidbey #101520 (fixed)
            UInt64[] testValues = new UInt64[] { UInt64.MinValue, 0, 1, 1000, UInt64.MaxValue };
            // Vanila Test Cases
            for (int i = 0; i < testValues.Length; i++)
            {
                String result = Convert.ToString(testValues[i]);
                Assert.AreEqual(testValues[i].ToString(), result, "Expected result to be the same as type.ToString()");
                result = Convert.ToString(testValues[i], new NumberFormatInfo());
                Assert.AreEqual(testValues[i].ToString(), result, "Expected result to be the same as type.ToString()");
            }
        }
    }
    [TestMethod]
    public static void ConvertFromSingleArray()
    {
        //[]Single
        {
            // The following line was failing due to VSWhidbey #101520 (fixed)
            Single[] testValues = new Single[] { Single.MinValue, 0.0f, 1.0f, 1000.0f, Single.MaxValue, Single.NegativeInfinity, Single.PositiveInfinity, Single.Epsilon, Single.NaN };

            // Vanila Test Cases
            for (int i = 0; i < testValues.Length; i++)
            {
                String result = Convert.ToString(testValues[i]);
                Assert.AreEqual(testValues[i].ToString(), result, "Expected result to be the same as type.ToString()");
                result = Convert.ToString(testValues[i], new NumberFormatInfo());
                Assert.AreEqual(testValues[i].ToString(), result, "Expected result to be the same as type.ToString()");
            }
        }
    }
    [TestMethod]
    public static void ConvertFromDoubleArray()
    {
        //[]Double
        {
            // The following line was failing due to VSWhidbey #101520 (fixed)
            Double[] testValues = new Double[] { Double.MinValue, 0.0, 1.0, 1000.0, Double.MaxValue, Double.NegativeInfinity, Double.PositiveInfinity, Double.Epsilon, Double.NaN };

            // Vanila Test Cases
            for (int i = 0; i < testValues.Length; i++)
            {
                String result = Convert.ToString(testValues[i]);
                Assert.AreEqual(testValues[i].ToString(), result, "Expected result to be the same as type.ToString()");
                result = Convert.ToString(testValues[i], new NumberFormatInfo());
                Assert.AreEqual(testValues[i].ToString(), result, "Expected result to be the same as type.ToString()");
            }
        }
    }
    [TestMethod]
    public static void ConvertFromDecimalArray()
    {
        //[]Decimal
        {
            // The following line was failing due to VSWhidbey #101520 (fixed)
            Decimal[] testValues = new Decimal[] { Decimal.MinValue, Decimal.Parse("-1.234567890123456789012345678", NumberFormatInfo.InvariantInfo), (Decimal)0.0, (Decimal)1.0, (Decimal)1000.0, Decimal.MaxValue, Decimal.One, Decimal.Zero, Decimal.MinusOne };
            // Vanila Test Cases
            for (int i = 0; i < testValues.Length; i++)
            {
                String result = Convert.ToString(testValues[i]);
                Assert.AreEqual(testValues[i].ToString(), result, "Expected result to be the same as type.ToString()");
                result = Convert.ToString(testValues[i], new NumberFormatInfo());
                Assert.AreEqual(testValues[i].ToString(), result, "Expected result to be the same as type.ToString()");
            }
        }
    }
    [TestMethod]
    public static void ConvertFromDateTimeArray()
    {

        //[]DateTime
        {
            DateTime[] testValues = new DateTime[] { 
                DateTime.Parse("08/15/2000 16:59:59", DateTimeFormatInfo.InvariantInfo), 
                DateTime.Parse("01/01/0001 01:01:01", DateTimeFormatInfo.InvariantInfo) };

            IFormatProvider formatProvider = DateTimeFormatInfo.GetInstance(new CultureInfo("en-US"));
            // Vanila Test Cases
            for (int i = 0; i < testValues.Length; i++)
            {
                String result = Convert.ToString(testValues[i]);
                Assert.AreEqual(testValues[i].ToString(), result, "Expected result to be the same as type.ToString()");
                result = Convert.ToString(testValues[i], formatProvider);
                String expected = testValues[i].ToString(formatProvider);
                Assert.AreEqual(expected, result, "Expected result to be the same as type.ToString()");
            }
        }
    }
    [TestMethod]
    public static void ConvertFromString()
    {
        //[]String
        {
            String[] testValues = new String[] { "Hello", " ", "", "\0" };
            // Vanila Test Cases
            for (int i = 0; i < testValues.Length; i++)
            {
                String result = Convert.ToString(testValues[i]);
                Assert.AreEqual(testValues[i].ToString(), result, "Expected result to be the same as type.ToString()");
                result = Convert.ToString(testValues[i], new NumberFormatInfo());
                Assert.AreEqual(testValues[i].ToString(), result, "Expected result to be the same as type.ToString()");
            }
        }
    }
    [TestMethod]
    public static void ConvertFromIFormattable()
    {
        //[]Object (supports IFormattable) - VSWhidbey 505068
        {
            FooFormattable foo = new FooFormattable(3);
            String result = Convert.ToString(foo);
            Assert.AreEqual("FooFormattable: 3", result, "Should be equal");
            result = Convert.ToString(foo, new NumberFormatInfo());
            Assert.AreEqual("System.Globalization.NumberFormatInfo: 3", result, "Should be equal.");

            foo = null;
            result = Convert.ToString(foo, new NumberFormatInfo());
            Assert.AreEqual("", result, "Should be Equal.");
        }
    }

    [TestMethod]
    public static void ConvertFromNonIConvertable()
    {
        //[]Object (supports neither IConvertible nor IFormattable)
        {
            Foo foo = new Foo(3);
            String result = Convert.ToString(foo);
            Assert.AreEqual("Foo", result, "Should be equal.");
            result = Convert.ToString(foo, new NumberFormatInfo());
            Assert.AreEqual("Foo", result, "Should be equal.");

            foo = null;
            result = Convert.ToString(foo, new NumberFormatInfo());
            Assert.AreEqual("", result, "Should be equal.");
        }
    }

    [TestMethod]
    public static void runTest_Negative1()
    {
        //[] Exception Case: ToString(Int32,Int32) - set base to 9
        int iBase = 9;
        int iValue = (int)Int32.MaxValue;

        Assert.Throws<ArgumentException>(() => strResult = Convert.ToString(iValue, iBase), "ArgumentException expected.");

    }

    [TestMethod]
    public static void runTest_Negative2()
    {
        //[] Exception Case: ToString(Int64,Int32) - set base to 0
        iBase = 0;
        long lValue = (long)Int64.MaxValue;
        Assert.Throws<ArgumentException>(() => strResult = Convert.ToString(lValue, iBase), "ArgumentException expected.");

    }

    [TestMethod]
    public static void runTest_Negative3()
    {
        //[] Exception Case: ToString(Int16,Int32) - set base to 1
        iBase = 1;
        short sValue = (short)Int16.MaxValue;
        Assert.Throws<ArgumentException>(() => strResult = Convert.ToString(sValue, iBase), "ArgumentException expected.");

    }

    [TestMethod]
    public static void runTest_Negative4()
    {
        //[] Exception Case: ToString(Byte,Int32) - set base to Int32.MinValue
        iBase = Int32.MinValue;
        Byte bValue = (Byte)Byte.MaxValue;
        Assert.Throws<ArgumentException>(() => strResult = Convert.ToString(bValue, iBase), "ArgumentException expected.");
    }

    private static void FillNormalInputsAndRslts()
    {
        //dont want to play around with passing arrays as parameters now
        //TODO remember to adjust iNormalArraySize if extending the arrays!!
        int i;
        String str1;

        i = 0;

        //bool
        //[] ToString(Boolean) - true
        vArrInputs[i++] = (true);
        //[] ToString(Boolean) - false
        vArrInputs[i++] = (false);

        //double
        //[] ToString(double) - -12.2364
        vArrInputs[i++] = (-12.2364);
        //[] ToString(double) - -12.236465923406483
        vArrInputs[i++] = (-12.236465923406483);
        //[] ToString(double) - -1.7753E-83
        vArrInputs[i++] = (-1.7753E-83);	//10
        //[] ToString(double) - +12.345e+234
        vArrInputs[i++] = (+12.345e+234);
        //[] ToString(double) - +12e+1
        vArrInputs[i++] = (+12e+1);
        //[] ToString(double) - Double.NegativeInfinity
        Double d = Double.NegativeInfinity;
        vArrInputs[i++] = (d);
        //[] ToString(double) - Double.PositiveInfinity
        d = Double.PositiveInfinity;
        vArrInputs[i++] = (d);
        //[] ToString(double) - Double.NaN
        d = Double.NaN;
        vArrInputs[i++] = (d); ;



        //float
        //[] ToString(Single) - -12.2364
        vArrInputs[i++] = ((float)(-12.2364));
        //[] ToString(Single) - -12.2364659234064826243
        vArrInputs[i++] = ((float)(-12.2364659234064826243));
        //[] ToString(Single) - -1.7753e-83
        vArrInputs[i++] = ((float)(-1.7753e-83));
        //[] ToString(Single) - +12.345e+234
        vArrInputs[i++] = ((float)+12.345e+234);
        //[] ToString(Single) - +12e+1
        vArrInputs[i++] = ((float)+12e+1);		//20
        //[] ToString(Single) - Single.NegativeInfinity
        Single s = Single.NegativeInfinity;
        vArrInputs[i++] = (s);
        //[] ToString(Single) - Single.PositiveInfinity
        s = Single.PositiveInfinity;
        vArrInputs[i++] = (s);
        //[] ToString(Single) - Single.NaN
        s = Single.NaN;
        vArrInputs[i++] = (s);


        //int
        //[] ToString(Int32) - Int32.MinValue
        Int32 i32 = Int32.MinValue;
        vArrInputs[i++] = (i32);
        //[] ToString(Int32) - 0
        vArrInputs[i++] = (0);
        //[] ToString(Int32) - Int32.MaxValue
        i32 = Int32.MaxValue;
        vArrInputs[i++] = (i32);


        //__int64
        //[] ToString(Int64) - Int64.MinValue
        Int64 i64 = Int64.MinValue;
        vArrInputs[i++] = (i64);
        //[] ToString(Int64) - 0
        vArrInputs[i++] = (0);
        //[] ToString(Int64) - Int64.MinValue
        i64 = Int64.MaxValue;
        vArrInputs[i++] = (i64);

        //Variant - seems silly, as the data type would be unboxed. Maybe for VB
        vArrInputs[i++] = (-128);		//30
        str1 = "-1.56-e-33";
        vArrInputs[i++] = str1;
        vArrInputs[i++] = (true);


        //short
        //[] ToString(Int16) - Int16.MinValue
        Int16 i16 = Int16.MinValue;
        vArrInputs[i++] = (i16);
        //[] ToString(Int16) - 0
        vArrInputs[i++] = ((Int16)0);
        //[] ToString(Int16) - Int16.MinValue
        i16 = Int16.MaxValue;
        vArrInputs[i++] = (i16);


        //Bytes
        //[] ToString(Byte) - Byte.MinValue
        Byte b = Byte.MinValue;
        vArrInputs[i++] = (b);
        //[] ToString(Byte) - 127
        vArrInputs[i++] = ((byte)127);
        //[] ToString(Byte) - 128
        vArrInputs[i++] = ((byte)128);
        //[] ToString(Byte) - Byte.MaxValue
        b = Byte.MaxValue;
        vArrInputs[i++] = (b);

        //SByte
        SByte sb;
        //[] ToString(SByte) - 0
        sb = 0;
        vArrInputs[i++] = (sb);
        //[] ToString(SByte) - 1
        sb = 1;
        vArrInputs[i++] = (sb);
        //[] ToString(SByte) - -1
        sb = -1;
        vArrInputs[i++] = (sb);
        //[] ToString(SByte) - SByte.MinValue
        sb = SByte.MinValue;
        vArrInputs[i++] = (sb);
        //[] ToString(SByte) - SByte.MaxValue
        sb = SByte.MaxValue;
        vArrInputs[i++] = (sb);

        //UInt16
        UInt16 uint16;
        //[] ToString(UInt16) - 0
        uint16 = 0;
        vArrInputs[i++] = (uint16);
        //[] ToString(UInt16) - 1
        uint16 = 1;
        vArrInputs[i++] = (uint16);
        //[] ToString(UInt16) - 100
        uint16 = 100;
        vArrInputs[i++] = (uint16);
        //[] ToString(UInt16) - UInt16.MaxValue
        uint16 = UInt16.MaxValue;
        vArrInputs[i++] = (uint16);

        //UInt32
        UInt32 uint32;
        //[] ToString(UInt32) - 0
        uint32 = 0;
        vArrInputs[i++] = (uint32);
        //[] ToString(UInt32) - 1
        uint32 = 1;
        vArrInputs[i++] = (uint32);
        //[] ToString(UInt32) - 100
        uint32 = 100;
        vArrInputs[i++] = (uint32);
        //[] ToString(UInt32) - UInt32.MaxValue
        uint32 = UInt32.MaxValue;
        vArrInputs[i++] = (uint32);

        //UInt64
        UInt64 uint64;
        //[] ToString(UInt64) - 0
        uint64 = 0;
        vArrInputs[i++] = (uint64);
        //[] ToString(UInt64) - 1
        uint64 = 1;
        vArrInputs[i++] = (uint64);
        //[] ToString(UInt64) - 100
        uint64 = 100;
        vArrInputs[i++] = (uint64);
        //[] ToString(UInt64) - UInt64.MaxValue
        uint64 = UInt64.MaxValue;
        vArrInputs[i++] = (uint64);

        //Decimal
        Decimal dec;
        //[] ToString(Decimal) - 0
        dec = Decimal.Zero;
        vArrInputs[i++] = (dec);
        //[] ToString(Decimal) - 1
        dec = Decimal.One;
        vArrInputs[i++] = (dec);
        //[] ToString(Decimal) - -1
        dec = Decimal.MinusOne;
        vArrInputs[i++] = (dec);
        //[] ToString(Decimal) - Decimal.MaxValue
        dec = Decimal.MaxValue;
        vArrInputs[i++] = (dec);
        //[] ToString(Decimal) - Decimal.MinValue
        dec = Decimal.MinValue;
        vArrInputs[i++] = (dec);
        //[] ToString(Decimal) - 1.234567890123456789012345678
        dec = Decimal.Parse("1.234567890123456789012345678", NumberFormatInfo.InvariantInfo);
        vArrInputs[i++] = (dec);
        //[] ToString(Decimal) - 1234.56
        dec = Decimal.Parse("1234.56", NumberFormatInfo.InvariantInfo);
        vArrInputs[i++] = (dec);
        //[] ToString(Decimal) - -1234.56
        dec = Decimal.Parse("-1234.56", NumberFormatInfo.InvariantInfo);
        vArrInputs[i++] = (dec);

        //DateTime
        DateTime dt;
        //[] ToString(DateTime) - 08/15/2000 16:59:59					
        dt = DateTime.Parse("08/15/2000 16:59:59", DateTimeFormatInfo.InvariantInfo);
        vArrInputs[i++] = (dt);
        //[] ToString(DateTime) - 01/01/01 01:01:01
        dt = DateTime.Parse("01/01/0001 01:01:01", DateTimeFormatInfo.InvariantInfo);
        vArrInputs[i++] = (dt);

        //TimeSpan
        TimeSpan ts;
        //[] ToString(TimeSpan) - 0.00:00:00
        ts = TimeSpan.Parse("0.00:00:00");
        vArrInputs[i++] = (ts);
        //[] ToString(TimeSpan) - 1999.9:09:09
        ts = TimeSpan.Parse("1999.9:09:09");
        vArrInputs[i++] = (ts);
        //[] ToString(TimeSpan) - -1111.1:11:11
        ts = TimeSpan.Parse("-1111.1:11:11");
        vArrInputs[i++] = (ts);
        //[] ToString(TimeSpan) - 1:23:45
        ts = TimeSpan.Parse("1:23:45");
        vArrInputs[i++] = (ts);
        //[] ToString(TimeSpan) - -2:34:56
        ts = TimeSpan.Parse("-2:34:56");
        vArrInputs[i++] = (ts);


        i = 0;
        //bool
        strArrExps[i++] = "True";
        strArrExps[i++] = "False";

        //double
        strArrExps[i++] = "-12.2364";
        strArrExps[i++] = "-12.2364659234065";
        strArrExps[i++] = "-1.7753E-83";
        strArrExps[i++] = "1.2345E+235";
        strArrExps[i++] = "120";
        strArrExps[i++] = "-Infinity";
        strArrExps[i++] = "Infinity";
        strArrExps[i++] = "NaN";
        //float
        strArrExps[i++] = "-12.2364";
        strArrExps[i++] = "-12.23647";
        strArrExps[i++] = "0";
        strArrExps[i++] = "Infinity";
        strArrExps[i++] = "120";
        strArrExps[i++] = "-Infinity";
        strArrExps[i++] = "Infinity";
        strArrExps[i++] = "NaN";
        //int
        strArrExps[i++] = "-2147483648";
        strArrExps[i++] = "0";
        strArrExps[i++] = "2147483647";
        //__int64
        strArrExps[i++] = "-9223372036854775808";
        strArrExps[i++] = "0";
        strArrExps[i++] = "9223372036854775807";
        //Variant
        strArrExps[i++] = "-128";
        strArrExps[i++] = "-1.56-e-33";
        strArrExps[i++] = "True";
        //short
        strArrExps[i++] = "-32768";
        strArrExps[i++] = "0";
        strArrExps[i++] = "32767";
        //Bytes
        strArrExps[i++] = "0";
        strArrExps[i++] = "127";
        strArrExps[i++] = "128";
        strArrExps[i++] = "255";

        //SByte
        strArrExps[i++] = "0";
        strArrExps[i++] = "1";
        strArrExps[i++] = "-1";
        strArrExps[i++] = "-128";
        strArrExps[i++] = "127";

        //UInt16
        strArrExps[i++] = "0";
        strArrExps[i++] = "1";
        strArrExps[i++] = "100";
        strArrExps[i++] = "65535";


        //UInt32
        strArrExps[i++] = "0";
        strArrExps[i++] = "1";
        strArrExps[i++] = "100";
        strArrExps[i++] = "4294967295";

        //UInt64
        strArrExps[i++] = "0";
        strArrExps[i++] = "1";
        strArrExps[i++] = "100";
        strArrExps[i++] = "18446744073709551615";

        //Decimal
        strArrExps[i++] = "0";
        strArrExps[i++] = "1";
        strArrExps[i++] = "-1";
        strArrExps[i++] = "79228162514264337593543950335";
        strArrExps[i++] = "-79228162514264337593543950335";
        strArrExps[i++] = "1.234567890123456789012345678";
        strArrExps[i++] = "1234.56";
        strArrExps[i++] = "-1234.56";

        //DateTime	
        if (CultureInfo.CurrentCulture.Name.Equals("ja-JP"))
        {
            if (CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern.Equals("yy/MM/dd"))
            {
                strArrExps[i++] = "00/08/15 16:59:59";
                strArrExps[i++] = "01/01/01 1:01:01";
            }
            else
            {
                strArrExps[i++] = "2000/08/15 16:59:59";
                strArrExps[i++] = "0001/01/01 1:01:01";
            }
        }
        else if (CultureInfo.CurrentCulture.Name.Equals("en-US"))
        {
            if (CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern.Equals("M/d/yy"))
            {
                strArrExps[i++] = "8/15/00 4:59:59 PM";
                strArrExps[i++] = "1/1/01 1:01:01 AM";
            }
            else
            {
                strArrExps[i++] = "8/15/2000 4:59:59 PM";
                strArrExps[i++] = "1/1/0001 1:01:01 AM";
            }
        }
        else
        {
            DateTime date = DateTime.Parse("08/15/2000 16:59:59", DateTimeFormatInfo.InvariantInfo);
            strArrExps[i++] = date.ToString();
            date = DateTime.Parse("01/01/0001 01:01:01", DateTimeFormatInfo.InvariantInfo);
            strArrExps[i++] = date.ToString();
        }

        //TimeSpan
        strArrExps[i++] = "00:00:00";
        strArrExps[i++] = "1999.09:09:09";
        strArrExps[i++] = "-1111.01:11:11";
        strArrExps[i++] = "01:23:45";
        strArrExps[i++] = "-02:34:56";
    }

    private static void FillMoreNormalInputsAndRslts()
    {
        int i = 0;
        //w_char
        //[] ToString(Char) - 'a'
        cArrInputs[i++] = 'a';
        //[] ToString(Char) - 'A'
        cArrInputs[i++] = 'A';
        //[] ToString(Char) - '@'
        cArrInputs[i++] = '@';
        //[] ToString(Char) - '\n'
        cArrInputs[i++] = '\n';

        i = 0;
        //w_char
        strCArrExps[i++] = "a";
        strCArrExps[i++] = "A";
        strCArrExps[i++] = "@";
        strCArrExps[i++] = "\n";
    }

    //[] ToString(Int32,Int32) - (Byte.MinValue, Base: 2, 8, 10, 16)	

    //[] ToString(Int32,Int32) - (128, Base: 2, 8, 10, 16)	

    //[] ToString(Int32,Int32) - (Byte.MinValue, Base: 2, 8, 10, 16)	
    private static void FillBaseIntInputs()
    {
        int i = 0;
        iArrBaseInputs[i++] = (int)Int32.MinValue;
        iArrBaseInputs[i++] = (int)0;
        iArrBaseInputs[i++] = (int)Int32.MaxValue;
    }

    //[] ToString(Int64,Int32) - (Byte.MinValue, Base: 2, 8, 10, 16)	

    //[] ToString(Int64,Int32) - (128, Base: 2, 8, 10, 16)	

    //[] ToString(Int64,Int32) - (Byte.MinValue, Base: 2, 8, 10, 16)	
    private static void FillBaseLongInputs()
    {
        int i = 0;
        lArrBaseInputs[i++] = Int64.MinValue;
        lArrBaseInputs[i++] = 0;
        lArrBaseInputs[i++] = Int64.MaxValue;
    }

    //[] ToString(Int16,Int32) - (Byte.MinValue, Base: 2, 8, 10, 16)	

    //[] ToString(Int16,Int32) - (128, Base: 2, 8, 10, 16)	

    //[] ToString(Int16,Int32) - (Byte.MinValue, Base: 2, 8, 10, 16)	
    private static void FillBaseShortInputs()
    {
        int i = 0;
        sArrBaseInputs[i++] = (short)Int16.MinValue;
        sArrBaseInputs[i++] = (short)0;
        sArrBaseInputs[i++] = (short)Int16.MaxValue;
    }

    //[] ToString(Byte,Int32) - (Byte.MinValue, Base: 2, 8, 10, 16)	

    //[] ToString(Byte,Int32) - (128, Base: 2, 8, 10, 16)	

    //[] ToString(Byte,Int32) - (Byte.MinValue, Base: 2, 8, 10, 16)	
    private static void FillBaseUCInputs()
    {
        int i = 0;
        uArrBaseInputs[i++] = Byte.MinValue;
        uArrBaseInputs[i++] = 128;
        uArrBaseInputs[i++] = Byte.MaxValue;
    }

    private static void FillBase2IntRslts()
    {
        int i = 0;
        strArrBaseExps[i++] = "10000000000000000000000000000000";//32 bits
        strArrBaseExps[i++] = "0";
        strArrBaseExps[i++] = "1111111111111111111111111111111";	//31 bits
    }

    private static void FillBase2LongRslts()
    {
        int i = 0;
        strArrBaseExps[i++] = "1000000000000000000000000000000000000000000000000000000000000000";	//64 bits
        strArrBaseExps[i++] = "0";
        strArrBaseExps[i++] = "111111111111111111111111111111111111111111111111111111111111111";		//63 bits
    }

    private static void FillBase2ShortRslts()
    {
        int i = 0;
        strArrBaseExps[i++] = "1000000000000000";	//16 bits
        strArrBaseExps[i++] = "0";
        strArrBaseExps[i++] = "111111111111111";		//15 bits
    }

    private static void FillBase2UCRslts()
    {
        int i = 0;
        strArrBaseExps[i++] = "0";
        strArrBaseExps[i++] = "10000000";	//8 bits
        strArrBaseExps[i++] = "11111111";	//8 bits
    }

    private static void FillBase8IntRslts()
    {
        int i = 0;
        strArrBaseExps[i++] = "20000000000";
        strArrBaseExps[i++] = "0";
        strArrBaseExps[i++] = "17777777777";
    }

    private static void FillBase8LongRslts()
    {
        int i = 0;
        strArrBaseExps[i++] = "1000000000000000000000";
        strArrBaseExps[i++] = "0";
        strArrBaseExps[i++] = "777777777777777777777";
    }

    private static void FillBase8ShortRslts()
    {
        int i = 0;
        strArrBaseExps[i++] = "100000";
        strArrBaseExps[i++] = "0";
        strArrBaseExps[i++] = "77777";
    }

    private static void FillBase8UCRslts()
    {
        int i = 0;

        //int
        strArrBaseExps[i++] = "0";
        strArrBaseExps[i++] = "200";
        strArrBaseExps[i++] = "377";
    }

    private static void FillBase10IntRslts()
    {
        int i = 0;

        //int
        strArrBaseExps[i++] = "-2147483648";
        strArrBaseExps[i++] = "0";
        strArrBaseExps[i++] = "2147483647";
    }

    private static void FillBase10LongRslts()
    {
        int i = 0;

        //int
        strArrBaseExps[i++] = "-9223372036854775808";
        strArrBaseExps[i++] = "0";
        strArrBaseExps[i++] = "9223372036854775807";
    }

    private static void FillBase10ShortRslts()
    {
        int i = 0;

        //int
        strArrBaseExps[i++] = "-32768";
        strArrBaseExps[i++] = "0";
        strArrBaseExps[i++] = "32767";
    }

    private static void FillBase10UCRslts()
    {
        int i = 0;

        //int
        strArrBaseExps[i++] = "0";
        strArrBaseExps[i++] = "128";
        strArrBaseExps[i++] = "255";
    }

    private static void FillBase16IntRslts()
    {
        int i = 0;

        //int
        strArrBaseExps[i++] = "80000000";
        strArrBaseExps[i++] = "0";
        strArrBaseExps[i++] = "7fffffff";
    }

    private static void FillBase16LongRslts()
    {
        int i = 0;

        //int
        strArrBaseExps[i++] = "8000000000000000";
        strArrBaseExps[i++] = "0";
        strArrBaseExps[i++] = "7fffffffffffffff";
    }

    private static void FillBase16ShortRslts()
    {
        int i = 0;

        //int
        strArrBaseExps[i++] = "8000";
        strArrBaseExps[i++] = "0";
        strArrBaseExps[i++] = "7fff";
    }

    private static void FillBase16UCRslts()
    {
        int i = 0;

        //int
        strArrBaseExps[i++] = "0";
        strArrBaseExps[i++] = "80";
        strArrBaseExps[i++] = "ff";
    }
}
