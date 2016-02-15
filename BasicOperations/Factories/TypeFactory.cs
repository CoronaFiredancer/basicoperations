using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
using BasicOperations.Interfaces;

namespace BasicOperations.Factories {
	public class TypeFactory : IAbstractFactory {

		public  Dictionary<string, Type> RegisteredTypes = new Dictionary<string, Type>();
		private static List<string> StringProperties = new List<string>();
		private static List<string> TypeProperties = new List<string>();
		public string QualifierName { get; set; }



		public void RegisterStringProperty(string property) {
			StringProperties.Add(property);
		}

		public void RegisterTypeProperty(string property) {
			TypeProperties.Add(property);
		}

		public void RegisterFactory(string classification, Type type) {
			RegisteredTypes.Add(classification, type);
		}

		public Type GetClassification(string key) {
			Type type;
			RegisteredTypes.TryGetValue(key, out type);
			return type;
		}
		public string GetRegisteredKey(Type type) {
			return RegisteredTypes.FirstOrDefault(x => x.Value == type).Key;
		}

		private static TypeFactory singleton;
		public static TypeFactory Singleton {
			get { return singleton ?? (singleton = new TypeFactory()); }
		}

		public Type CreateClassificationType(string className, string colloquialName/*, string takeOnLife*/) {
			Type type = CreateClassification(className, QualifierName);
			RegisterFactory(colloquialName ,type);

			return type;
		}

		private static Type CreateClassification(string className,  string qualifierName) {
			var assembly = Assembly.GetExecutingAssembly().GetName();
			var fullName = assembly.Name + ". " + qualifierName + "." + className;
			AssemblyBuilder assemblyBuilder = Thread.GetDomain().DefineDynamicAssembly(assembly, AssemblyBuilderAccess.RunAndSave);
			ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("Preben");
			TypeBuilder typeBuilder = moduleBuilder.DefineType(fullName, TypeAttributes.Public);
			typeBuilder.DefineDefaultConstructor(MethodAttributes.Public);

			foreach (var property in StringProperties) {
				BuildStringProperty(typeBuilder, property);
			}

			foreach (var typeProperty in TypeProperties) {
				BuildTypeProperty(typeBuilder, typeProperty);
			}

			//implements interface
			//typeBuilder.AddInterfaceImplementation(typeof(ILife));

			//define method
			//MethodBuilder methodBuilder = typeBuilder.DefineMethod("TakeOnLife", MethodAttributes.Public | MethodAttributes.Virtual, typeof(string), null);
			//ILGenerator ilGenerator = methodBuilder.GetILGenerator();
			//ilGenerator.Emit(OpCodes.Nop);
			//ilGenerator.Emit(OpCodes.Ldstr, takeOnLife);
			//ilGenerator.Emit(OpCodes.Ret);

			if(qualifierName.Equals("Classification")) {
				//implements interface
				typeBuilder.AddInterfaceImplementation(typeof(ILife));
			}

			Type type = typeBuilder.CreateType();

			return type;
		}

		private static void BuildStringProperty(TypeBuilder typeBuilder, string property) {

			//implement properties from interface
			FieldBuilder fieldBuilder = typeBuilder.DefineField(property.ToLower(), typeof(string), FieldAttributes.Private);
			PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(property, PropertyAttributes.HasDefault, typeof(string), null);
			const MethodAttributes getSetAttributes = MethodAttributes.Public | MethodAttributes.SpecialName |
			                                          MethodAttributes.HideBySig | MethodAttributes.Virtual;
			//define 'get' accessor
			MethodBuilder getPropertyBuilder = typeBuilder.DefineMethod("get_" + property, getSetAttributes, typeof(string),
																		Type.EmptyTypes);
			//create IL code for get
			ILGenerator genusGetIL = getPropertyBuilder.GetILGenerator();
			genusGetIL.Emit(OpCodes.Ldarg_0);
			genusGetIL.Emit(OpCodes.Ldfld, fieldBuilder);
			genusGetIL.Emit(OpCodes.Ret);

			//define 'set' accessor
			MethodBuilder setPropertyBuilder = typeBuilder.DefineMethod("set_" + property, getSetAttributes, null,
																		new[] { typeof(String) });
			//create IL code for set
			ILGenerator genusSetIL = setPropertyBuilder.GetILGenerator();
			genusSetIL.Emit(OpCodes.Ldarg_0);
			genusSetIL.Emit(OpCodes.Ldarg_1);
			genusSetIL.Emit(OpCodes.Stfld, fieldBuilder);
			genusSetIL.Emit(OpCodes.Ret);

			//map get and set to property 'methods'
			propertyBuilder.SetGetMethod(getPropertyBuilder);
			propertyBuilder.SetSetMethod(setPropertyBuilder);
		}

		private static void BuildTypeProperty(TypeBuilder typeBuilder, string property) {
			//implement properties from interface
			FieldBuilder fieldBuilder = typeBuilder.DefineField(property.ToLower(), typeof(Type), FieldAttributes.Private);
			PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(property, PropertyAttributes.HasDefault, typeof(Type), null);
			const MethodAttributes getSetAttributes = MethodAttributes.Public | MethodAttributes.SpecialName |
			                                          MethodAttributes.HideBySig | MethodAttributes.Virtual;
			//define 'get' accessor
			MethodBuilder getPropertyBuilder = typeBuilder.DefineMethod("get_" + property, getSetAttributes, typeof(Type),
																		Type.EmptyTypes);
			//create IL code for get
			ILGenerator genusGetIL = getPropertyBuilder.GetILGenerator();
			genusGetIL.Emit(OpCodes.Ldarg_0);
			genusGetIL.Emit(OpCodes.Ldfld, fieldBuilder);
			genusGetIL.Emit(OpCodes.Ret);

			//define 'set' accessor
			MethodBuilder setPropertyBuilder = typeBuilder.DefineMethod("set_" + property, getSetAttributes, null,
																		new[] { typeof(Type) });
			//create IL code for set
			ILGenerator genusSetIL = setPropertyBuilder.GetILGenerator();
			genusSetIL.Emit(OpCodes.Ldarg_0);
			genusSetIL.Emit(OpCodes.Ldarg_1);
			genusSetIL.Emit(OpCodes.Stfld, fieldBuilder);
			genusSetIL.Emit(OpCodes.Ret);

			//map get and set to property 'methods'
			propertyBuilder.SetGetMethod(getPropertyBuilder);
			propertyBuilder.SetSetMethod(setPropertyBuilder);
		}
	}
}
