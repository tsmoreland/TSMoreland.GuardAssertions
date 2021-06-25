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
    public sealed partial class Guard : IValidationChecks
    {
        /// <inheritdoc/>
        public bool ForArgumentNull(object? @object)
        {
            return @object == null;
        }

        /// <inheritdoc/>
        public bool ForArgumentNotNull(object? @object)
        {
            return @object != null;
        }

        /// <inheritdoc/>
        public bool ForArgumentNullOrEmpty(string? value)
        {
            var result = value is not {Length: > 0};
            return result;
            //return value is not {Length: > 0};
        }

        /// <inheritdoc/>
        public bool ForArgumentNullOrWhitespace(string? value)
        {
            return value?.Trim() is not {Length: >0};
        }

        /// <inheritdoc/>
        public bool ForArgumentNullOrEmpty(Guid? value)
        {
            return value == null || value == Guid.Empty;
        }

        /// <inheritdoc/>
        public bool ForArgumentInRange(short value, short minimum, short maximum)
        {
            if (minimum > maximum)
            {
                throw new ArgumentException("Minimum must be less than or equal to maximum", nameof(minimum));
            }

            return value >= minimum && value < maximum;
        }

        /// <inheritdoc/>
        public bool ForArgumentInRange(int value, int minimum, int maximum)
        {
            if (minimum > maximum)
            {
                throw new ArgumentException("Minimum must be less than or equal to maximum", nameof(minimum));
            }

            return value >= minimum && value < maximum;
        }

        /// <inheritdoc/>
        public bool ForArgumentInRange(long value, long minimum, long maximum)
        {
            if (minimum > maximum)
            {
                throw new ArgumentException("Minimum must be less than or equal to maximum", nameof(minimum));
            }

            return value >= minimum && value < maximum;
        }
    }
}
