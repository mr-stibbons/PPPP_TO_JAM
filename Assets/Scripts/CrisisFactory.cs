using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrisisFactory : MonoBehaviour {

	public List<Roles> activeRoles; 
	public List<Crisis> CrisisList;
	public int numberOfPlayers; 

	public List<Crisis> MakeCrisis(List<JamPlayer> players){
		List<Roles> activeRoles = new List<Roles> ();
		int numberOfPlayers = players.Count;
		for (int i = 0; i < players.Count; ++i) {
			activeRoles.Add (players [i].role);
		}
		MakeRound (false);
		MakeRound (true);
		MakeFinale ();
		return CrisisList;
	}
	

	public void MakeRound(bool blackRound){
		for(int i = 0; i < activeRoles.Count; ++i) {
			Crisis currentCrisis =new Crisis();
			currentCrisis.role = activeRoles[i];
			currentCrisis.winReward = 120*numberOfPlayers;
			currentCrisis.loseReward = 60 * numberOfPlayers; //adjust this as time goes on
			currentCrisis.isBlackOp = blackRound;
			CrisisList.Add (currentCrisis);
		}

	} 

	public void MakeFinale()
	{
		int extraCrisis = Random.Range (3, 8);
		for (int i = 0; i < extraCrisis; i++) {
			Crisis currentCrisis =new Crisis();
			currentCrisis.role = activeRoles [Random.Range (0, activeRoles.Count)];
			currentCrisis.winReward = 240*numberOfPlayers;
			currentCrisis.loseReward = 120 * numberOfPlayers;
		}
	}

}
