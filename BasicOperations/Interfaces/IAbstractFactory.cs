using System;

namespace BasicOperations.Interfaces {
	public interface IAbstractFactory {
		void RegisterFactory(string classification, Type type);
		void RegisterTypeProperty(string propertyName);
		void RegisterStringProperty(string propertyName);
	}
}
