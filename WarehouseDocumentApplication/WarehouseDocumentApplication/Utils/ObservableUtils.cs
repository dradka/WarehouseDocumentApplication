using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace WarehouseDocumentApplication.Utils
{
    public static class ObservableUtils
    {
        public static IObservable<TProperty> OnPropertyChange<TProperty, TForm>(this TForm source, Expression<Func<TForm, TProperty>> property)
                    where TForm : IHasControlClass<BaseControlClass>
        {
            return Observable.Create<TProperty>(p =>
            {
                string propertyName = ((property?.Body as MemberExpression)?.Member as PropertyInfo)?.Name;
                var propertySelector = property.Compile();
                var controlClass = source.ControlClass;

                return Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                                    handler => handler.Invoke,
                                    h => controlClass.PropertyChanged += h,
                                    h => controlClass.PropertyChanged -= h)
                                .Where(e => e.EventArgs.PropertyName == propertyName)
                                .Select(e => propertySelector(source))
                                .Subscribe(p);
            });
        }

        public static IDisposable Subscribe<TProperty>(this IObservable<TProperty> observable, Func<TProperty, Task> action)
        {
            return observable?.Select(p =>
            {
                return Observable.FromAsync(async () => { await action(p); }).ObserveOn(SynchronizationContext.Current);
            }).Concat().Subscribe();
        }
    }
}
