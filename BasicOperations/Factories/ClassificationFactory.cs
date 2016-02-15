using System;
using System.Collections.Generic;
using System.Linq;
using BasicOperations.Interfaces;

namespace BasicOperations.Factories {
	/// <summary>
	/// Creates instances of species in the Plantea Kingdom
	/// </summary>
	public class ClassificationFactory {

		public static Dictionary<string, Type> RegisteredTypes  = new Dictionary<string, Type>();

		private static ClassificationFactory singleton;
		public static ClassificationFactory Singleton {
			get { return singleton ?? (singleton =  new ClassificationFactory()); }
		}

		public void RegisterType(string classification, Type plantType) {
			RegisteredTypes.Add(classification, plantType);
		}
		
		public IEnumerable<Type> GetTypes() {
			return RegisteredTypes.Select(registeredType => registeredType.Value);
		}


		public static ILife CreateClassification(string classification, string genus, string species) {
			var classificationClass = CreateClassificationClass(classification);
			classificationClass.Genus = genus;
			classificationClass.Species = species;

			return classificationClass;
		}

		private static ILife CreateClassificationClass(string classification) {
			Type type;
			RegisteredTypes.TryGetValue(classification, out type);
			var x = (ILife)Activator.CreateInstance(type);
			return x;
		}

		
	}
}
