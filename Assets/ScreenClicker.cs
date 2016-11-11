using UnityEngine;
using System.Collections;

public class ScreenClicker : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown ("Fire1")){
			Clicked ();
		}
	}

	void Clicked () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit hit = new RaycastHit ();

		//Debug.Log(Physics.Raycast (ray, out hit));

		if (Physics.Raycast (ray, out hit)) {
			Debug.Log(hit.collider.gameObject.name);
			ClickMove clickMove = hit.collider.gameObject.GetComponent<ClickMove>();
			clickMove.OnClick(hit.point);
		}
	}
}
