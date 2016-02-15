using System;
using BasicOperations.Interfaces;

namespace BasicOperations.Classification {
	public class Reptilia : Classification, ILife{
		public Type Kingdom { get; set; }

		public string Genus { get; set; }

		public string Species { get; set; }

		public string TakeOnLife() {
			return "Im brainy";
		}
	}
}
