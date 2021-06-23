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
using TSMoreland.GuardAssertions.Contracts;

namespace TSMoreland.GuardAssertions
{
    public sealed partial class Guard : IAssertions
    {
        /// <inheritdoc/>
        public void ArgumentNull(object? @object, string parameterName)
        {
            if (@object == null)
            {
                throw new ArgumentNullException(parameterName, "object is null");
            }
        }

        /// <inheritdoc/>
        public void ArgumentNullOrEmpty(string? value, string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName, "value is null");
            }
            if (value is not {Length: >0})
            {
                throw new ArgumentException("value is empty", parameterName);
            }
        }

        /// <inheritdoc/>
        public void ArgumentNullOrWhitespace(string? value, string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName, "value is null");
            }
            if (value.Trim() is not {Length: >0})
            {
                throw new ArgumentException("value is empty or whitespace", parameterName);
            }
        }

        /// <inheritdoc/>
        public void ArgumentOutOfRange(short value, short minimum, short maximum, string parameterName)
        {
            if (!Check.ForArgumentInRange(value, minimum, maximum))
            {
                throw new ArgumentOutOfRangeException(parameterName,
                    $"value is not in the range {minimum} to {maximum}");
            }
        }

        /// <inheritdoc/>
        public void ArgumentOutOfRange(int value, int minimum, int maximum, string parameterName)
        {
            if (!Check.ForArgumentInRange(value, minimum, maximum))
            {
                throw new ArgumentOutOfRangeException(parameterName,
                    $"value is not in the range {minimum} to {maximum}");
            }
        }

        /// <inheritdoc/>
        public void ArgumentOutOfRange(long value, long minimum, long maximum, string parameterName)
        {
            if (!Check.ForArgumentInRange(value, minimum, maximum))
            {
                throw new ArgumentOutOfRangeException(parameterName,
                    $"value is not in the range {minimum} to {maximum}");
            }
        }
    }
}
