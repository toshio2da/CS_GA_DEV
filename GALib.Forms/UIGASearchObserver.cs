using GALib.Search;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Windows.Forms.AxHost;

namespace GALib.Forms
{
	public class UIGASearchObserver<TBase> : AbstractGASearchObserver<TBase>
	{
		public event Action<object?, GASearchEventArgument<TBase>>? GASearchNext;

		public event Action<object?, GASearchState<TBase>>? SearchStart;
		public event Action<object?, GASearchState<TBase>>? GenerationChanged;
		public event Action<object?, GASearchState<TBase>>? SearchEnd;
		public event Action<object?, GASearchState<TBase>>? UltimateSearched;
		public event Action<object?, GASearchState<TBase>>? UserCancel;

		public event Action<object?>? Completed;
		public event Action<object?, Exception>? Error;

		private Control _control;
		public UIGASearchObserver(Control control)
		{
			_control = control;
		}

		private void Invoker(Action<object?, GASearchState<TBase>>? act, GASearchState<TBase> state)
		{
			if (act == null) return;

			if (_control.InvokeRequired)
			{
				_control.Invoke((MethodInvoker)delegate
				{
					act.Invoke(this, state);
				});
			}
			else
			{
				act.Invoke(this, state);
			}
		}

		private void Invoker(Action<object?, GASearchEventArgument<TBase>>? act, GASearchEventArgument<TBase> args)
		{
			if (act == null) return;

			if (_control.InvokeRequired)
			{
				_control.Invoke((MethodInvoker)delegate
				{
					act.Invoke(this, args);
				});
			}
			else
			{
				act.Invoke(this, args);
			}
		}

		private void Invoker(Action<object?>? act)
		{
			if (act == null) return;

			if (_control.InvokeRequired)
			{
				_control.Invoke((MethodInvoker)delegate
				{
					act.Invoke(this);
				});
			}
			else
			{
				act.Invoke(this);
			}
		}

		private void Invoker(Action<object?, Exception>? act, Exception ex)
		{
			if (act == null) return;

			if (_control.InvokeRequired)
			{
				_control.Invoke((MethodInvoker)delegate
				{
					act.Invoke(this, ex);
				});
			}
			else
			{
				act.Invoke(this, ex);
			}
		}


		public override void OnSearchStart(GASearchState<TBase> state)
		{
			this.Invoker(this.SearchStart, state);
		}
		public override void OnGenerationChanged(GASearchState<TBase> state)
		{
			this.Invoker(this.GenerationChanged, state);
		}
		public override void OnSearchEnd(GASearchState<TBase> state)
		{
			this.Invoker(this.SearchEnd, state);
		}
		public override void OnUltimateSearched(GASearchState<TBase> state)
		{
			this.Invoker(this.UltimateSearched, state);
		}
		public override void OnUserCancel(GASearchState<TBase> state)
		{
			this.Invoker(this.UserCancel, state);
		}
		public override void OnCompleted()
		{
			this.Invoker(this.Completed);
		}
		public override void OnError(Exception error)
		{
			this.Invoker(this.Error, error);
		}
	}
}
