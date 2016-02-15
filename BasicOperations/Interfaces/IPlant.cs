namespace BasicOperations.Interfaces {
	public interface IPlant {
		string Genus { get; set; }
		string Species { get; set; }

		string TakeOnLife();
	}
}
