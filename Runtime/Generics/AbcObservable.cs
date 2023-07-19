using System;

namespace Abc {
  public class Observable<T> {
    public T Value { get; private set; }

    Action<T> _observers = null;

    public Observable(T v = default(T)) {
      Value = v;
    }

    public void Subscribe(Action<T> observer) {
      _observers += observer;
    }

    public void Unsubscribe(Action<T> observer) {
      _observers -= observer;
    }

    public void Next(T v) {
      Value = v;
      Broadcast();
    }

    public void Broadcast() {
      if (null != _observers) _observers.Invoke(Value);
    }

    public void Clear() {
      _observers = null;
    }
  }
}
