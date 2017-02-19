using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour {

	//public AudioClip applause; 
	//public AudioClip swish; 

	//private AudioSource source2;
	//private float lowPitchRange = .75f;
	//private float highPitchRange = 1.25f;

	// Use this for initialization
	void Start () {
		//source2 = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")		//If it enters this loop, you have scored 
		{
			//Debug.Log ("Bruhh");
			//source2.PlayOneShot (applause, 3f);	
			//System.Threading.Thread.Sleep (500);		// 
			//Destroy (gameObject); 

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}




}
