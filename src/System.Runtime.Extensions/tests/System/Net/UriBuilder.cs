﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Xunit;

namespace NCLFunctional.UriBuilderTest
{
    public class UriBuilderRefreshTest
    {
        private static Uri s_starterUri = new Uri("http://user:psw@host:9090/path/file.txt?query#fragment");

        [Fact]
        public void UriBuilder_ChangeScheme_Refreshed()
        {
            UriBuilder builder = new UriBuilder(s_starterUri);
            Assert.Equal(s_starterUri.Scheme, builder.Scheme);
            Assert.Equal(s_starterUri.Scheme, builder.Uri.Scheme);
            String newValue = "newvalue";
            builder.Scheme = newValue;
            Assert.Equal(newValue, builder.Scheme);
            Assert.Equal(newValue, builder.Uri.Scheme);
        }

        [Fact]
        public void UriBuilder_ChangeUser_Refreshed()
        {
            UriBuilder builder = new UriBuilder(s_starterUri);
            Assert.Equal(s_starterUri.UserInfo, builder.UserName + ":" + builder.Password);
            Assert.Equal(s_starterUri.UserInfo, builder.Uri.UserInfo);
            String newValue = "newvalue";
            builder.UserName = newValue;
            Assert.Equal(newValue, builder.UserName);
            Assert.Equal(newValue + ":" + builder.Password, builder.Uri.UserInfo);
        }

        [Fact]
        public void UriBuilder_ChangePassword_Refreshed()
        {
            UriBuilder builder = new UriBuilder(s_starterUri);
            Assert.Equal(s_starterUri.UserInfo, builder.UserName + ":" + builder.Password);
            Assert.Equal(s_starterUri.UserInfo, builder.Uri.UserInfo);
            String newValue = "newvalue";
            builder.Password = newValue;
            Assert.Equal(newValue, builder.Password);
            Assert.Equal(builder.UserName + ":" + newValue, builder.Uri.UserInfo);
        }

        [Fact]
        public void UriBuilder_ChangeHost_Refreshed()
        {
            UriBuilder builder = new UriBuilder(s_starterUri);
            Assert.Equal(s_starterUri.Host, builder.Host);
            Assert.Equal(s_starterUri.Host, builder.Uri.Host);
            String newValue = "newvalue";
            builder.Host = newValue;
            Assert.Equal(newValue, builder.Host);
            Assert.Equal(newValue, builder.Uri.Host);
        }

        [Fact]
        public void UriBuilder_ChangePort_Refreshed()
        {
            UriBuilder builder = new UriBuilder(s_starterUri);
            Assert.Equal(s_starterUri.Port, builder.Port);
            Assert.Equal(s_starterUri.Port, builder.Uri.Port);
            int newValue = 1010;
            builder.Port = newValue;
            Assert.Equal(newValue, builder.Port);
            Assert.Equal(newValue, builder.Uri.Port);
        }

        [Fact]
        public void UriBuilder_ChangePath_Refreshed()
        {
            UriBuilder builder = new UriBuilder(s_starterUri);
            Assert.Equal(s_starterUri.AbsolutePath, builder.Path);
            Assert.Equal(s_starterUri.AbsolutePath, builder.Uri.AbsolutePath);
            String newValue = "/newvalue";
            builder.Path = newValue;
            Assert.Equal(newValue, builder.Path);
            Assert.Equal(newValue, builder.Uri.AbsolutePath);
        }

        [Fact]
        public void UriBuilder_ChangeQuery_Refreshed()
        {
            UriBuilder builder = new UriBuilder(s_starterUri);
            Assert.Equal(s_starterUri.Query, builder.Query);
            Assert.Equal(s_starterUri.Query, builder.Uri.Query);
            String newValue = "newvalue";
            builder.Query = newValue;
            Assert.Equal("?" + newValue, builder.Query);
            Assert.Equal("?" + newValue, builder.Uri.Query);
        }

        [Fact]
        public void UriBuilder_ChangeFragment_Refreshed()
        {
            UriBuilder builder = new UriBuilder(s_starterUri);
            Assert.Equal(s_starterUri.Fragment, builder.Fragment);
            Assert.Equal(s_starterUri.Fragment, builder.Uri.Fragment);
            String newValue = "newvalue";
            builder.Fragment = newValue;
            Assert.Equal("#" + newValue, builder.Fragment);
            Assert.Equal("#" + newValue, builder.Uri.Fragment);
        }
    }
}
