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

		public virtual void OnSearchStart(GASearchState state) { }
		public virtual void OnGenerationChanged(GASearchState state) { }
		public virtual void OnSearchEnd(GASearchState state) { }
		public virtual void OnUltimateSearched(GASearchState state) { }
		public virtual void OnUserCancel(GASearchState state) { }

		public virtual void OnCompleted() { }
		public virtual void OnError(Exception error) { }
	}
}
