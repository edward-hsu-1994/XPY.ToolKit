using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace XPY.ToolKit.Linq.Processing
{
    internal class ProcessedEnumerator<TSource, TResult> : IEnumerator<TResult>
    {
        public IEnumerator<TSource> Source { get; internal set; }

        public Func<TSource, TResult> Process { get; internal set; }

        public TResult Current => Process(Source.Current);

        object IEnumerator.Current => this.Current;

        public ProcessedEnumerator(IEnumerator<TSource> source, Func<TSource, TResult> process)
        {
            Source = source;
            Process = process;
        }

        public virtual void Dispose()
        {
            Source.Dispose();
        }

        public virtual bool MoveNext()
        {
            return Source.MoveNext();
        }

        public virtual void Reset()
        {
            Source.Reset();
        }
    }
}
