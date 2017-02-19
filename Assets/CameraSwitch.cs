using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour 
{
	public GameObject Camera1; 
	public GameObject Camera2; 

	public Ball b;

	 void Update()
	{
		Camera1.tag = "MainCamera";
		Camera2.tag = "Camera2";
		if (b.getCollision ()) 
		{
			if (Camera1.GetComponent<Camera> ().enabled) {
				Camera2.GetComponent<Camera> ().enabled = true;
				Camera1.GetComponent<Camera> ().enabled = false; 
				b.transform.position = new Vector3 (0, 0, 14f);
				b.switchOrientation ();
				b.changeTurn ();
				Debug.Log ("Team 1, you're up!");
			} else if (Camera2.GetComponent<Camera> ().enabled) {
				Camera1.GetComponent<Camera> ().enabled = true;
				Camera2.GetComponent<Camera> ().enabled = false;
				b.transform.position = Vector3.zero;
				b.switchOrientation (); 
				b.changeTurn ();
				Debug.Log ("Team 2, you're up!");
			}
			b.setCollision (false);
		}
	}

}
