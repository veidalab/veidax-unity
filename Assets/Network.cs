using UnityEngine;
using System.Collections;
using SocketIO;


public class Network : MonoBehaviour {

	static SocketIOComponent socket;

	public GameObject playerPrefab;

	// Use this for initialization
	void Start () {
		socket = GetComponent<SocketIOComponent>();
		socket.On("open", OnConnected);
		socket.On("spawn", OnSpawned);

		playerPrefab = (GameObject) Resources.Load("Player");

	}

	// Callback used when connected
	void OnConnected(SocketIOEvent e) {
		Debug.Log("connected");
		socket.Emit("move");
	}

	void OnSpawned(SocketIOEvent e) { 
		Debug.Log("another client connected");
		Instantiate (playerPrefab, SetPlayerSpawnPoint(),Quaternion.identity);
	}

	Vector3 SetPlayerSpawnPoint() {
		//Vector2 randomPoint = Random.insideUnitCircle * 1.5f;

		float x = 4.0f;
		float y = 0.1f; //TODO: flying units;
		float z = -1.0f;

		return new Vector3(x, y, z);
	}
}
