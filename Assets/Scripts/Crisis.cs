using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crisis : MonoBehaviour {

	public Roles role;
	public double winReward;
	public double loseReward;
	public Factions winFaction;
	public Factions loseFaction;
	public bool isBlackOp;
	public List<JamPlayer> winners;
	public List<JamPlayer> losers;

	public double winnerRewards() { return winReward/winners.Count; }
	public double loserRewards() { return winReward/winners.Count; }

	public Factions Resolve(List<JamPlayer> players){
		for (int i = 0; i < players.Count; ++i) {
			if (players [i].role == role) {
				winFaction = players [i].faction;
				if (winFaction == Factions.Reds) {
					loseFaction = Factions.Blues;
				} else
					loseFaction = Factions.Reds;
			}
		}
		for (int i = 0; i < players.Count; ++i) {
			if (players [i].faction == winFaction){
				winners.Add (players [i]);
			}else
			{
			losers.Add(players[i]);
			}
		}
		for (int i = 0; i < winners.Count; ++i) {
			players [i].CmdRewards (true, winFaction, winnerRewards ());
		}
		for (int i = 0; i < losers.Count; ++i) {
			players [i].CmdRewards (false, loseFaction, loserRewards ());
		}
		return winFaction;
	}
}

