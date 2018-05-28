using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelTimer : MonoBehaviour 
{

	private Slider slider;

	private GameObject player;

	public float time = 10f;

	public float timeBurn = 1f;

	// Use this for initialization
	void Awake () 
	{
		GetReferences ();
	}

	// Update is called once per frame
	void Update () 
	{
		if (!player)
			return;

		if (time> 0) 
		{
			//The (Time.deltaTime * 0.2f) slows down time!!!!!
			time -= timeBurn * (Time.deltaTime * 0.2f);
			slider.value = time;
		} 
		else 
		{
			Destroy (player);
			GetComponent<GameplayController> ().PlayerDied ();
		}
	}

	void GetReferences()
	{
		player = GameObject.Find ("Player");
		slider = GameObject.Find ("Time Slider").GetComponent<Slider> ();

		slider.minValue = 0f;
		slider.maxValue = time;
		slider.value = slider.maxValue;
	}
}