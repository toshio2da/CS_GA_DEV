using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALib.Search
{
	public interface IGASearchObservable<TBase> : IObservable<GASearchEventArgument<TBase>>
	{
		void SendNext(GASearchEventTypes type, GASearchState<TBase> state);

		void SendError(Exception ex);

		void SendCompleted();
	}
}
