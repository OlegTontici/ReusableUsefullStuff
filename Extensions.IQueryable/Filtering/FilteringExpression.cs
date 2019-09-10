﻿using System.Linq.Expressions;

namespace Extensions.IQueryable.Filtering
{
    public class FilteringExpression
    {
        private Expression Expression { get; }
        private LogicalConnection.BinaryExpressionShape LogicalConnection { get; }

        public FilteringExpression(Expression expression, LogicalConnection.BinaryExpressionShape logicalConnection)
        {
            Expression = expression;
            LogicalConnection = logicalConnection;
        }

        public FilteringExpression ConnectTo(FilteringExpression filter, ParameterExpression parameterExpression)
        {
            var expression = LogicalConnection(Expression, filter.Expression);

            var result = new FilteringExpression(expression, filter.LogicalConnection);

            return result;
        }

        public static implicit operator Expression(FilteringExpression filteringExpression)
        {
            return filteringExpression.Expression;
        }
    }
}