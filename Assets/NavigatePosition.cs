using UnityEngine;
using System.Collections;

public class NavigatePosition : MonoBehaviour {

	public NavMeshAgent agent;
	public GameObject playerLoaded;
	public GameObject[] players;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		agent.enabled = false;
	}
	

	public void NavigateToLocal (Vector3 position) {
		players = GameObject.FindGameObjectsWithTag("Player");

		foreach (GameObject playerLoaded in players) {
			Debug.Log("local playerId: " + GameObject.FindGameObjectsWithTag("Ground")[0].GetComponent<UniqueId>().uniqueId);
			Debug.Log("prefabId: " + playerLoaded.GetComponent<UniqueId>().uniqueId);
			if(object.Equals(playerLoaded.GetComponent<UniqueId>().uniqueId, GameObject.FindGameObjectsWithTag("Ground")[0].GetComponent<UniqueId>().uniqueId)){
				Debug.Log("moving local playerId: " + GameObject.FindGameObjectsWithTag("Ground")[0].GetComponent<UniqueId>().uniqueId);
				agent = playerLoaded.GetComponent<NavMeshAgent> ();
				agent.enabled = true;
				if(agent.isOnNavMesh){
					agent.SetDestination (position);
				} else {
					Debug.Log("Not on NavMesh");
				}
			}
		}
	}

	public void NavigateToRemote (Vector3 position, string uniqueId) {
		players = GameObject.FindGameObjectsWithTag("Player");

		foreach (GameObject playerLoaded in players) {
			Debug.Log("remote playerId: " + uniqueId);
			Debug.Log("prefabId: " + playerLoaded.GetComponent<UniqueId>().uniqueId);
			if(object.Equals(playerLoaded.GetComponent<UniqueId>().uniqueId, uniqueId)){
				Debug.Log("moving remote playerId: " + playerLoaded.GetComponent<UniqueId>().uniqueId);
				agent = playerLoaded.GetComponent<NavMeshAgent> ();
				agent.enabled = true;
				if(agent.isOnNavMesh){
					agent.SetDestination (position);
				} else {
					Debug.Log("Not on NavMesh");
				}
			}
		}
	}
}
