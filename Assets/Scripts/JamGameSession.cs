using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public enum JamGameState{
	Offline,
	Connecting,
	Lobby,
	Countdown,
	Setup,
	Crisis,
	Rewards,
	GameOver
}

public class JamGameSession : NetworkBehaviour {
	public static JamGameSession instance;

	List<JamPlayer> players;
	CrisisFactory factory;

	[SyncVar]
	public JamGameState gameState;

	public void OnDestroy()
	{
	}

	[Server]
	public override void OnStartServer()
	{
		
	}

	[Server]
	void RunGame(){
		List<Roles> availableRoles = new List<Roles> ();
		availableRoles.AddRange(new Roles[] {Roles.Assassin, Roles.Commando, Roles.Infiltrator, Roles.Negotiator, Roles.Transporter});
		foreach (JamPlayer player in players) {
			Roles assignedRole = availableRoles[Random.Range (0, availableRoles.Count)];
			player.role = assignedRole;
			availableRoles.Remove (assignedRole);
		}

		List<Crisis> GameCrisis = factory.MakeCrisis (players);

		foreach (Crisis crisis in GameCrisis) {
			crisis.Resolve(players);	
		}
	}

}
