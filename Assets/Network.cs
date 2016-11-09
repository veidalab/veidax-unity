using UnityEngine;
using System.Collections;
using SocketIO;


public class Network : MonoBehaviour {

	public SocketIOComponent socket;

	public GameObject playerPrefab;
	private NetworkMove netMove;

	// Use this for initialization
	void Start () {
		socket = GetComponent<SocketIOComponent>();
		socket.On("open", OnConnected);
		socket.On("spawn", OnSpawned);
		socket.On("move", OnMove);

		playerPrefab = (GameObject) Resources.Load("Player");
		netMove = playerPrefab.GetComponent<NetworkMove>();
		netMove.socket = socket;

	}

	// Callback used when connected
	void OnConnected(SocketIOEvent e) {
		Debug.Log("connected");
	}

	void OnSpawned(SocketIOEvent e) { 
		Debug.Log("another client connected");
		Instantiate (playerPrefab, SetPlayerSpawnPoint(),Quaternion.identity);
	}

	void OnMove(SocketIOEvent e) {
		Debug.Log("player is moving" + e.data);
	}

	Vector3 SetPlayerSpawnPoint() {
		//Vector2 randomPoint = Random.insideUnitCircle * 1.5f;

		float x = 3.0f;
		float y = 1.081f; //TODO: flying units;
		float z = -1.0f;

		return new Vector3(x, y, z);
	}
}
