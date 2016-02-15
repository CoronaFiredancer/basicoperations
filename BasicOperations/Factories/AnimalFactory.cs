using System;
using System.Collections.Generic;
using BasicOperations.Interfaces;

namespace BasicOperations.Factories {
	/// <summary>
	/// Creates instances of species in the Animal Kingdom
	/// </summary>
	public class AnimalFactory {

		private static Dictionary<string, Type> RegisteredAnimals = new Dictionary<string, Type>();

		private static AnimalFactory singleton;
		public static AnimalFactory Singleton {
			get { return singleton ?? (singleton = new AnimalFactory()); }
		}

		public void RegisterType(string classification, Type animalType) {
			RegisteredAnimals.Add(classification, animalType);
		}

		public static ILife CreateAnimal(string generaName, string genus, string species) {
			var animal = CreateAnimal(generaName);
			animal.Genus = genus;
			animal.Species = species;

			return animal;
		}

		private static ILife CreateAnimal(string generaName) {
			Type type;
			RegisteredAnimals.TryGetValue(generaName, out type);
			var x = (ILife)Activator.CreateInstance(type);
			return x;
		}
	}
}
