using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AirTimer : MonoBehaviour 
{

	private Slider slider;

	private GameObject player;

	public float air = 10f;

	public float airBurn = 1f;

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

		if (air > 0) 
		{
			//The (Time.deltaTime * 0.2f) slows down time!!!!!
			air -= airBurn * (Time.deltaTime * 0.2f);
			slider.value = air;
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
		slider = GameObject.Find ("Air Slider").GetComponent<Slider> ();

		slider.minValue = 0f;
		slider.maxValue = air;
		slider.value = slider.maxValue;
	}























}
