using System;
using CoreFXTestLibrary;

[TestClass]
public class SetEnvironmentVariable
{
    const int MAX_VAR_LENGTH_ALLOWED = 32767;

    [TestMethod]
    public void NullVariableThrowsArgumentNull()
    {
        Assert.Throws<ArgumentNullException>(() => Environment.SetEnvironmentVariable(null, "foo"));
    }

    [TestMethod]
    public void IncorrectVariableThrowsArgument()
    {
        Assert.Throws<ArgumentException>(() => Environment.SetEnvironmentVariable(String.Empty, "foo"));
        Assert.Throws<ArgumentException>(() => Environment.SetEnvironmentVariable('\x00'.ToString(), "foo"));
        Assert.Throws<ArgumentException>(() => Environment.SetEnvironmentVariable("Variable=Something", "foo"));

        string varWithLenLongerThanAllowed = new string('c', MAX_VAR_LENGTH_ALLOWED + 1);
        Assert.Throws<ArgumentException>(() => Environment.SetEnvironmentVariable(varWithLenLongerThanAllowed, "foo"));
    }

    [TestMethod]
    public void SetEnvironmentVariable_Default()
    {
        const string varName = "Test_SetEnvironmentVariable_Default";
        string value = "true";
        Environment.SetEnvironmentVariable(varName, value);

        // Check whether the variable exists.
        Assert.AreEqual(Environment.GetEnvironmentVariable(varName), value, "SetEnvironmentVariable_Default failed");

        // Clean the value.
        Environment.SetEnvironmentVariable(varName, null);
    }

    [TestMethod]
    public void ModifyEnvironmentVariable()
    {
        string varName = "Test_ModifyEnvironmentVariable";
        string value = "false";

        // First set the value to something and then change it and ensure that it gets modified.
        Environment.SetEnvironmentVariable(varName, "true");
        Environment.SetEnvironmentVariable(varName, value);

        // Check whether the variable exists.
        Assert.AreEqual(Environment.GetEnvironmentVariable(varName), value, "ModifyEnvironmentVariable failed");

        // Clean the value.
        Environment.SetEnvironmentVariable(varName, null);
    }

    [TestMethod]
    public void DeleteEnvironmentVariable()
    {
        string varName = "Test_DeleteEnvironmentVariable";
        string value = "false";

        // First set the value to something and then change it and ensure that it gets modified.
        Environment.SetEnvironmentVariable(varName, value);
        Environment.SetEnvironmentVariable(varName, String.Empty);

        // Check whether the variable exists.
        Assert.AreEqual(Environment.GetEnvironmentVariable(varName), null, "DeleteEnvironmentVariable001 failed");

        Environment.SetEnvironmentVariable(varName, value);
        Environment.SetEnvironmentVariable(varName, null);
        Assert.AreEqual(Environment.GetEnvironmentVariable(varName), null, "DeleteEnvironmentVariable002 failed");

        Environment.SetEnvironmentVariable(varName, value);
        Environment.SetEnvironmentVariable(varName, '\u0000'.ToString());
        Assert.AreEqual(Environment.GetEnvironmentVariable(varName), null, "DeleteEnvironmentVariable003 failed");


        // Check that the varName with non-initial zero characters work during deleting.
        string varName_initial = "Begin_DeleteEnvironmentVariable";
        string varName_end = "End_DeleteEnvironmentVariable";
        string hexDecimal = '\u0000'.ToString();

        varName = varName_initial + hexDecimal + varName_end;
        Environment.SetEnvironmentVariable(varName, "true");
        Environment.SetEnvironmentVariable(varName, String.Empty);
        Assert.AreEqual(Environment.GetEnvironmentVariable(varName), null, "DeleteEnvironmentVariable004 failed");
        Assert.AreEqual(Environment.GetEnvironmentVariable(varName_initial), null, "DeleteEnvironmentVariable005 failed");

        //Make sure we remove the environmentVariables.
        Environment.SetEnvironmentVariable(varName, String.Empty);

        //Check that the varValue with non-initial zero characters also work during deleting.
        hexDecimal = '\u0000'.ToString();
        value = hexDecimal + "Foo";
        varName = "Test_DeleteEnvironmentVariable1";
        Environment.SetEnvironmentVariable(varName, value);
        Assert.AreEqual(Environment.GetEnvironmentVariable(varName), null, "DeleteEnvironmentVariable006 failed");
        Environment.SetEnvironmentVariable(varName, String.Empty);
    }

    [TestMethod]
    public void TestNonInitialZeroCharacterInVariableName()
    {
        string varName_initial = "Begin";
        string varName_end = "End";
        string hexDecimal = '\u0000'.ToString();

        string varName = varName_initial + hexDecimal + varName_end;
        string value = "true";

        Environment.SetEnvironmentVariable(varName, value);
        Assert.AreEqual(Environment.GetEnvironmentVariable(varName_initial), "true", "TestNonInitialZeroCharacterInVariableName001 failed");

        Environment.SetEnvironmentVariable(varName, String.Empty);
        Environment.SetEnvironmentVariable(varName_initial, String.Empty);
    }

    [TestMethod]
    public void TestNonInitialZeroCharacterInValue()
    {
        string varName = "Test_TestNonInitialZeroCharacterInValue";
        string value_initial = "Begin";
        string value_end = "End";
        string hexDecimal = '\u0000'.ToString();

        string value = value_initial + hexDecimal + value_end;
        Environment.SetEnvironmentVariable(varName, value);
        Assert.AreEqual(Environment.GetEnvironmentVariable(varName), value_initial, "TestNonInitialZeroCharacterInVariableName001 failed");

        Environment.SetEnvironmentVariable(varName, String.Empty);
    }

    [TestMethod]
    public void TestDeletingNonExistingEnvironmentVariable()
    {
        string varName = "Test_TestDeletingNonExistingEnvironmentVariable";

        if (Environment.GetEnvironmentVariable(varName) != null)
        {
            Environment.SetEnvironmentVariable(varName, null);
        }

        try
        {
            Environment.SetEnvironmentVariable("TestDeletingNonExistingEnvironmentVariable", String.Empty);
        }
        catch (Exception ex)
        {
            Assert.Fail("TestDeletingNonExistingEnvironmentVariable failed: " + ex);
        }
    }

}