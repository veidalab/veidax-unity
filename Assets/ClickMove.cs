using UnityEngine;
using System.Collections;

public class ClickMove : MonoBehaviour {

	public GameObject player;
	
	public void OnClick (Vector3 position) {
		var navPos = player.GetComponent<NavigatePosition> ();
		navPos.NavigateTo (position);
	}
}
