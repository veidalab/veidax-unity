﻿using UnityEngine;
using System.Collections;

public class InteractableItem : MonoBehaviour {

	protected Rigidbody rigidbody;

	protected bool currentlyInteracting;

	private WandController attachedWand;

	private Transform interactionPoint;

	private float velocityFactor = 20000f;
	private float rotationFactor = 600f;
	private Vector3 posDelta;  // posDelta = (hand_pos - obj_pos)
	private Quaternion rotationDelta;
	private float angle;
	private Vector3 axis;

	// Use this for initialization
	protected void Start () {
		rigidbody = GetComponent<Rigidbody>();
		interactionPoint = new GameObject().transform;
		velocityFactor /= rigidbody.mass;
	}
	
	// Update is called once per frame
	protected void Update () {
		if (attachedWand && currentlyInteracting) {
			posDelta = attachedWand.transform.position - interactionPoint.position;
			this.rigidbody.velocity = posDelta * velocityFactor * Time.fixedDeltaTime;

			rotationDelta = attachedWand.transform.rotation * Quaternion.Inverse(interactionPoint.rotation);
			rotationDelta.ToAngleAxis(out angle, out axis);

			if (angle > 180){
				angle -= 360;
			}

			this.rigidbody.angularVelocity = (Time.fixedDeltaTime * angle * axis) * rotationFactor;
		}
	}

	public void BeginInteraction(WandController wand) {
		attachedWand = wand;
		interactionPoint.position = wand.transform.position;
		interactionPoint.rotation = wand.transform.rotation;
		interactionPoint.SetParent(transform, true);

		currentlyInteracting = true;
	}

	public void EndInteraction(WandController wand) {
		if (wand == attachedWand) {
			attachedWand = null;
			currentlyInteracting = false;
		}
	}

	public bool IsInteracting(){
		return currentlyInteracting;
	}

	private void OnDestroy() {
		if(interactionPoint) {
			Destroy(interactionPoint.gameObject);
		}
	}
}
