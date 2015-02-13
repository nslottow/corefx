 namespace NCLFunctional.UriBuilderTest
{
    using CoreFXTestLibrary;
    using System;

    [TestClass]
    public class UriBuilderRefreshTest
    {
        private static Uri StarterUri = new Uri("http://user:psw@host:9090/path/file.txt?query#fragment");

        [TestMethod]
        public void UriBuilder_ChangeScheme_Refreshed()
        {
            UriBuilder builder = new UriBuilder(StarterUri);
            Assert.AreEqual<String>(StarterUri.Scheme, builder.Scheme);
            Assert.AreEqual<String>(StarterUri.Scheme, builder.Uri.Scheme);
            String newValue = "newvalue";
            builder.Scheme = newValue;
            Assert.AreEqual<String>(newValue, builder.Scheme);
            Assert.AreEqual<String>(newValue, builder.Uri.Scheme);
        }

        [TestMethod]
        public void UriBuilder_ChangeUser_Refreshed()
        {
            UriBuilder builder = new UriBuilder(StarterUri);
            Assert.AreEqual<String>(StarterUri.UserInfo, builder.UserName + ":" + builder.Password);
            Assert.AreEqual<String>(StarterUri.UserInfo, builder.Uri.UserInfo);
            String newValue = "newvalue";
            builder.UserName = newValue;
            Assert.AreEqual<String>(newValue, builder.UserName);
            Assert.AreEqual<String>(newValue + ":" + builder.Password, builder.Uri.UserInfo);
        }

        [TestMethod]
        public void UriBuilder_ChangePassword_Refreshed()
        {
            UriBuilder builder = new UriBuilder(StarterUri);
            Assert.AreEqual<String>(StarterUri.UserInfo, builder.UserName + ":" + builder.Password);
            Assert.AreEqual<String>(StarterUri.UserInfo, builder.Uri.UserInfo);
            String newValue = "newvalue";
            builder.Password = newValue;
            Assert.AreEqual<String>(newValue, builder.Password);
            Assert.AreEqual<String>(builder.UserName + ":" + newValue, builder.Uri.UserInfo);
        }

        [TestMethod]
        public void UriBuilder_ChangeHost_Refreshed()
        {
            UriBuilder builder = new UriBuilder(StarterUri);
            Assert.AreEqual<String>(StarterUri.Host, builder.Host);
            Assert.AreEqual<String>(StarterUri.Host, builder.Uri.Host);
            String newValue = "newvalue";
            builder.Host = newValue;
            Assert.AreEqual<String>(newValue, builder.Host);
            Assert.AreEqual<String>(newValue, builder.Uri.Host);
        }

        [TestMethod]
        public void UriBuilder_ChangePort_Refreshed()
        {
            UriBuilder builder = new UriBuilder(StarterUri);
            Assert.AreEqual<int>(StarterUri.Port, builder.Port);
            Assert.AreEqual<int>(StarterUri.Port, builder.Uri.Port);
            int newValue = 1010;
            builder.Port = newValue;
            Assert.AreEqual<int>(newValue, builder.Port);
            Assert.AreEqual<int>(newValue, builder.Uri.Port);
        }

        [TestMethod]
        public void UriBuilder_ChangePath_Refreshed()
        {
            UriBuilder builder = new UriBuilder(StarterUri);
            Assert.AreEqual<String>(StarterUri.AbsolutePath, builder.Path);
            Assert.AreEqual<String>(StarterUri.AbsolutePath, builder.Uri.AbsolutePath);
            String newValue = "/newvalue";
            builder.Path = newValue;
            Assert.AreEqual<String>(newValue, builder.Path);
            Assert.AreEqual<String>(newValue, builder.Uri.AbsolutePath);
        }

        [TestMethod]
        public void UriBuilder_ChangeQuery_Refreshed()
        {
            UriBuilder builder = new UriBuilder(StarterUri);
            Assert.AreEqual<String>(StarterUri.Query, builder.Query);
            Assert.AreEqual<String>(StarterUri.Query, builder.Uri.Query);
            String newValue = "newvalue";
            builder.Query = newValue;
            Assert.AreEqual<String>("?" + newValue, builder.Query);
            Assert.AreEqual<String>("?" + newValue, builder.Uri.Query);
        }

        [TestMethod]
        public void UriBuilder_ChangeFragment_Refreshed()
        {
            UriBuilder builder = new UriBuilder(StarterUri);
            Assert.AreEqual<String>(StarterUri.Fragment, builder.Fragment);
            Assert.AreEqual<String>(StarterUri.Fragment, builder.Uri.Fragment);
            String newValue = "newvalue";
            builder.Fragment = newValue;
            Assert.AreEqual<String>("#" + newValue, builder.Fragment);
            Assert.AreEqual<String>("#" + newValue, builder.Uri.Fragment);
        }
    }
}
