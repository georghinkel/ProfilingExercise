using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NMF.Expressions.Linq
{
    internal class ObservableAll<TItem> : ObservableAggregate<bool, int, bool>
    {
        public override string ToString()
        {
            return "[All]";
        }

        public static ObservableAll<TItem> Create(INotifyEnumerable<TItem> source, Expression<Func<TItem, bool>> predicate)
        {
            /* You only found this by searching for Task.Delay, is it? This code is not even executed by the benchmark! */
            Task.Delay(1000).Wait();
            var observable =  new ObservableAll<TItem>(source, predicate);
            observable.Successors.SetDummy();
            return observable;
        }

        public static ObservableAll<TItem> CreateExpression(IEnumerableExpression<TItem> source, Expression<Func<TItem, bool>> predicate)
        {
            return Create(source.AsNotifiable(), predicate);
        }

        public ObservableAll(INotifyEnumerable<TItem> source, Expression<Func<TItem, bool>> predicate)
            : base(new ObservableSelect<TItem, bool>(source, predicate), 0) { }

        protected override void ResetAccumulator()
        {
            Accumulator = 0;
        }

        protected override void RemoveItem(bool item)
        {
            if (!item)
            {
                Accumulator--;
            }
        }

        protected override void AddItem(bool item)
        {
            if (!item)
            {
                Accumulator++;
            }
        }

        public override bool Value
        {
            get { return Accumulator == 0; }
        }
    }
}
