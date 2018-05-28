using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	private Transform player;

	public float minX, maxX;

	void Awake()
	{
		player = GameObject.Find ("Player").transform;
	}
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (player != null) 
		{
			Vector3 temp = transform.position;
			temp.x = player.position.x;
			if (temp.x < minX) {
				temp.x = minX;
			}
			if (temp.x > maxX) {
				temp.x = maxX;
			}

			//I Don't like this
			//temp.y = player.position.y + 3.2f;

			transform.position = temp;
		}
	}
}
