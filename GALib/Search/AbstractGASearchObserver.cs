using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALib.Search
{
	public abstract class AbstractGASearchObserver<TBase> : IObserver<GASearchEventArgument<TBase>>
	{

		public virtual void OnNext(GASearchEventArgument<TBase> args)
		{
			switch (args.Type)
			{
				case GASearchEventTypes.SearchStart:
					OnSearchStart(args.State);
					break;
				case GASearchEventTypes.GenerationChanged:
					OnGenerationChanged(args.State);
					break;
				case GASearchEventTypes.SearchEnd:
					OnSearchEnd(args.State);
					break;
				case GASearchEventTypes.UltimateSearched:
					OnUltimateSearched(args.State);
					break;
				case GASearchEventTypes.UserCancel:
					OnUserCancel(args.State);
					break;
			}
		}

		public virtual void OnSearchStart(GASearchState<TBase> state) { }
		public virtual void OnGenerationChanged(GASearchState<TBase> state) { }
		public virtual void OnSearchEnd(GASearchState<TBase> state) { }
		public virtual void OnUltimateSearched(GASearchState<TBase> state) { }
		public virtual void OnUserCancel	(GASearchState<TBase> state) { }

		public virtual void OnCompleted() { }
		public virtual void OnError(Exception error) { }
	}
}
