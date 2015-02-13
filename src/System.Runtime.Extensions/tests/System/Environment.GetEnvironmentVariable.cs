using System;
using System.Collections;
using System.Runtime.InteropServices;
using CoreFXTestLibrary;

[TestClass]
public class GetEnvironmentVariable
{
    // TODO: Hard-coded for now -- check with test team how to inject this based
    //       on platform capability.
    internal static readonly bool PlatformBehavesAsIfNoVariablesAreEverSet = false;

    [TestMethod]
    public void NullVariableThrowsArgumentNull()
    {
        Assert.Throws<ArgumentNullException>(() => Environment.GetEnvironmentVariable(null));
    }

    [TestMethod]
    public void EmptyVariableReturnsNull()
    {
        Assert.AreEqual(null, Environment.GetEnvironmentVariable(String.Empty));
    }

    [TestMethod]
    public void RandomLongVariableNameCanRoundTrip()
    {
        // NOTE: The limit of 32766 characters enforced by dekstop
        // SetEnvironmentVariable (not in the contract) is antiquated. I was
        // able to create ~1GB names and values on my Windows 8.1 box. On
        // desktop, GetEnvironmentVariable throws OOM during its attempt to
        // demand huge EnvironmentPermission well before that. Also, the old
        // test for long name case wasn't very good: it just checked that an
        // arbitrary long name > 32766 characters returned null (not found), but
        // that had nothing to do with the limit, the variable was simply not
        // found!

        string variable = "LongVariable_" + new string('@', 33000);
        Assert.AreEqual(true, SetEnvironmentVariable(variable, "TestValue"));
        string expectedValue = PlatformBehavesAsIfNoVariablesAreEverSet ? null : "TestValue";

        Assert.AreEqual(expectedValue, Environment.GetEnvironmentVariable(variable));
        Assert.AreEqual(true, SetEnvironmentVariable(variable, null));
    }

    [TestMethod]
    public void RandomVariableThatDoesNotExistReturnsNull()
    {
        string variable = "TestVariable_SurelyThisDoesNotExist";
        Assert.AreEqual(null, Environment.GetEnvironmentVariable(variable));
    }

    [TestMethod]
    public void VariablesAreCaseInsensitive()
    {
        Assert.AreEqual(true, SetEnvironmentVariable("ThisIsATestEnvironmentVariable", "TestValue"));
        string expectedValue = PlatformBehavesAsIfNoVariablesAreEverSet ? null : "TestValue";

        Assert.AreEqual(expectedValue, Environment.GetEnvironmentVariable("ThisIsATestEnvironmentVariable"));
        Assert.AreEqual(expectedValue, Environment.GetEnvironmentVariable("thisisatestenvironmentvariable"));
        Assert.AreEqual(expectedValue, Environment.GetEnvironmentVariable("THISISATESTENVIRONMENTVARIABLE"));
        Assert.AreEqual(expectedValue, Environment.GetEnvironmentVariable("ThISISATeSTENVIRoNMEnTVaRIABLE"));
        Assert.AreEqual(true, SetEnvironmentVariable("ThisIsATestEnvironmentVariable", null));
    }

    [TestMethod]
    public void CanGetAllVariablesIndividually()
    {
        bool atLeastOne = false;

        IDictionary envBlock = Environment.GetEnvironmentVariables();

        foreach (DictionaryEntry envEntry in envBlock)
        {
            string name = (string)envEntry.Key;
            string value = Environment.GetEnvironmentVariable(name);
            Assert.AreEqual(envEntry.Value, value, "Variable Name: " + name);
            atLeastOne = true;
        }

        Assert.AreEqual(atLeastOne, !PlatformBehavesAsIfNoVariablesAreEverSet);
    }

    [DllImport("api-ms-win-core-processenvironment-l1-1-0.dll", CharSet=CharSet.Unicode, SetLastError=true)]
    private static extern bool SetEnvironmentVariable(string lpName, string lpValue);
}
