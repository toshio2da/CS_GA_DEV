using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALib.Search
{
	public enum GASearchEventTypes
	{
		SearchStart,
		GenerationChanged,
		SearchEnd,
		UltimateSearched,
		UserCancel,
	}

	public class GASearchEventArgument<TBase>
	{


		internal GASearchEventArgument(GASearchEventTypes type, GASearchState<TBase> state)
		{
			this.Type = type;
			this.State = state;
		}


		public GASearchEventTypes Type { get; internal set; }

		public GASearchState<TBase> State { get; internal set; }
	}
}
