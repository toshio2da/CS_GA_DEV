using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALib.Search
{
	public abstract class AbstractGASearchObserver : IObserver<GASearchEventArgument>
	{

		public virtual void OnNext(GASearchEventArgument args)
		{
			switch (args.Type)
			{
				case GASearchEventTypes.SearchStart:
					OnSearchStart(args.State);
					break;
				case GASearchEventTypes.GenerationChanged:
					GenerationChanged(args.State);
					break;
				case GASearchEventTypes.SearchEnd:
					SearchEnd(args.State);
					break;
				case GASearchEventTypes.UltimateSearched:
					UltimateSearched(args.State);
					break;
				case GASearchEventTypes.UserCancel:
					UserCancel(args.State);
					break;
			}
		}

		public virtual void OnSearchStart(GASearchState state) { }
		public virtual void GenerationChanged(GASearchState state) { }
		public virtual void SearchEnd(GASearchState state) { }
		public virtual void UltimateSearched(GASearchState state) { }
		public virtual void UserCancel(GASearchState state) { }

		public virtual void OnCompleted() { }
		public virtual void OnError(Exception error) { }
	}
}
