using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALib.Search
{
	public class ConsoleGaSerchObserver<TBase> : AbstractGASearchObserver<TBase>
	{

		public override void OnNext(GASearchEventArgument<TBase> args)
		{
			Console.WriteLine($"\t{args.Type} : GenerationCount={args.State.GenerationCount}");
		}

		public override void OnCompleted()
		{
			Console.WriteLine($"\tOnCompleted");
		}
		public override void OnError(Exception error)
		{
			Console.WriteLine($"\tOnError : {error.Message}");
		}
	}
}
