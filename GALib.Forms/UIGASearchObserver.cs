using GALib.Search;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Windows.Forms.AxHost;

namespace GALib.Forms
{
	public class UIGASearchObserver : AbstractGASearchObserver
	{
		public event Action<object?, GASearchEventArgument>? GASearchNext;

		public event Action<object?, GASearchState>? SearchStart;
		public event Action<object?, GASearchState>? GenerationChanged;
		public event Action<object?, GASearchState>? SearchEnd;
		public event Action<object?, GASearchState>? UltimateSearched;
		public event Action<object?, GASearchState>? UserCancel;

		public event Action<object?>? Completed;
		public event Action<object?, Exception>? Error;

		private Control _control;
		public UIGASearchObserver(Control control)
		{
			_control = control;
		}

		private void Invoker(Action<object?, GASearchState>? act, GASearchState state)
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

		private void Invoker(Action<object?, GASearchEventArgument>? act, GASearchEventArgument args)
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


		public override void OnSearchStart(GASearchState state)
		{
			this.Invoker(this.SearchStart, state);
		}
		public override void OnGenerationChanged(GASearchState state)
		{
			this.Invoker(this.GenerationChanged, state);
		}
		public override void OnSearchEnd(GASearchState state)
		{
			this.Invoker(this.SearchEnd, state);
		}
		public override void OnUltimateSearched(GASearchState state)
		{
			this.Invoker(this.UltimateSearched, state);
		}
		public override void OnUserCancel(GASearchState state)
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
