// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.IO;
using Xunit;

namespace PathTests
{
    public class CombineTests
    {
        private static String s_separator = "\\"; // Was Path.DirectorySeparatorChar
        [Fact]
        public static void PathIsNull()
        {
            VerifyException<ArgumentNullException>(null);
        }

        [Fact]
        public static void VerifyEmptyPath()
        {
            //paths is empty
            Verify(new String[0]);
        }

        [Fact]
        public static void VerifyPath1Element()
        {
            //paths has 1 element
            Verify(new String[] { "abc" });
        }

        [Fact]
        public static void VerifyPath2Elements()
        {
            //paths has 2 elements
            Verify(new String[] { "abc", "def" });
        }

        [Fact]
        public static void VerifyPathManyElements()
        {
            //paths has many elements
            Verify(new String[] { "abc" + s_separator + "def", "def", "ghi", "jkl", "mno" });
        }
        [Fact]
        public static void PathIsNullWihtoutRootedAfterArgumentNull()
        {
            //any path is null without rooted after (ANE)
            CommonCasesException<ArgumentNullException>(null);
        }
        [Fact]
        public static void ContainsInvalidCharWithoutRootedAfterArgumentNull()
        {
            //any path contains invalid character without rooted after (AE)
            CommonCasesException<ArgumentException>("ab\"cd");
            CommonCasesException<ArgumentException>("ab\"cd");
            CommonCasesException<ArgumentException>("ab<cd");
            CommonCasesException<ArgumentException>("ab>cd");
            CommonCasesException<ArgumentException>("ab|cd");
            CommonCasesException<ArgumentException>("ab\bcd");
            CommonCasesException<ArgumentException>("ab\0cd");
            CommonCasesException<ArgumentException>("ab\tcd");
        }
        [Fact]
        public static void ContainsInvalidCharWithRootedAfterArgumentNull()
        {
            //any path contains invalid character with rooted after (AE)
            CommonCasesException<ArgumentException>("ab\"cd", s_separator + "abc");
            CommonCasesException<ArgumentException>("ab<cd", s_separator + "abc");
            CommonCasesException<ArgumentException>("ab>cd", s_separator + "abc");
            CommonCasesException<ArgumentException>("ab|cd", s_separator + "abc");
            CommonCasesException<ArgumentException>("ab\bcd", s_separator + "abc");
            CommonCasesException<ArgumentException>("ab\0cd", s_separator + "abc");
            CommonCasesException<ArgumentException>("ab\tcd", s_separator + "abc");
        }

        [Fact]
        public static void PathIsRooted()
        {
            //any path is rooted (starts with \, \\, A:)
            CommonCases(s_separator + "abc");
            CommonCases(s_separator + s_separator + "abc");
        }

        [Fact]
        public static void PathIsEmptyCommonCases()
        {
            //any path is empty (skipped)
            CommonCases("");
        }

        [Fact]
        public static void PathIsEmptyMultipleArguments()
        {
            //all paths are empty
            Verify(new String[] { "" });
            Verify(new String[] { "", "" });
            Verify(new String[] { "", "", "" });
            Verify(new String[] { "", "", "", "" });
            Verify(new String[] { "", "", "", "", "" });
        }

        [Fact]
        public static void PathIsSingleElement()
        {
            //any path is single element
            CommonCases("abc");
        }

        [Fact]
        public static void PathIsMultipleElements()
        {
            //any path is multiple element
            CommonCases(Path.Combine("abc", Path.Combine("def", "ghi")));
        }

        public static void NoPathIsRooted()
        {
            //no path is rooted
            CommonCases("abc");
        }

        private static void Verify(string[] paths)
        {
            String rVal;

            Logger.LogInformation("");
            Logger.LogInformation("Testing on combining: ");
            bool first = true;
            foreach (string s in paths)
            {
                if (!first)
                {
                    Logger.LogInformation(", ");
                }
                else
                {
                    first = false;
                }
                Logger.LogInformation(s);
            }
            Logger.LogInformation("");

            String expected = String.Empty;
            if (paths.Length > 0) expected = paths[0];
            for (int i = 1; i < paths.Length; i++)
            {
                expected = Path.Combine(expected, paths[i]);
            }

            //verify passed as array case
            rVal = Path.Combine(paths);

            Assert.Equal(expected, rVal);

            //verify passed as elements case
            switch (paths.Length)
            {
                case 0:
                    rVal = Path.Combine();
                    break;
                case 1:
                    rVal = Path.Combine(paths[0]);
                    break;
                case 2:
                    rVal = Path.Combine(paths[0], paths[1]);
                    break;
                case 3:
                    rVal = Path.Combine(paths[0], paths[1], paths[2]);
                    break;
                case 4:
                    rVal = Path.Combine(paths[0], paths[1], paths[2], paths[3]);
                    break;
                case 5:
                    rVal = Path.Combine(paths[0], paths[1], paths[2], paths[3], paths[4]);
                    break;
                default:
                    Assert.True(false, String.Format("Test doesn't cover case with {0} items passed seperately, add it.", paths.Length));
                    break;
            }

            Assert.Equal(expected, rVal);
        }

        public static void CommonCases(string testing)
        {
            Verify(new string[] { testing });

            Verify(new string[] { "abc", testing });
            Verify(new string[] { testing, "abc" });

            Verify(new string[] { "abc", "def", testing });
            Verify(new string[] { "abc", testing, "def" });
            Verify(new string[] { testing, "abc", "def" });

            Verify(new string[] { "abc", "def", "ghi", testing });
            Verify(new string[] { "abc", "def", testing, "ghi" });
            Verify(new string[] { "abc", testing, "def", "ghi" });
            Verify(new string[] { testing, "abc", "def", "ghi" });

            Verify(new string[] { "abc", "def", "ghi", "jkl", testing });
            Verify(new string[] { "abc", "def", "ghi", testing, "jkl" });
            Verify(new string[] { "abc", "def", testing, "ghi", "jkl" });
            Verify(new string[] { "abc", testing, "def", "ghi", "jkl" });
            Verify(new string[] { testing, "abc", "def", "ghi", "jkl" });
        }

        private static void VerifyException<T>(string[] paths) where T : Exception
        {
            String rVal;

            Logger.LogInformation("");
            Logger.LogInformation("Testing on combining: ");
            if (paths != null)
            {
                bool first = true;
                foreach (string s in paths)
                {
                    if (!first)
                    {
                        Logger.LogInformation(", ");
                    }
                    else
                    {
                        first = false;
                    }
                    Logger.LogInformation("{0}", s);
                }
                Logger.LogInformation("");
            }

            Assert.Throws<T>(() => { rVal = Path.Combine(paths); });

            //verify passed as elements case
            if (paths != null)
            {
                if (paths.Length >= 1 && paths.Length <= 5)
                {
                    Assert.Throws<T>(() =>
                    {
                        switch (paths.Length)
                        {
                            case 0:
                                rVal = Path.Combine();
                                break;
                            case 1:
                                rVal = Path.Combine(paths[0]);
                                break;
                            case 2:
                                rVal = Path.Combine(paths[0], paths[1]);
                                break;
                            case 3:
                                rVal = Path.Combine(paths[0], paths[1], paths[2]);
                                break;
                            case 4:
                                rVal = Path.Combine(paths[0], paths[1], paths[2], paths[3]);
                                break;
                            case 5:
                                rVal = Path.Combine(paths[0], paths[1], paths[2], paths[3], paths[4]);
                                break;
                        }
                    });
                }
                else
                {
                    Assert.True(false, String.Format("Test doesn't cover case with {0} items passed seperately, add it.", paths.Length));
                }
            }
        }

        private static void CommonCasesException<T>(string testing) where T : Exception
        {
            VerifyException<T>(new string[] { testing });

            VerifyException<T>(new string[] { "abc", testing });
            VerifyException<T>(new string[] { testing, "abc" });

            VerifyException<T>(new string[] { "abc", "def", testing });
            VerifyException<T>(new string[] { "abc", testing, "def" });
            VerifyException<T>(new string[] { testing, "abc", "def" });

            VerifyException<T>(new string[] { "abc", "def", "ghi", testing });
            VerifyException<T>(new string[] { "abc", "def", testing, "ghi" });
            VerifyException<T>(new string[] { "abc", testing, "def", "ghi" });
            VerifyException<T>(new string[] { testing, "abc", "def", "ghi" });

            VerifyException<T>(new string[] { "abc", "def", "ghi", "jkl", testing });
            VerifyException<T>(new string[] { "abc", "def", "ghi", testing, "jkl" });
            VerifyException<T>(new string[] { "abc", "def", testing, "ghi", "jkl" });
            VerifyException<T>(new string[] { "abc", testing, "def", "ghi", "jkl" });
            VerifyException<T>(new string[] { testing, "abc", "def", "ghi", "jkl" });
        }

        private static void CommonCasesException<T>(string testing, string testing2) where T : Exception
        {
            VerifyException<T>(new string[] { testing, testing2 });

            VerifyException<T>(new string[] { "abc", testing, testing2 });
            VerifyException<T>(new string[] { testing, "abc", testing2 });
            VerifyException<T>(new string[] { testing, testing2, "def" });

            VerifyException<T>(new string[] { "abc", "def", testing, testing2 });
            VerifyException<T>(new string[] { "abc", testing, "def", testing2 });
            VerifyException<T>(new string[] { "abc", testing, testing2, "ghi" });
            VerifyException<T>(new string[] { testing, "abc", "def", testing2 });
            VerifyException<T>(new string[] { testing, "abc", testing2, "ghi" });
            VerifyException<T>(new string[] { testing, testing2, "def", "ghi" });

            VerifyException<T>(new string[] { "abc", "def", "ghi", testing, testing2 });
            VerifyException<T>(new string[] { "abc", "def", testing, "ghi", testing2 });
            VerifyException<T>(new string[] { "abc", "def", testing, testing2, "jkl" });
            VerifyException<T>(new string[] { "abc", testing, "def", "ghi", testing2 });
            VerifyException<T>(new string[] { "abc", testing, "def", testing2, "jkl" });
            VerifyException<T>(new string[] { "abc", testing, testing2, "ghi", "jkl" });
            VerifyException<T>(new string[] { testing, "abc", "def", "ghi", testing2 });
            VerifyException<T>(new string[] { testing, "abc", "def", testing2, "jkl" });
            VerifyException<T>(new string[] { testing, "abc", testing2, "ghi", "jkl" });
            VerifyException<T>(new string[] { testing, testing2, "def", "ghi", "jkl" });
        }
    }
}
