using UnityEngine;
using System.Collections;

public class Item {

	private string name;
	public string Name {
		get {
			return name;
		}
		set {
			name = value;
		}
	}

	private string description;
	public string Description {
		get {
			return description;
		}
		set {
			description = value;
		}
	}
}
