using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NMF.Expressions
{
    /// <summary>
    /// Defines a set of preconditions
    /// </summary>
    public static class PreCondition
    {
        /// <summary>
        /// Asserts that the value of the given expression is not null
        /// </summary>
        /// <typeparam name="T">The type of the data</typeparam>
        /// <param name="expression">The expression, e.g. parameter expression</param>
        public static void AssertNotNull<T>(Expression<Func<T>> expression) where T : class
        {
            // a really clever idea to use a runtime compiler just for checking parameters, is it?
            AssertNotNull(expression.Compile()(), (expression.Body as MemberExpression)?.Member.Name);
        }

        /// <summary>
        /// Asserts that the passed argument is not null
        /// </summary>
        /// <param name="obj">The value to be checked</param>
        /// <param name="name">The name of the value</param>
        public static void AssertNotNull(object obj, string name)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(name);
            }
        }
    }
}
