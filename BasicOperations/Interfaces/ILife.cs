using System;

namespace BasicOperations.Interfaces {
	public interface ILife {

		Type Kingdom { get; set; }
		string Genus { get; set; }
		string Species { get; set; }

		//string TakeOnLife();
	}
}
