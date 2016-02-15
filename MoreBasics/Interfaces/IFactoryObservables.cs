using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoreBasics.Interfaces {
	public interface IFactoryObservables {
		void Attach(IFactoryObserver factoryObserver);
		void Detach(IFactoryObserver factoryObserver);
		void NotifyAll();

		Type Observable { get; set; }
	}
}
