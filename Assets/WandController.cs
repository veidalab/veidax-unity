using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WandController : MonoBehaviour {

	private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
	//private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

	private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
	private SteamVR_TrackedObject trackedObj;

	HashSet<InteractableItem> objectsHoveringOver = new HashSet<InteractableItem>();

	private InteractableItem closestItem;
	private InteractableItem interactingItem;
    public CameraController cam;

    // Use this for initialization
    void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
		if(controller == null){
			Debug.Log("Controller not initialized");
			return;
		}

        if (controller.GetTouch(touchPad))
        {
            Vector2 dir = controller.GetAxis();
            float rotation = -head.GetComponent<Transform>().rotation.eulerAngles.y;
            float sin = Mathf.Sin(rotation * Mathf.Deg2Rad);
            float cos = Mathf.Cos(rotation * Mathf.Deg2Rad);
            float tx = dir.x;
            float ty = dir.y;

            dir.x = (cos * tx) - (sin * ty);
            dir.y = (sin * tx) + (cos * ty);

            if (dir.x < -0.2)
            {
                if (dir.y < -0.2)
                    cam.Move("Backward and Left");
                else if (dir.y > 0.2)
                    cam.Move("Forward and Left");
                else
                    cam.Move("Left");

            }
            else if (dir.x > 0.2)
            {
                if (dir.y < -0.2)
                    cam.Move("Backward and Right");
                else if (dir.y > 0.2)
                    cam.Move("Forward and Right");
                else
                    cam.Move("Right");

            }
            else
            {
                if (dir.y < -0.2)
                    cam.Move("Backward");
                else if (dir.y > 0.2)
                    cam.Move("Forward");

            }

        }

        if (controller.GetPressDown(gripButton)) {
			float minDistance = float.MaxValue;

			float distance;
			foreach (InteractableItem item in objectsHoveringOver){
				distance = (item.transform.position - transform.position).sqrMagnitude;

				if (distance < minDistance){
					minDistance = distance;
					closestItem = item;
				}
			}

			interactingItem = closestItem;
			closestItem = null;

			if (interactingItem){
				if (interactingItem.IsInteracting()){
					interactingItem.EndInteraction(this);
				}

				interactingItem.BeginInteraction(this);
			}

		}
		if(controller.GetPressUp(gripButton) && interactingItem != null) {
			interactingItem.EndInteraction(this);
		}
	}

	private void OnTriggerEnter(Collider collider) {
		InteractableItem collidedItem = collider.GetComponent<InteractableItem>();
		if (collidedItem) {
			objectsHoveringOver.Add(collidedItem);
		}
	}

	private void OnTriggerExit(Collider collider) {
		InteractableItem collidedItem = collider.GetComponent<InteractableItem>();
		if (collidedItem) {
			objectsHoveringOver.Remove(collidedItem);
		}
	}
}
