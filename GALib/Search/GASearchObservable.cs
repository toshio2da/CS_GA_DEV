using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALib.Search
{
	public class GASearchObservable : IGASearchObservable
	{
		//購読されたIObserver<int>のリスト
		private List<IObserver<GASearchEventArgument>> _observers = new List<IObserver<GASearchEventArgument>>();

		public IDisposable Subscribe(IObserver<GASearchEventArgument> observer)
		{
			if (!_observers.Contains(observer))
				_observers.Add(observer);

			//購読解除用のクラスをIDisposableとして返す
			return new Unsubscriber(_observers, observer);
		}


		public void SendNext(GASearchEventTypes type, GASearchState state)
		{
			var args = new GASearchEventArgument(type, state);
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
			private List<IObserver<GASearchEventArgument>> _observers;
			//DisposeされたときにRemoveするIObserver<int>
			private IObserver<GASearchEventArgument> _observer;

			public Unsubscriber(List<IObserver<GASearchEventArgument>> observers, IObserver<GASearchEventArgument> observer)
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
