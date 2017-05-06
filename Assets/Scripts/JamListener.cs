using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class JamListener : CaptainsMessListener {

	public enum NetworkState{
		Init,
		Offline,
		Connecting,
		Connected,
		Disrupted
	};

	[HideInInspector]
	public NetworkState networkState = NetworkState.Init;

	public GameObject gameSessionPrefab;
	public JamGameSession gameSession;

	public void Start() {
		networkState = NetworkState.Init;

		ClientScene.RegisterPrefab (gameSessionPrefab);
	}

	public override void OnStartConnecting() {
		base.OnStartConnecting ();
	}

	public override void OnStopConnecting () {
		base.OnStopConnecting ();
	}

	public override void OnServerCreated ()
	{
		base.OnServerCreated ();

		JamGameSession oldSession = FindObjectOfType<JamGameSession> ();
		if (oldSession == null) {
			GameObject serverSession = Instantiate (gameSessionPrefab);
			NetworkServer.Spawn (serverSession);
		} else {
			Debug.Log ("Game Session Already Exists");
		}
	}

	public override void OnJoinedLobby ()
	{
		base.OnJoinedLobby ();
	}

	public override void OnLeftLobby ()
	{
		base.OnLeftLobby ();

		networkState = NetworkState.Offline;
	}

	public override void OnCountdownStarted () {
		base.OnCountdownStarted ();
	}

	public override void OnCountdownCancelled () {
		base.OnCountdownCancelled ();
	}

	public override void OnStartGame (List<CaptainsMessPlayer> aStartingPlayers)
	{
		base.OnStartGame (aStartingPlayers);
	}

	public override void OnAbortGame () {
		base.OnAbortGame ();
	}
}
