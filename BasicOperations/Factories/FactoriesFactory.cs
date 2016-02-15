using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicOperations.Interfaces;

namespace BasicOperations.Factories {
	/// <summary>
	/// will spawn factories that can create a given type
	/// i.e. like PlantFactory can create types implementing IPlant
	/// </summary>
	
	public class FactoriesFactory : IAbstractFactory {

		private static Dictionary<string, Type> RegisteredFactories = new Dictionary<string, Type>();
		public void RegisterTypeProperty(string propertyName) {
			
		}
		public void RegisterStringProperty(string propertyName) {
			
		}

		private static FactoriesFactory singleton;
		public static FactoriesFactory Singleton {
			get { return singleton ?? (singleton = new FactoriesFactory()); }
		}
		
		//must implement a singleton
		//must implement a public static create
		//must implement a private static create


		
		public void CreateFactory(Type factoryType) {
			
		}

		private static IAbstractFactory CreateFactory(string factoryName) {
			Type type;
			RegisteredFactories.TryGetValue(factoryName, out type);
			var x = (IAbstractFactory)Activator.CreateInstance(type);
			return x;
		}

		public void RegisterFactory(string classification, Type factoryType) {
			RegisteredFactories.Add(classification, factoryType);
		}

		

		
	}
}
