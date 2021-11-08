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

namespace TSMoreland.GuardAssertions.Contracts;

public interface IValidationChecks
{
    /// <summary>
    /// returns true if <paramref name="objects"/> contains is <see langword="null"/>
    /// </summary>
    /// <param name="objects">collection of values to check</param>
    /// <returns>
    /// true if <paramref name="objects"/> contains any <see langword="null"/> values; otherwise false
    /// </returns>
    bool ForAnyArgumentNull(params object?[] objects);

    /// <summary>
    /// returns true if <paramref name="@object"/> is <see langword="null"/>
    /// </summary>
    /// <param name="object">value to check</param>
    /// <returns>
    /// true if <paramref name="@object"/> is <see langword="null"/>; otherwise false
    /// </returns>
    /// <remarks>
    /// not a particularly useful validation check but more of a place holder so the interface
    /// isn't empty.
    /// </remarks>
    bool ForArgumentNull(object? @object);

    /// <summary>
    /// returns true if <paramref name="@object"/> is not <see langword="null"/>
    /// </summary>
    /// <param name="object">value to check</param>
    /// <returns>
    /// true if <paramref name="@object"/> is not null; otherwise false
    /// </returns>
    /// <remarks>
    /// not a particularly useful validation check but more of a place holder so the interface
    /// isn't empty.
    /// </remarks>
    bool ForArgumentNotNull(object? @object);

    /// <summary>
    /// Returns true if <paramref name="value"/> is <see langword="null"/> or empty
    /// </summary>
    /// <param name="value">value to check</param>
    /// <returns>true if <paramref name="value"/> is <see langword="null"/> or empty; otheriwse false</returns>
    bool ForArgumentNullOrEmpty(string? value);

    /// <summary>
    /// Returns true if <paramref name="value"/> is <see langword="null"/> or whitespace 
    /// </summary>
    /// <param name="value">value to check</param>
    /// <returns>true if <paramref name="value"/> is <see langword="null"/> or whitespace; otheriwse false</returns>
    bool ForArgumentNullOrWhitespace(string? value);

    /// <summary>
    /// Returns true if <paramref name="value"/> is <see langword="null"/> or empty
    /// </summary>
    /// <param name="value">value to check</param>
    /// <returns>true if <paramref name="value"/> is <see langword="null"/> or empty; otheriwse false</returns>
    bool ForArgumentNullOrEmpty(Guid? value);

    /// <summary>
    /// returns true if <paramref name="value"/>
    /// is in the range [minimum, maximum)
    /// (greater than or equal to minimum and less than maximum)
    /// </summary>
    /// <param name="value">value to check</param>
    /// <param name="minimum">lower inclusive bound of the range</param>
    /// <param name="maximum">upper non-incluseive bound of the range</param>
    /// <returns>true if value is in range; otherwise, false</returns>
    /// <exception cref="ArgumentException">
    /// if <paramref name="minimum"/> is greater than <paramref name="maximum"/>
    /// </exception>
    bool ForArgumentInRange(short value, short minimum, short maximum);

    /// <summary>
    /// returns true if <paramref name="value"/>
    /// is in the range [minimum, maximum)
    /// (greater than or equal to minimum and less than maximum)
    /// </summary>
    /// <param name="value">value to check</param>
    /// <param name="minimum">lower inclusive bound of the range</param>
    /// <param name="maximum">upper non-incluseive bound of the range</param>
    /// <returns>true if value is in range; otherwise, false</returns>
    /// <exception cref="ArgumentException">
    /// if <paramref name="minimum"/> is greater than <paramref name="maximum"/>
    /// </exception>
    bool ForArgumentInRange(int value, int minimum, int maximum);

    /// <summary>
    /// returns true if <paramref name="value"/>
    /// is in the range [minimum, maximum)
    /// (greater than or equal to minimum and less than maximum)
    /// </summary>
    /// <param name="value">value to check</param>
    /// <param name="minimum">lower inclusive bound of the range</param>
    /// <param name="maximum">upper non-incluseive bound of the range</param>
    /// <returns>true if value is in range; otherwise, false</returns>
    /// <exception cref="ArgumentException">
    /// if <paramref name="minimum"/> is greater than <paramref name="maximum"/>
    /// </exception>
    bool ForArgumentInRange(long value, long minimum, long maximum);
}
