using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour {

	public GameObject spawn;
	public GameObject bulletObj;
	public float bulletSpeed = 85000f;
	bool canFire = true;
	public Rigidbody rb;
	public GameObject rifle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		FireBullet();
	}

	void FireBullet() 
	{

		if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.F)) && canFire)
		{
			//Create a new bullet
			GameObject newBullet = Instantiate(bulletObj, spawn.transform.position, spawn.transform.rotation) as GameObject;

			//Give it speed
			rb = newBullet.GetComponent<Rigidbody>();

			rb.AddForce(-rifle.transform.right * bulletSpeed);

			//rb.AddForce(spawn.transform.position.x,spawn.transform.position.y,spawn.transform.position.z);


			canFire = false;
		}

		//Has to release the trigger to fire again
		if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.F))
		{
			canFire = true;
		}
	}
}
