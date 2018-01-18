using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour {

	private bool isRewinding = false;

	public float recordSeconds = 5f;

	List<RewindableObject> rewindableObjects;

	Rigidbody rb;

	void Start() 
	{
		rewindableObjects = new List<RewindableObject>();
		rb = GetComponent<Rigidbody>();
	}

	void Update() 
	{
		if (Input.GetKeyDown(KeyKode.P)) 
			StartRewind();

		if (Input.GetKeyUp(KeyCode.P)) 
			StopRewind();	
	}

	void FixedUpdate() 
	{
		if (isRewinding)
			Rewind();
		else
			Record();
	}

	void Rewind() 
	{
		if (rewindableObjects.Count > 0) {
			RewindableObject rewindableObject = rewindableObjects[0];
			transform.position = rewindableObject.position;
			transform.rotation = rewindableObject.rotation;

			rewindableObjects.RemoveAt(0);
		} else {
			StopRewind();
		}
	}

	void Record() 
	{
		if (rewindableObject.Count > Math.Round(recordSeconds / Time.fixedDeltaTime)) {
			rewindableObjects.RemoveAt(rewindableObjects.Count - 1);
		}

		rewindableObjects.Insert(0, new RewindableObject(transform.position, transform.rotation));
	}

	public void StartRewind() 
	{
		isRewinding = true;
		rb.isKinematic = true;
	}

	public void StopRewind() 
	{
		isRewinding = false;
		rb.isKinematic = false;
	}

}