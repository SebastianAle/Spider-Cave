using UnityEngine;
using System.Collections;

public class Bouncy : MonoBehaviour 
{
	public float force = 500f;

	private Animator anim;


	// Use this for initialization
	void Awake () 
	{
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.tag == "Player") 
		{
			target.gameObject.GetComponent<PlayerScript> ().BouncePlayerWithBouncy (force);
			StartCoroutine (AnimateBouncy ());
		}
	}

	IEnumerator AnimateBouncy()
	{
		anim.Play ("Up");
		yield return new WaitForSeconds (0.5f);
		anim.Play ("Down");
	}
}
