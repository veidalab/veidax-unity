using UnityEngine;
using System.Collections;

public class ClickMove : MonoBehaviour {

	public GameObject player;

	public void OnClick (Vector3 position) {
		var navPos = player.GetComponent<NavigatePosition> ();
		var netMove = player.GetComponent<NetworkMove> ();
		navPos.NavigateToLocal (position);
		netMove.OnMove (position);
	}
}
