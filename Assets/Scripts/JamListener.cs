using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamListener : CaptainsMessListener {

	public enum NetworkState{
		Init,
		Offline,
		Connecting,
		Connected,
		Disrupted
	};
	public NetworkState networkState = NetworkState.Init;

	public JamGameSession gameSession;
}
