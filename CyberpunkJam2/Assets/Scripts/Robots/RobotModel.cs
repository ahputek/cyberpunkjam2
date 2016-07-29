using UnityEngine;
using System.Collections;

using Framework.MVC;

public class RobotModel : Model<CyberpunkApplication> {

	private string name;
	public string Name {
		get {
			return name;
		}
		set {
			name = value;
		}
	}

	private int health;
	public int Health {
		get {
			return health;
		}
		set {
			health = Mathf.Clamp(value, 0, 10000);
		}
	}

	private int accuracy;
	public int Accuracy {
		get {
			return accuracy;
		}
		set {
			accuracy = Mathf.Clamp(value, 50, 100);
		}
	}

	private int hardness;
	public int Hardness {
		get {
			return hardness;
		}
		set {
			hardness = Mathf.Clamp(value, 50, 100);
		}
	}

	private int speed;
	public int Speed {
		get {
			return speed;
		}
		set {
			speed = Mathf.Clamp(value, 50, 100);
		}
	}

	private int power;
	public int Power {
		get {
			return power;
		}
		set {
			power = Mathf.Clamp(value, 50, 100);
		}
	}

	private int popularity;
	public int Popularity {
		get {
			return popularity;
		}
		set {
			popularity = value;
		}
	}

	private int weight;
	public int Weight {
		get {
			return weight;
		}
		set {
			weight = value;
		}
	}

	private int win;
	public int Win {
		get {
			return win;
		}
		set {
			win = value;
		}
	}

	private int loss;
	public int Loss {
		get {
			return loss;
		}
		set {
			loss = value;
		}
	}

	private int draw;
	public int Draw {
		get {
			return draw;
		}
		set {
			draw = value;
		}
	}

	private int level;
	public int Level {
		get {
			return level;
		}
		set {
			level = value;
		}
	}

	private int exp;
	public int Exp {
		get {
			return exp;
		}
		set {
			exp = value;
		}
	}

	private int skillPoints;
	public int SkillPoints {
		get {
			return skillPoints;
		}
		set {
			skillPoints = value;
		}
	}
}
