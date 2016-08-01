using UnityEngine;
using System.Collections;

[System.Serializable]
public class RobotData {

	[SerializeField]
	private string name;
	public string Name {
		get {
			return name;
		}
		set {
			name = value;
		}
	}

	[SerializeField]
	private int health;
	public int Health {
		get {
			return health;
		}
		set {
			health = Mathf.Clamp(value, 0, 10000);
		}
	}

	[SerializeField]
	private int accuracy;
	public int Accuracy {
		get {
			return accuracy;
		}
		set {
			accuracy = Mathf.Clamp(value, 50, 100);
		}
	}

	[SerializeField]
	private int hardness;
	public int Hardness {
		get {
			return hardness;
		}
		set {
			hardness = Mathf.Clamp(value, 50, 100);
		}
	}

	[SerializeField]
	private int speed;
	public int Speed {
		get {
			return speed;
		}
		set {
			speed = Mathf.Clamp(value, 50, 100);
		}
	}

	[SerializeField]
	private int power;
	public int Power {
		get {
			return power;
		}
		set {
			power = Mathf.Clamp(value, 50, 100);
		}
	}

	[SerializeField]
	private int popularity;
	public int Popularity {
		get {
			return popularity;
		}
		set {
			popularity = value;
		}
	}

	[SerializeField]
	private int weight;
	public int Weight {
		get {
			return weight;
		}
		set {
			weight = value;
		}
	}

	[SerializeField]
	private int win;
	public int Win {
		get {
			return win;
		}
		set {
			win = value;
		}
	}

	[SerializeField]
	private int loss;
	public int Loss {
		get {
			return loss;
		}
		set {
			loss = value;
		}
	}

	[SerializeField]
	private int draw;
	public int Draw {
		get {
			return draw;
		}
		set {
			draw = value;
		}
	}
}
