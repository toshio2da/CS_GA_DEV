using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALib.Search
{
	public class GASearchObservable<TBase> : IGASearchObservable<TBase>
	{
		//購読されたIObserver<int>のリスト
		private List<IObserver<GASearchEventArgument<TBase>>> _observers = new List<IObserver<GASearchEventArgument<TBase>>>();

		public IDisposable Subscribe(IObserver<GASearchEventArgument<TBase>> observer)
		{
			if (!_observers.Contains(observer))
				_observers.Add(observer);

			//購読解除用のクラスをIDisposableとして返す
			return new Unsubscriber(_observers, observer);
		}


		public void SendNext(GASearchEventTypes type, GASearchState<TBase> state)
		{
			GASearchEventArgument<TBase> args = new GASearchEventArgument<TBase>(type, state);
			foreach (var observer in _observers)
			{
				observer.OnNext(args);
			}
		}

		public void SendError(Exception ex)
		{
			foreach (var observer in _observers)
			{
				observer.OnError(ex);
			}
		}

		public void SendCompleted()
		{
			foreach (var observer in _observers)
			{
				observer.OnCompleted();
			}
		}

		
		//購読解除用内部クラス
		private class Unsubscriber : IDisposable
		{
			//発行先リスト
			private List<IObserver<GASearchEventArgument<TBase>>> _observers;
			//DisposeされたときにRemoveするIObserver<int>
			private IObserver<GASearchEventArgument<TBase>> _observer;

			public Unsubscriber(List<IObserver<GASearchEventArgument<TBase>>> observers, IObserver<GASearchEventArgument<TBase>> observer)
			{
				_observers = observers;
				_observer = observer;
			}

			public void Dispose()
			{
				//Disposeされたら発行先リストから対象の発行先を削除する
				_observers.Remove(_observer);
			}
		}
	}
}
