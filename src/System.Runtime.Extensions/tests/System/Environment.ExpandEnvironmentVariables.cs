using System;
using System.Collections;
using System.Text;
using System.Runtime.InteropServices;
using CoreFXTestLibrary;

[TestClass]
public class ExpandEnvironmentVariables
{
    [TestMethod]
    public void NullArgumentThrowsArgumentNull()
    {
        Assert.Throws<ArgumentNullException>(() => Environment.ExpandEnvironmentVariables(null));
    }

    [TestMethod]
    public void EmptyArgumentReturnsEmpty()
    {
        Assert.AreEqual(String.Empty, Environment.ExpandEnvironmentVariables(String.Empty));
    }

    [TestMethod]
    public void ExpansionOfAllVariablesReturnedByGetEnvironmentVariablesSucceeds()
    {
        bool atLeastOne = false;
        StringBuilder input = new StringBuilder();
        StringBuilder expected = new StringBuilder();

        foreach (DictionaryEntry entry in Environment.GetEnvironmentVariables())
        {
            string key = (string)entry.Key;
            if (key.IndexOf('%') >= 0)
            {
                continue;
            }

            input.Append('%');
            input.Append(key);
            input.Append('%');
            expected.Append((string)entry.Value);
            atLeastOne = true;
        }

        Assert.AreEqual(atLeastOne, !GetEnvironmentVariable.PlatformBehavesAsIfNoVariablesAreEverSet);
        Assert.AreEqual(expected.ToString(), Environment.ExpandEnvironmentVariables(input.ToString()));
    }

    [TestMethod]
    public void VariableThatDoesNotExistGoesThroughUnexpanded()
    {
        string unexpanded = "%TestVariable_ThatDoesNotExist%";
        Assert.AreEqual(unexpanded, Environment.ExpandEnvironmentVariables(unexpanded));
    }

    [TestMethod]
    public void StringWithNoEnvironmentVariablesGoesThroughUnchnaged()
    {
        Assert.AreEqual("Hello World", Environment.ExpandEnvironmentVariables("Hello World"));
    }

    [TestMethod]
    public void PotentiallyAmbiguousInputIsHandledCorrectly()
    {
        int count = 6;
        string prefix = "ExpandTestVar_@";
        string[] keys = new string[count];
        string[] values = new string[count];

        for (int i = 0; i < count; i++)
        {
            keys[i] = prefix + (i + 1);
            Assert.AreEqual(null, Environment.GetEnvironmentVariable(keys[i]));

            if (i < 3)
            {
                Assert.AreEqual(true, SetEnvironmentVariable(keys[i], "value" + (i + 1)));
            }
        }

        string set1   = keys[0], set2   = keys[1], set3   = keys[2];
        string unset1 = keys[3], unset2 = keys[4], unset3 = keys[5];
        string value1, value2, value3;

        if (GetEnvironmentVariable.PlatformBehavesAsIfNoVariablesAreEverSet)
        {
            value1 = "%" + set1 + "%";
            value2 = "%" + set2 + "%";
            value3 = "%" + set3 + "%";
        }
        else
        {
            value1 = "value1";
            value2 = "value2";
            value3 = "value3";
        }

        Test( "%",
              "%" );

        Test( "%%",
              "%%" );

        Test( "%%%",
              "%%%" );

        Test( ("%" +  set1    + "%") + set2 + ("%" + set3 + "%"),
               value1                + set2 + value3 );

        Test( "%" + ("%" + set1 + "%"),
              "%" + value1 );

        Test( "%%" + ("%" + set1 + "%") + "%%",
              "%%" + value1 + "%%" );

        Test( "%%%" + ("%" + set1 + "%") + "%",
              "%%%" + value1 + "%");

        Test( ("%" + set1 + "%") + ("%" + set2 + "%"),
              value1             + value2 );

        Test( ("%" + unset1 + "%") + ("%" + set1 + "%"),
              ("%" + unset1 + "%") + value1 );

        Test( ("%" + set2 + "%") + "hello" + ("%" + unset2 + "%"),
              value2             + "hello" + ("%" + unset2 + "%") );

        Test( ("%" + unset2 + "%") + ("%" + unset3 + "%"),
              ("%" + unset2 + "%") + ("%" + unset3 + "%") );

        Test( "% " + set1 + "%",
              "% " + set1 + "%" );

        Test( "%  " + set1 +  "  %",
              "%  " + set1 +  "  %" );

        Test( "%\t" + set1 + "%",
              "%\t" + set1 + "%" );

        Test( "%%% " + set1 + "%",
              "%%% " + set1 + "%" );
    }

    private void Test(string toExpand, string expectedExpansion)
    {
        Assert.AreEqual(expectedExpansion, Environment.ExpandEnvironmentVariables(toExpand));
        Assert.AreEqual("qq" + expectedExpansion + "rr", "qq" + Environment.ExpandEnvironmentVariables(toExpand) +"rr");
    }

    [DllImport("api-ms-win-core-processenvironment-l1-1-0.dll", CharSet=CharSet.Unicode, SetLastError=true)]
    private static extern bool SetEnvironmentVariable(string lpName, string lpValue);
}
