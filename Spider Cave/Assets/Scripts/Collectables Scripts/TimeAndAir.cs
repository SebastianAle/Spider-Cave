using UnityEngine;
using System.Collections;

public class TimeAndAir : MonoBehaviour 
{

	public float airValue = 15f;

	public float timeValue = 20f;

	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.tag == "Player") 
		{
			if (gameObject.name == "Air Collectable") 
			{
				GameObject.Find ("Gameplay Controller").GetComponent<AirTimer> ().air += airValue;
			} 
			else 
			{
				GameObject.Find ("Gameplay Controller").GetComponent<LevelTimer> ().time += timeValue;
			}
			Destroy (gameObject);
		}
	}

}
