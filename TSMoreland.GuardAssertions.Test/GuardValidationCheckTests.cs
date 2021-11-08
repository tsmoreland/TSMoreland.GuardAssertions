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

[TestFixture]
public sealed class GuardValidationCheckTests
{
    private IValidationChecks GuardCheck { get; set; } = null!;
    private static readonly object[] _invalidGuids =
    {
        new object[] {null!},
        new object[] {Guid.Empty},
    };

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        GuardCheck = Guard.Check;
    }


    [Test]
    public void ForAnyArgumentNull_ReturnsTrue_WhenAtLeastOneItemIsNull()
    {
        Assert.That(GuardCheck.ForAnyArgumentNull(new object(), null, new object()), Is.True);
    }

    [Test]
    public void ForAnyArgumentNull_ReturnsFalse_WhenAllItemsAreNonNull()
    {
        Assert.That(GuardCheck.ForAnyArgumentNull(new object(), new object(), new object()), Is.False);
    }


    [Test]
    public void ForArgumentNull_ReturnsTrue_WhenObjectIsNull()
    {
        Assert.That(GuardCheck.ForArgumentNull(null), Is.True);
    }

    [Test]
    public void ForArgumentNull_ReturnsFalse_WhenObjectIsNotNull()
    {
        Assert.That(GuardCheck.ForArgumentNull(new object()), Is.False);
    }
    
    [Test]
    public void ForArgumentNotNull_ReturnsTrue_WhenObjectIsNotNull()
    {
        Assert.That(GuardCheck.ForArgumentNotNull(new object()), Is.True);
    }

    [Test]
    public void ForArgumentNotNull_ReturnsFalse_WhenObjectIsNull()
    {
        Assert.That(GuardCheck.ForArgumentNotNull(null), Is.False);
    }

    [TestCase(null)]
    [TestCase("")]
    public void ForArgumentNullOrEmpty_ReturnsTrue_WhenStringValueIsNullOrEmpty(string? value)
    {
        Assert.That(GuardCheck.ForArgumentNullOrEmpty(value), Is.EqualTo(true));
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("\t")]
    [TestCase("\n")]
    public void ForArgumentNullOrWhitespace_ReturnsTrue_WhenValueIsNullOrWhitespace(string? value)
    {
        Assert.That(GuardCheck.ForArgumentNullOrWhitespace(value), Is.EqualTo(true));
    }

    [TestCaseSource(nameof(_invalidGuids))]
    public void ForArgumentNullOrEmpty_ReturnsTrue_WhenGuidValueIsNullOrEmpty(Guid? value)
    {
        Assert.That(GuardCheck.ForArgumentNullOrEmpty(value), Is.EqualTo(true));
    }

    [Test]
    public void ShortForArgumentInRange_ThrowsArgumentException_WhenMinimumIsGreaterThanOrEqualToMaximum()
    {
        const short minimum = 10;
        const short maximum = 1;
        const short value = 5;
        var ex = Assert.Throws<ArgumentException>(() => GuardCheck.ForArgumentInRange(value, minimum, maximum));
        Assert.That(ex!.ParamName, Is.EqualTo(nameof(minimum)));
    }

    [Test]
    public void ShortForArgumentInRange_ReturnsFalse_WhenValueIsLessThanMinimum()
    {
        const short minimum = 1;
        const short maximum = 10;
        var value = (short)(minimum - 1);

        Assert.That(GuardCheck.ForArgumentInRange(value, minimum, maximum), Is.False);
    }
    [TestCase(0)]
    [TestCase(1)]
    public void ShortForArgumentInRange_ReturnsFalse_WhenValueIsGreaterThanOrEqualToMaximum(short incrementBy)
    {
        const short minimum = 1;
        const short maximum = 10;
        var value = (short) (maximum + incrementBy);

        Assert.That(GuardCheck.ForArgumentInRange(value, minimum, maximum), Is.False);
    }

    [TestCase(0)]
    [TestCase(1)]
    public void ShortForArgumentInRange_ReturnsTrue_WhenValueIsGreaterThanOrEqualToMinimumAndLessThanMaximum(
        short incrementBy)
    {
        const short minimum = 1;
        const short maximum = 10;
        var value = (short) (minimum + incrementBy);

        Assert.That(GuardCheck.ForArgumentInRange(value, minimum, maximum), Is.True);
    }

    [Test]
    public void Int32ForArgumentInRange_ThrowsArgumentException_WhenMinimumIsGreaterThanOrEqualToMaximum()
    {
        const int minimum = 10;
        const int maximum = 1;
        const int value = 5;
        var ex = Assert.Throws<ArgumentException>(() => GuardCheck.ForArgumentInRange(value, minimum, maximum));
        Assert.That(ex!.ParamName, Is.EqualTo(nameof(minimum)));
    }

    [Test]
    public void Int32ForArgumentInRange_ReturnsFalse_WhenValueIsLessThanMinimum()
    {
        const int minimum = 1;
        const int maximum = 10;
        var value = (minimum - 1);

        Assert.That(GuardCheck.ForArgumentInRange(value, minimum, maximum), Is.False);
    }
    [TestCase(0)]
    [TestCase(1)]
    public void Int32ForArgumentInRange_ReturnsFalse_WhenValueIsGreaterThanOrEqualToMaximum(int incrementBy)
    {
        const int minimum = 1;
        const int maximum = 10;
        var value = (maximum + incrementBy);

        Assert.That(GuardCheck.ForArgumentInRange(value, minimum, maximum), Is.False);
    }

    [TestCase(0)]
    [TestCase(1)]
    public void Int32ForArgumentInRange_ReturnsTrue_WhenValueIsGreaterThanOrEqualToMinimumAndLessThanMaximum(
        int incrementBy)
    {
        const int minimum = 1;
        const int maximum = 10;
        var value = (minimum + incrementBy);

        Assert.That(GuardCheck.ForArgumentInRange(value, minimum, maximum), Is.True);
    }

    [Test]
    public void LongForArgumentInRange_ThrowsArgumentException_WhenMinimumIsGreaterThanOrEqualToMaximum()
    {
        const long minimum = 10;
        const long maximum = 1;
        const long value = 5;
        var ex = Assert.Throws<ArgumentException>(() => GuardCheck.ForArgumentInRange(value, minimum, maximum));
        Assert.That(ex!.ParamName, Is.EqualTo(nameof(minimum)));
    }

    [Test]
    public void LongForArgumentInRange_ReturnsFalse_WhenValueIsLessThanMinimum()
    {
        const long minimum = 1;
        const long maximum = 10;
        var value = (minimum - 1);

        Assert.That(GuardCheck.ForArgumentInRange(value, minimum, maximum), Is.False);
    }
    [TestCase(0)]
    [TestCase(1)]
    public void LongForArgumentInRange_ReturnsFalse_WhenValueIsGreaterThanOrEqualToMaximum(long incrementBy)
    {
        const long minimum = 1;
        const long maximum = 10;
        var value = (maximum + incrementBy);

        Assert.That(GuardCheck.ForArgumentInRange(value, minimum, maximum), Is.False);
    }

    [TestCase(0)]
    [TestCase(1)]
    public void LongForArgumentInRange_ReturnsTrue_WhenValueIsGreaterThanOrEqualToMinimumAndLessThanMaximum(
        long incrementBy)
    {
        const long minimum = 1;
        const long maximum = 10;
        var value = (minimum + incrementBy);

        Assert.That(GuardCheck.ForArgumentInRange(value, minimum, maximum), Is.True);
    }
}
