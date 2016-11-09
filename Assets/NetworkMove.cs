using UnityEngine;
using System.Collections;
using SocketIO;

public class NetworkMove : MonoBehaviour {

	public SocketIOComponent socket;

	public void OnMove (Vector3 position) {
		//send position to node
		Debug.Log("sending position to node" + position);
		socket.Emit("move", new JSONObject(VectorToJSON(position)));
	}

	string VectorToJSON (Vector3 vector) {
		return string.Format (@"{{""x"":""{0}"", ""y"":""{1}""}}", vector.x, vector.z);
	}
}
