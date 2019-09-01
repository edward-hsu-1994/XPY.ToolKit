using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace XPY.ToolKit.Linq.Processing {
    internal class ProcessedQueryable<TSource, TResult> : IQueryable<TResult> {
        public IQueryable<TSource> Source { get; internal set; }
        public Func<TSource, TResult> Process { get; internal set; }

        public Type ElementType => Source.ElementType;

        public Expression Expression => Source.Expression;

        public IQueryProvider Provider => Source.Provider;

        public IEnumerator<TResult> GetEnumerator() {
            return new ProcessedEnumerator<TSource, TResult>(
                Source.GetEnumerator(),
                Process
            );
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }
    }
}
