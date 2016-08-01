using UnityEngine;
using System.Collections;

public class RobotSpriteHandler : MonoBehaviour {

	private const string PATH = "Characters/";

	[SerializeField]
	private string characterId;

	[SerializeField]
	private SpriteRenderer head;

	[SerializeField]
	private SpriteRenderer upperBody;

	[SerializeField]
	private SpriteRenderer rightShoulder;

	[SerializeField]
	private SpriteRenderer rightArm;

	[SerializeField]
	private SpriteRenderer rightFist;

	[SerializeField]
	private SpriteRenderer leftShoulder;

	[SerializeField]
	private SpriteRenderer leftArm;

	[SerializeField]
	private SpriteRenderer leftFist;

	[SerializeField]
	private SpriteRenderer lowerBody;

	[SerializeField]
	private SpriteRenderer rightThigh;

	[SerializeField]
	private SpriteRenderer rightKnee;

	[SerializeField]
	private SpriteRenderer rightFoot;

	[SerializeField]
	private SpriteRenderer leftThigh;

	[SerializeField]
	private SpriteRenderer leftKnee;

	[SerializeField]
	private SpriteRenderer leftFoot;

	private void Start () {
		Load(this.characterId);
	}

	private void Load (string characterId) {
		SetSprite(this.head, characterId, "Head");
		SetSprite(this.upperBody, characterId, "Upper_Body");
		SetSprite(this.rightShoulder, characterId, "Right_Shoulder");
		SetSprite(this.rightArm, characterId, "Right_Arm");
		SetSprite(this.rightFist, characterId, "Right_Fist");
		SetSprite(this.leftShoulder, characterId, "Left_Shoulder");
		SetSprite(this.leftArm, characterId, "Left_Arm");
		SetSprite(this.leftFist, characterId, "Left_Fist");
		SetSprite(this.lowerBody, characterId, "Lower_Body");
		SetSprite(this.rightThigh, characterId, "Right_Thigh");
		SetSprite(this.rightKnee, characterId, "Right_Knee");
		SetSprite(this.rightFoot, characterId, "Right_Foot");
		SetSprite(this.leftThigh, characterId, "Left_Thigh");
		SetSprite(this.leftKnee, characterId, "Left_Knee");
		SetSprite(this.leftFoot, characterId, "Left_Foot");
	}

	private void SetSprite (SpriteRenderer renderer, string characterId, string bodyPart) {
		renderer.sprite = Resources.Load<Sprite>(PATH + characterId + "/" + characterId + "_" + bodyPart);
	}
}