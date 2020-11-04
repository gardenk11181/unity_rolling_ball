using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCan : MonoBehaviour
{
	public float rotateSpeed;

	// Start is called before the first frame update
	void Awake() // initiating variables
	{	}

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime,Space.World);
	}
}
