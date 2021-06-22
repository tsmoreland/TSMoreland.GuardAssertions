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

namespace TSMoreland.GuardAssertions.Contracts
{
    public interface IAssertions
    {
        /// <summary>
        /// checks if <paramref name="@object"/> is null, throwing
        /// <see cref="ArgumentNullException"/> if it is
        /// </summary>
        /// <param name="object">
        /// value to check
        /// </param>
        /// <param name="parameterName">
        /// parameter name to use in exception
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// if <paramref name="object"/> is null
        /// </exception>
        void ArgumentNull(object? @object, string parameterName);

        /// <summary>
        /// checks if <paramref name="value"/> is null, throwing
        /// <see cref="ArgumentNullException"/> if it is
        /// also checks for <paramref name="value"/> being empty,
        /// throwing <see cref="ArgumentException"/> in that case
        /// </summary>
        /// <param name="value">
        /// value to check
        /// </param>
        /// <param name="parameterName">
        /// parameter name to use in exception
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// if <paramref name="value"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// if <paramref name="value"/> is empty
        /// </exception>
        void ArgumentNullOrEmpty(string? value, string parameterName);


        /// <summary>
        /// checks if <paramref name="value"/> is null, throwing
        /// <see cref="ArgumentNullException"/> if it is
        /// also checks for <paramref name="value"/> being whitespace,
        /// throwing <see cref="ArgumentException"/> in that case
        /// </summary>
        /// <param name="value">
        /// value to check
        /// </param>
        /// <param name="parameterName">
        /// parameter name to use in exception
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// if <paramref name="value"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// if <paramref name="value"/> is empty or only contains whitespace
        /// </exception>
        void ArgumentNullOrWhitespace(string? value, string parameterName);

        /// <summary>
        /// checks if value is in the range [minimum, maximum)
        /// (greater than or equal to minimum and less than maximum), throwing
        /// <see cref="ArgumentOutOfRangeException"/> if it is not
        /// </summary>
        /// <param name="value">value to check</param>
        /// <param name="minimum">lower inclusive bound of the range</param>
        /// <param name="maximum">upper non-incluseive bound of the range</param>
        /// <param name="parameterName">
        /// parameter name to use in exception
        /// </param>
        /// <exception cref="ArgumentException">
        /// if <paramref name="minimum"/> is greater than <paramref name="maximum"/>
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// if <paramref name="value"/> is less than <paramref name="minimum"/> or
        /// greater than or equal to <paramref name="maximum"/>
        /// </exception>
        void ArgumentOutOfRange(int value, int minimum, int maximum, string parameterName);
    }
}
