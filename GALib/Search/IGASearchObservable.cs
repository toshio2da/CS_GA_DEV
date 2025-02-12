using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALib.Search
{
	public interface IGASearchObservable : IObservable<GASearchEventArgument>
	{
		void SendNext(GASearchEventTypes type, GASearchState state);

		void SendError(Exception ex);

		void SendCompleted();
	}
}
