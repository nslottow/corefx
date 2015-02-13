// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

using Xunit;

namespace NCLFunctional.UriBuilderTest
{
    public class UriBuilderRefreshTest
    {
        private static Uri s_StarterUri = new Uri("http://user:psw@host:9090/path/file.txt?query#fragment");

        [Fact]
        public void UriBuilder_ChangeScheme_Refreshed()
        {
            UriBuilder builder = new UriBuilder(s_StarterUri);
            Assert.Equal<String>(s_StarterUri.Scheme, builder.Scheme);
            Assert.Equal<String>(s_StarterUri.Scheme, builder.Uri.Scheme);
            String newValue = "newvalue";
            builder.Scheme = newValue;
            Assert.Equal<String>(newValue, builder.Scheme);
            Assert.Equal<String>(newValue, builder.Uri.Scheme);
        }

        [Fact]
        public void UriBuilder_ChangeUser_Refreshed()
        {
            UriBuilder builder = new UriBuilder(s_StarterUri);
            Assert.Equal<String>(s_StarterUri.UserInfo, builder.UserName + ":" + builder.Password);
            Assert.Equal<String>(s_StarterUri.UserInfo, builder.Uri.UserInfo);
            String newValue = "newvalue";
            builder.UserName = newValue;
            Assert.Equal<String>(newValue, builder.UserName);
            Assert.Equal<String>(newValue + ":" + builder.Password, builder.Uri.UserInfo);
        }

        [Fact]
        public void UriBuilder_ChangePassword_Refreshed()
        {
            UriBuilder builder = new UriBuilder(s_StarterUri);
            Assert.Equal<String>(s_StarterUri.UserInfo, builder.UserName + ":" + builder.Password);
            Assert.Equal<String>(s_StarterUri.UserInfo, builder.Uri.UserInfo);
            String newValue = "newvalue";
            builder.Password = newValue;
            Assert.Equal<String>(newValue, builder.Password);
            Assert.Equal<String>(builder.UserName + ":" + newValue, builder.Uri.UserInfo);
        }

        [Fact]
        public void UriBuilder_ChangeHost_Refreshed()
        {
            UriBuilder builder = new UriBuilder(s_StarterUri);
            Assert.Equal<String>(s_StarterUri.Host, builder.Host);
            Assert.Equal<String>(s_StarterUri.Host, builder.Uri.Host);
            String newValue = "newvalue";
            builder.Host = newValue;
            Assert.Equal<String>(newValue, builder.Host);
            Assert.Equal<String>(newValue, builder.Uri.Host);
        }

        [Fact]
        public void UriBuilder_ChangePort_Refreshed()
        {
            UriBuilder builder = new UriBuilder(s_StarterUri);
            Assert.Equal<int>(s_StarterUri.Port, builder.Port);
            Assert.Equal<int>(s_StarterUri.Port, builder.Uri.Port);
            int newValue = 1010;
            builder.Port = newValue;
            Assert.Equal<int>(newValue, builder.Port);
            Assert.Equal<int>(newValue, builder.Uri.Port);
        }

        [Fact]
        public void UriBuilder_ChangePath_Refreshed()
        {
            UriBuilder builder = new UriBuilder(s_StarterUri);
            Assert.Equal<String>(s_StarterUri.AbsolutePath, builder.Path);
            Assert.Equal<String>(s_StarterUri.AbsolutePath, builder.Uri.AbsolutePath);
            String newValue = "/newvalue";
            builder.Path = newValue;
            Assert.Equal<String>(newValue, builder.Path);
            Assert.Equal<String>(newValue, builder.Uri.AbsolutePath);
        }

        [Fact]
        public void UriBuilder_ChangeQuery_Refreshed()
        {
            UriBuilder builder = new UriBuilder(s_StarterUri);
            Assert.Equal<String>(s_StarterUri.Query, builder.Query);
            Assert.Equal<String>(s_StarterUri.Query, builder.Uri.Query);
            String newValue = "newvalue";
            builder.Query = newValue;
            Assert.Equal<String>("?" + newValue, builder.Query);
            Assert.Equal<String>("?" + newValue, builder.Uri.Query);
        }

        [Fact]
        public void UriBuilder_ChangeFragment_Refreshed()
        {
            UriBuilder builder = new UriBuilder(s_StarterUri);
            Assert.Equal<String>(s_StarterUri.Fragment, builder.Fragment);
            Assert.Equal<String>(s_StarterUri.Fragment, builder.Uri.Fragment);
            String newValue = "newvalue";
            builder.Fragment = newValue;
            Assert.Equal<String>("#" + newValue, builder.Fragment);
            Assert.Equal<String>("#" + newValue, builder.Uri.Fragment);
        }
    }
}
