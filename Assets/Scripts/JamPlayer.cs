using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class JamPlayer : CaptainsMessPlayer {

	public Image icon;
	public Text nameField;
	public Text readyField;
	public Text RedScoreField;
	public Text BlueScoreField;
	public Text SuccessesField;

	[SyncVar]
	public double RedScore;
	[SyncVar]
	public double BlueScore;
	[SyncVar]
	public int Successes;
	[SyncVar]
	public Roles role;
	[SyncVar]
	public bool faction;
	[SyncVar]
	public bool traitor;
	public Color PlayerColor;



	public override void OnStartLocalPlayer(){
		base.OnStartLocalPlayer ();
		PlayerColor = UnityEngine.Random.ColorHSV(0,1,1,1,1,1);
		RedScore = 0;
		BlueScore = 0;
		Successes = 0;
		traitor = false;
	}

	[Command]
	public void CmdRewards(bool Success, bool Faction, double points){
		if (Success)
			Successes += 1;
		if (Faction) {
			RedScore += points;
		} else {
			BlueScore += points;
		}
	}

	public void ChoseSide(bool side){
		faction = side;
	}

	public void TurnCoat(bool faction){
		if (!traitor) {
			traitor = true;
			if (faction) {
				RedScore += 0.75 * BlueScore;
				BlueScore = 0;
			} else {
				BlueScore += 0.75 * RedScore;
				RedScore = 0;
			}
		}
	}

	public void Update()
	{
		RedScoreField.text = RedScore.ToString ();
		BlueScoreField.text = BlueScoreField.ToString ();
	}

}
