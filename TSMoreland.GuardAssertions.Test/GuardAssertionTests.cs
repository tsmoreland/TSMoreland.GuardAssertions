//
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
using NUnit.Framework;
using TSMoreland.GuardAssertions.Contracts;

namespace TSMoreland.GuardAssertions.Test;

public sealed class GuardAssertionTests
{
    private IGuardAssertions GuardAgainst { get; set; } = null!;
    private const string _parameterName = "parameter";
    private static object[] _invalidGuids =
    {
        new object[] {typeof(ArgumentNullException), null!},
        new object[] {typeof(ArgumentException), Guid.Empty},
    };


    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        GuardAgainst = Guard.Against;
    }

    [Test]
    public void ArgumentNull_ThrowsArgumentNullException_WhenArugmentIsNull()
    {
        var ex = Assert.Throws<ArgumentNullException>(() => GuardAgainst.ArgumentNull(null, _parameterName));
        Assert.That(ex!.ParamName, Is.EqualTo(_parameterName));
    }

    [Test]
    public void ArgumentNull_ArgumentNullExceptionParameterIsExpectedValue_WhenArugmentIsNull()
    {
        var ex = Assert.Throws<ArgumentNullException>(() => GuardAgainst.ArgumentNull(null, _parameterName));
        Assert.That(ex?.ParamName, Is.EqualTo(_parameterName));
    }

    [Test]
    public void ArgumentNull_DoesNotThrowException_WhenArgumentIsNotNull()
    {
        Assert.DoesNotThrow(() => GuardAgainst.ArgumentNull(new object(), _parameterName));
    }

    [TestCase(typeof(ArgumentNullException), null)]
    [TestCase(typeof(ArgumentException), "")]
    public void ArgumentNullOrEmpty_ThrowsException_WhenArgumentIs(Type exceptionType, string? value)
    {
        var ex = Assert.Throws(exceptionType, () => GuardAgainst.ArgumentNullOrEmpty(value, _parameterName));
        Assert.That((ex as ArgumentException)?.ParamName, Is.EqualTo(_parameterName));
    }

    [TestCase(" ")]
    [TestCase("alpha")]
    public void ArgumentNullOrEmpty_DoesNotThrrow_WhenArgumentIsNonEmpty(string? value)
    {
        Assert.DoesNotThrow(() => GuardAgainst.ArgumentNullOrEmpty(value, _parameterName));
    }

    [TestCase(typeof(ArgumentNullException), null)]
    [TestCase(typeof(ArgumentException), "")]
    [TestCase(typeof(ArgumentException), " ")]
    [TestCase(typeof(ArgumentException), "\t")]
    [TestCase(typeof(ArgumentException), "\n")]
    public void ArgumentNullOrWhiteSpace_ThrowsException_WhenArgumentIs(Type exceptionType, string? value)
    {
        var ex = Assert.Throws(exceptionType, () => GuardAgainst.ArgumentNullOrWhitespace(value, _parameterName));
        Assert.That((ex as ArgumentException)?.ParamName, Is.EqualTo(_parameterName));
    }

    [Test]
    public void ArgumentNullOrWhitespace_DoesNotThrrow_WhenArgumentIsNonWhitespace()
    {
        Assert.DoesNotThrow(() => GuardAgainst.ArgumentNullOrWhitespace("alpha", _parameterName));
    }

    [TestCaseSource(nameof(_invalidGuids))]
    public void ArgumentNullOrEmpty_ThrowsException_WhenArgumentGuidIs(Type exceptionType, Guid? value)
    {
        Assert.Throws(exceptionType, () => GuardAgainst.ArgumentNullOrEmpty(value, _parameterName));
    }

    [Test]
    public void ArgumentNullOrEmpty_DoesNotThrrow_WhenArgumentGuidIsNonEmpty()
    {
        Guid? uuid = new Guid("E3670C5C-73EB-4E90-832F-6183675FDC33");
        Assert.DoesNotThrow(() => GuardAgainst.ArgumentNullOrEmpty(uuid, _parameterName));
    }

    [Test]
    public void ShortArgumentOutOfRange_ThrowsArgumentOutOfRangeException_WhenLessThanMinimum()
    {
        const short minimum = 1;
        const short maximum = 10;
        const short value = minimum - 1;

        var ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
            GuardAgainst.ArgumentOutOfRange(value, minimum, maximum, _parameterName));
        Assert.That(ex!.ParamName, Is.EqualTo(_parameterName));
    }

    [Test]
    public void ShortArgumentOutOfRange_ThrowsArgumentException_WhenMinimumIsGreaterThanMaximum()
    {
        const short minimum = 10;
        const short maximum = 1;
        const short value = 5;

        var ex = Assert.Throws<ArgumentException>(() =>
            GuardAgainst.ArgumentOutOfRange(value, minimum, maximum, _parameterName));
        Assert.That(ex!.ParamName, Is.EqualTo(nameof(minimum)));
    }

    [TestCase(0)]
    [TestCase(1)]
    public void ShortArgumentOutOfRange_ThrowsArgumentOutOfRangeException_WhenGreaterThanOrEqualToMaximum(short incrementBy)
    {
        const short minimum = 1;
        const short maximum = 10;
        short value = (short)(maximum + incrementBy);

        var ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
            GuardAgainst.ArgumentOutOfRange(value, minimum, maximum, _parameterName));
        Assert.That(ex!.ParamName, Is.EqualTo(_parameterName));
    }

    [Test]
    public void ShortArgumenOutOfRange_DoesNotThrow_WhenArgumentEqualToMinimum()
    {
        const short minimum = 1;
        const short maximum = 10;
        Assert.DoesNotThrow(() => GuardAgainst.ArgumentOutOfRange(minimum, minimum, maximum, _parameterName));
    }

    [Test]
    public void ShortArgumenOutOfRange_DoesNotThrow_WhenArgumentInRange()
    {
        const short minimum = 1;
        const short maximum = 10;
        const short value = 5;
        Assert.DoesNotThrow(() => GuardAgainst.ArgumentOutOfRange(value, minimum, maximum, _parameterName));
    }


    [Test]
    public void Int32ArgumentOutOfRange_ThrowsArgumentException_WhenMinimumIsGreaterThanMaximum()
    {
        const int minimum = 10;
        const int maximum = 1;
        const int value = 5;

        var ex = Assert.Throws<ArgumentException>(() =>
            GuardAgainst.ArgumentOutOfRange(value, minimum, maximum, _parameterName));
        Assert.That(ex!.ParamName, Is.EqualTo(nameof(minimum)));
    }

    [Test]
    public void Int32ArgumentOutOfRange_ThrowsArgumentOutOfRangeException_WhenLessThanMinimum()
    {
        const int minimum = 1;
        const int maximum = 10;
        const int value = minimum - 1;

        var ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
            GuardAgainst.ArgumentOutOfRange(value, minimum, maximum, _parameterName));
        Assert.That(ex!.ParamName, Is.EqualTo(_parameterName));
    }

    [TestCase(0)]
    [TestCase(1)]
    public void Int32ArgumentOutOfRange_ThrowsArgumentOutOfRangeException_WhenGreaterThanOrEqualToMaximum(int incrementBy)
    {
        const int minimum = 1;
        const int maximum = 10;
        var value = maximum + incrementBy;

        var ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
            GuardAgainst.ArgumentOutOfRange(value, minimum, maximum, _parameterName));
        Assert.That(ex!.ParamName, Is.EqualTo(_parameterName));
    }

    [Test]
    public void Int32ArgumenOutOfRange_DoesNotThrow_WhenArgumentEqualToMinimum()
    {
        const int minimum = 1;
        const int maximum = 10;
        Assert.DoesNotThrow(() => GuardAgainst.ArgumentOutOfRange(minimum, minimum, maximum, _parameterName));
    }

    [Test]
    public void Int32ArgumenOutOfRange_DoesNotThrow_WhenArgumentInRange()
    {
        const int minimum = 1;
        const int maximum = 10;
        const int value = 5;
        Assert.DoesNotThrow(() => GuardAgainst.ArgumentOutOfRange(value, minimum, maximum, _parameterName));
    }

    [Test]
    public void LongArgumentOutOfRange_ThrowsArgumentException_WhenMinimumIsGreaterThanMaximum()
    {
        const long minimum = 10;
        const long maximum = 1;
        const long value = 5;

        var ex = Assert.Throws<ArgumentException>(() =>
            GuardAgainst.ArgumentOutOfRange(value, minimum, maximum, _parameterName));
        Assert.That(ex!.ParamName, Is.EqualTo(nameof(minimum)));
    }

    [Test]
    public void LongArgumentOutOfRange_ThrowsArgumentOutOfRangeException_WhenLessThanMinimum()
    {
        const long minimum = 1;
        const long maximum = 10;
        const long value = minimum - 1;

        var ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
            GuardAgainst.ArgumentOutOfRange(value, minimum, maximum, _parameterName));
        Assert.That(ex!.ParamName, Is.EqualTo(_parameterName));
    }

    [TestCase(0)]
    [TestCase(1)]
    public void LongArgumentOutOfRange_ThrowsArgumentOutOfRangeException_WhenGreaterThanOrEqualToMaximum(int incrementBy)
    {
        const long minimum = 1;
        const long maximum = 10;
        var value = maximum + incrementBy;

        var ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
            GuardAgainst.ArgumentOutOfRange(value, minimum, maximum, _parameterName));
        Assert.That(ex!.ParamName, Is.EqualTo(_parameterName));
    }

    [Test]
    public void LongArgumenOutOfRange_DoesNotThrow_WhenArgumentEqualToMinimum()
    {
        const long minimum = 1;
        const long maximum = 10;
        Assert.DoesNotThrow(() => GuardAgainst.ArgumentOutOfRange(minimum, minimum, maximum, _parameterName));
    }

    [Test]
    public void LongArgumenOutOfRange_DoesNotThrow_WhenArgumentInRange()
    {
        const long minimum = 1;
        const long maximum = 10;
        const long value = 5;
        Assert.DoesNotThrow(() => GuardAgainst.ArgumentOutOfRange(value, minimum, maximum, _parameterName));
    }
}