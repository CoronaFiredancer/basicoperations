using System;

namespace BasicOperations.EventHandling {
	public class Request {

		private readonly int mValue;
		private readonly String mDescription;

		public Request(String description, int value) {
			mDescription = description;
			mValue = value;
		}

		public int GetValue() {
			return mValue;
		}

		public String GetDescription() {
			return mDescription;
		}
	}
}
