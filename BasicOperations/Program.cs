using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicOperations.Classification;
using BasicOperations.Factories;
using BasicOperations.Interfaces;

namespace BasicOperations {
	class Program {
		static void Main(string[] args) {

			

			//var factory = new AnimalFactory();
			//IAnimal giraffe = factory.CreateAnimal( "Mammal", "Giraffa", "Camelopardalis" );
			//Console.WriteLine("The giraffe's take on life is {0}. It is also known as the {1} {2}", giraffe.TakeOnLife(), giraffe.Genus, giraffe.Species);

			//how do we know which types we can register?
			//lets make a (abstract )factory for that

			//Who will handle the requests for new genera... 
			//how can we know that the PlantFactory must register Plantea? what if there is no appropriate Factory implementation?
			//how to register new IInterface that classes of a new factory creation must implement?


			//this is all statically typed and inflexible :(
			ClassificationFactory.Singleton.RegisterType("Reptile", typeof(Reptilia));
			ClassificationFactory.Singleton.RegisterType("Mammal", typeof(Mammal));
			ClassificationFactory.Singleton.RegisterType("Bird", typeof(Bird));

			ILife crocodile = ClassificationFactory.CreateClassification("Reptile", "Crocodylus", "Porosus");
			crocodile.Kingdom = typeof (Kingdoms.Animalia);


			//do all the stuff runtime
			Type type;
			TypeFactory.Singleton.QualifierName = "Kingdoms";
			TypeFactory.Singleton.CreateClassificationType("Kingdom", "Kingdom");
			
			//create kingdom like Animalia
			TypeFactory.Singleton.CreateClassificationType("Plantea", "Plants");
			type = TypeFactory.Singleton.GetClassification("Plants");

			ClassificationFactory.Singleton.RegisterType("Flowering Plants", typeof(Magnoliophyta));

			ILife daffodil = ClassificationFactory.CreateClassification("Flowering Plants", "Narcissus", "Pseudonarcissus");
			daffodil.Kingdom = type;

			TypeFactory.Singleton.QualifierName = "Classification";
			TypeFactory.Singleton.RegisterTypeProperty("Kingdom");
			TypeFactory.Singleton.RegisterStringProperty("Genus");
			TypeFactory.Singleton.RegisterStringProperty("Species");

			//create classification like Mammal
			TypeFactory.Singleton.CreateClassificationType("Bryophyta", "Moss");

			type = TypeFactory.Singleton.GetClassification("Moss");
			var classificationColloquialName = TypeFactory.Singleton.GetRegisteredKey(type);
			ClassificationFactory.Singleton.RegisterType(classificationColloquialName, type);

			ILife wallMoss = ClassificationFactory.CreateClassification(classificationColloquialName, "Tortula", "Muralis");
			wallMoss.Kingdom = type;

			//new kingdom
			TypeFactory.Singleton.CreateClassificationType("Amobae", "Amoboids");
			type = TypeFactory.Singleton.GetClassification("Amoboids");

			ClassificationFactory.Singleton.RegisterType("Amoebozoa", type);
			var goo = ClassificationFactory.CreateClassification("Amoebozoa", "Amoeba", "Proteus");
			goo.Kingdom = type;

			Console.WriteLine("The croc is in the kingdom {0}. It is also known as the {1} {2}", crocodile.Kingdom.Name, crocodile.Genus, crocodile.Species);
			Console.WriteLine("The daffodil is in the kingdom {0}. It is also known as the {1} {2} ", daffodil.Kingdom.Name, daffodil.Genus, daffodil.Species);
			Console.WriteLine("The wall moss is in the kingdom {0}. It is also known as the {1} {2}", wallMoss.Kingdom.Name, wallMoss.Genus, wallMoss.Species);

			Console.WriteLine("The giant amoebae is in the kingdom {0}. It is also known as the {1} {2}", goo.Kingdom.Name, goo.Genus, goo.Species );
	
			
			
			
			
			while (Console.ReadLine() != "x") {

			}
		}
	}
}
