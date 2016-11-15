﻿using UnityEngine;
using System.Collections.Generic;
using SocketIO;


public class Network : MonoBehaviour {

	public SocketIOComponent socket;

	public GameObject playerPrefab;

	private NetworkMove netMove;

	Dictionary<string, GameObject> players;

	// Use this for initialization
	void Start () {
		socket = GetComponent<SocketIOComponent>();
		socket.On("open", OnConnected);
		socket.On("spawn", OnSpawned);
		socket.On("move", OnMove);

		playerPrefab = (GameObject) Resources.Load("Player");
		netMove = playerPrefab.GetComponent<NetworkMove>();
		netMove.socket = socket;

		players = new Dictionary<string, GameObject> ();

	}

	// Callback used when connected
	void OnConnected(SocketIOEvent e) {
		Debug.Log("connected");
	}

	void OnSpawned(SocketIOEvent e) { 
		Debug.Log("spawned" + e.ToString());
		var player = (GameObject) Instantiate (playerPrefab, SetPlayerSpawnPoint(),Quaternion.identity);

		players.Add (e.data["id"].ToString (), player);
		player.GetComponent<UniqueId>().uniqueId = e.data["id"].ToString ();

		//if this is the first player, let's set the ground truth = to that ID
		if (players.Count == 1){
			GameObject[] ground = GameObject.FindGameObjectsWithTag("Ground");
			ground[0].GetComponent<UniqueId>().uniqueId = e.data["id"].ToString ();
		}
		Debug.Log("count: " + players.Count);
	}

	void OnMove(SocketIOEvent e) {
		Debug.Log("player is moving" + e.data);

		var player = players [e.data ["id"].ToString()];
		var position = new Vector3(GetFloatFromJson(e.data,"x"), 0, GetFloatFromJson(e.data,"y"));
		var navPos = player.GetComponent<NavigatePosition> ();

		navPos.NavigateTo(position);
	}

	Vector3 SetPlayerSpawnPoint() {
		Vector2 randomPoint = Random.insideUnitCircle * 3.5f;

		float x = randomPoint.x;
		float y = 1.081f; //TODO: flying units;
		float z = randomPoint.y;

		return new Vector3(x, y, z);
	}

	float GetFloatFromJson(JSONObject data, string key) {
		return float.Parse(data [key].ToString().Replace("\"",""));
	}
}
