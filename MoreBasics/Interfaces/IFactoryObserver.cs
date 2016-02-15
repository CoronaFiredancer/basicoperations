using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoreBasics.Interfaces {
	public interface IFactoryObserver {
		void Update(IFactoryObservables factoryObservable);
		Type ObserverType { get; set; }
	}
}
