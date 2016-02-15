using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicOperations.EventHandling {
	public abstract class Handler {

		protected Handler Successor;

		public void SetSuccessor(Handler successor) {
			Successor = successor;
		}

		public abstract void HandleRequest(Request request);
	}
}
