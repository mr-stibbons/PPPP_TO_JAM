using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public enum JamGameState{
	Offline,
	Connecting,
	Lobby,
	Countdown,
	Setup,
	Crisis,
	Waiting,
	Rewards,
	GameOver
}

public class JamGameSession : NetworkBehaviour {
	public static JamGameSession instance;

	List<JamPlayer> players;
	CrisisFactory factory;

	JamListener networkListener;
	[SyncVar]
	public JamGameState gameState;

	public int waitTime;

	public void OnDestroy()
	{
	}

	[Server]
	public override void OnStartServer()
	{
		networkListener = FindObjectOfType<JamListener> ();
		gameState = JamGameState.Connecting;
	}

	[Client]
	public override void OnStartClient()
	{
		instance = this;
		networkListener = FindObjectOfType<JamListener>();
	}

	[Server]
	void RunGame(){
		gameState = JamGameState.Setup; 
		List<Roles> availableRoles = new List<Roles> ();
		int RedWins = 0;
		int BlueWins = 0;
		availableRoles.AddRange(new Roles[] {Roles.Assassin, Roles.Commando, Roles.Infiltrator, Roles.Negotiator, Roles.Transporter});
		foreach (JamPlayer player in players) {
			Roles assignedRole = availableRoles[Random.Range (0, availableRoles.Count)];
			player.role = assignedRole;
			availableRoles.Remove (assignedRole);
		}

		List<Crisis> GameCrisis = factory.MakeCrisis (players);

		foreach (Crisis crisis in GameCrisis) {
			FactionSelect ();
			Factions winner = crisis.Resolve(players);	
			if (winner == Factions.Reds) {
				RedWins++;
			}else{
				BlueWins++;
			}
		}

		 FinalScoring (RedWins > BlueWins);
		
	}

	[Server]
	IEnumerator FactionSelect(){
		foreach (JamPlayer players in players) {
			players.faction = Factions.None; 
		}

		while (players.Any(p => p.faction == Factions.None)){
			gameState = JamGameState.Waiting;
			yield return new WaitForSeconds(waitTime);
			//need crash protection
		}
			
	}

	[Server]
	JamPlayer FinalScoring(bool winningFaction){
		if (winningFaction) {
			double highestScore = players.Max (p => p.RedScore);
			return players.Where (p => p.RedScore == highestScore).First ();
		} else {
			double highestScore = players.Max (p => p.BlueScore);
			return players.Where (p => p.BlueScore == highestScore).First ();
		}

	}

	void Update()
	{

	}

}
