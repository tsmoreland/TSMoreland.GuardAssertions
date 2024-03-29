﻿//
// Copyright © 2021 Terry Moreland
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), 
// to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
// and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 
using System;
using TSMoreland.GuardAssertions.Contracts;

namespace TSMoreland.GuardAssertions;

public sealed partial class Guard 
{
    /// <summary>
    /// Private Constructor to ensure singleton access is only public method of use
    /// </summary>
    private Guard()
    {
    }

    private static readonly Lazy<Guard> _instance = new(() => new Guard());

    /// <summary>
    /// Singleton instance providing access to Guard Assertions methods
    /// </summary>
    public static IGuardAssertions Against => _instance.Value;

    /// <summary>
    /// Singleton instance providing access to Guard Checks
    /// </summary>
    public static IValidationChecks Check => _instance.Value;
}
