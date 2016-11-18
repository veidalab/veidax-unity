using UnityEngine;
using System.Collections.Generic;
using SocketIO;


public class Network : MonoBehaviour {

	public SocketIOComponent socket;

	public GameObject playerPrefab;

	public GameObject myPlayer;

	private NetworkMove netMove;

	Dictionary<string, GameObject> players;

	// Use this for initialization
	void Start () {
		socket = GetComponent<SocketIOComponent>();
		socket.On("open", OnConnected);
		socket.On("spawn", OnSpawned);
		socket.On("move", OnMove);
		socket.On("disconnected", OnDisconnected);
		socket.On("requestPosition", OnRequestPosition);
		socket.On("updatePosition", OnUpdatePosition);

		playerPrefab = (GameObject) Resources.Load("Player");
		netMove = playerPrefab.GetComponent<NetworkMove>();
		netMove.socket = socket;

		players = new Dictionary<string, GameObject> ();

	}

	// Callback used when connected
	void OnConnected(SocketIOEvent e) {
		Debug.Log("connected to server");
	}

	void OnSpawned(SocketIOEvent e) { 
		Debug.Log("spawning new player: " + e.ToString());
		var player = (GameObject) Instantiate (playerPrefab, SetPlayerSpawnPoint(),Quaternion.identity);

		players.Add (e.data["id"].ToString (), player);
		player.GetComponent<UniqueId>().uniqueId = e.data["id"].ToString ();

		//if this is the first player, let's set the ground truth = to that ID
		if (players.Count == 1){
			GameObject[] ground = GameObject.FindGameObjectsWithTag("Ground");
			ground[0].GetComponent<UniqueId>().uniqueId = e.data["id"].ToString ();
		}
		Debug.Log("total players connected: " + players.Count);
	}

	void OnMove(SocketIOEvent e) {
		Debug.Log("player is moving" + e.data);

		var player = players [e.data ["id"].ToString()];
		var position = new Vector3(GetFloatFromJson(e.data,"x"), 0, GetFloatFromJson(e.data,"y"));
		var navPos = player.GetComponent<NavigatePosition> ();

		navPos.NavigateToRemote(position, e.data ["id"].ToString());
	}

	void OnDisconnected(SocketIOEvent e) {
		Debug.Log("Client disconnected from backend" + e.data);

		var player = players[e.data["id"].ToString()];
		Destroy (player);
		players.Remove(e.data["id"].ToString());
	}

	void OnRequestPosition(SocketIOEvent e) {
		Debug.Log("server is requesting position" + e.data);
		socket.Emit("updatePosition", new JSONObject(VectorToJSON(myPlayer.transform.position)));
	}

	void OnUpdatePosition(SocketIOEvent e) {
		Debug.Log("server is requesting position" + e.data);
		var player = players [e.data ["id"].ToString()];
		var position = new Vector3(GetFloatFromJson(e.data,"x"), 0, GetFloatFromJson(e.data,"y"));	
		player.transform.position = position;
	}

	float GetFloatFromJson(JSONObject data, string key) {
		return float.Parse(data [key].ToString().Replace("\"",""));
	}

	Vector3 SetPlayerSpawnPoint() {
		Vector2 randomPoint = Random.insideUnitCircle * 3.5f;

		float x = randomPoint.x;
		float y = 1.081f; //TODO: flying units;
		float z = randomPoint.y;

		return new Vector3(x, y, z);
	}

	public static string VectorToJSON (Vector3 vector) {
		return string.Format (@"{{""x"":""{0}"", ""y"":""{1}""}}", vector.x, vector.z);
	}
}
