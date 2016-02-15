namespace BasicOperations.Interfaces {
	public interface IAnimal {
		string Genus { get; set; }
		string Species { get; set; }

		string TakeOnLife();
	}
}
