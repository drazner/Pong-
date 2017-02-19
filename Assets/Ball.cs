using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float speed; 
	public float jumpMult; 
	public float horizontalMult;
	public float heightMult; 
	public float depthMult; 
	private float change;
	private Rigidbody rb; 
	private bool hit;

	private int blue;
	private int red;
	public bool isRed;

	public AudioClip swoosh; 
	public AudioClip bruhh; 
	public AudioClip applause;
	private AudioSource source; 
	private float lowPitchRange = .9f;
	private float highPitchRange = 1.1f; 

	// Use this for initialization
	void Start () 
	{
		hit = true;
		rb = GetComponent<Rigidbody> ();
		source = GetComponent<AudioSource> ();		//Initialize audio component 
		blue = 10;
		red = 10;
		isRed = true;
		change = 1;

	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag.Equals ("Cup")) {
			hit = true;
			//horizontalMult = -horizontalMult;		
			//depthMult = -depthMult; 
			Debug.Log ("Nice try");
			rb.velocity = Vector3.zero; 
			rb.angularVelocity = Vector3.zero; 
		} else if (collision.gameObject.tag.Equals ("Top")) 
		{
			hit = true;
			System.Threading.Thread.Sleep (500);
			source.PlayOneShot (applause, 3f);
			if (isRed) 
			{
				red--;
			} 
			else 
			{
				blue--;
			}

			if (red <= 0) 
			{
				Debug.Log("Congrats Player 1 you won!");
				Destroy (gameObject);
			}
			else if( blue <= 0)
			{
				Debug.Log("Congrats Player 2 you won!");
				Destroy (gameObject);
			}
			rb.velocity = Vector3.zero; 
			rb.angularVelocity = Vector3.zero; 
			Destroy (collision.gameObject);  
		}

		//Input.getMousebuttondown(0) 
			//transform.position = (new Vector3 (0,0,-24)); 

	}

	public void changeTurn()
	{
		isRed = false;
	}

	public bool getCollision()
	{
		return hit;
	}

	public void setCollision(bool b)
	{
		hit = b;
	}

	public void switchOrientation()
	{
		rb.angularVelocity = Vector3.zero; 
		horizontalMult = -horizontalMult;			//Switches orientation of ball whenever sides switch
		depthMult = -depthMult; 	
		change = -change;
	}


	// Update is called once per frame
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal")*change; 
		float moveVertical = Input.GetAxis ("Vertical")*change; 
		float moveJump = Input.GetAxis ("Jump"); 

		Vector3 movement = new Vector3 (moveHorizontal, jumpMult*moveJump, moveVertical); 

		rb.AddForce (movement * speed); 

		if ((transform.position.y < -1) || (transform.position.y > 20) || (transform.position.z >34))
		{
			transform.position = Vector3.zero; 
			hit = true;
			source.PlayOneShot (bruhh, 3f); 
			Debug.Log ("Where ya aimin'?");
			rb.velocity = Vector3.zero; 
			rb.angularVelocity = Vector3.zero; 
		}
	}

	Vector2 mMouseDown = Vector2.zero;

	void Update () 
	{
		if (Input.GetMouseButtonDown (0))
		{											//Senses when the left mouse button is pressed. index 0 is left click, 1 would be right click
			mMouseDown = Input.mousePosition;		//A vector containing the location of the cursor when you click
			source.pitch = Random.Range (lowPitchRange, highPitchRange); 	//Randomize the pitch of the sound for organic variation
		}

		if (Input.GetMouseButton (0))
		{			
			Vector2 mMouseCur = Input.mousePosition;
			Vector2 vMouse = mMouseCur - mMouseDown;		//A vector showing where the mouse moved from since you had started clicking
			//if(Input.GetMouseButtonUp(0))
			if (vMouse.magnitude > 30)
			{				
				source.PlayOneShot(swoosh,1f);				//Plays swoosh sound effect
				// TODO: fire the ball vMouse direction (but make sure to create your own Z force)
				//Vector3 movement = new Vector3 (horizontalMult*vMouse.x, heightMult*vMouse.y, depthMult);

				//rb.AddForce (movement * speed); 
				rb.AddForce(new Vector3(horizontalMult*vMouse.x,6,depthMult) * speed);
			}
				

			//Input.touchCount					for mobile devices
			//Input.touches[0].position			touch[0] is the first finger it senses
		}


	}
}

