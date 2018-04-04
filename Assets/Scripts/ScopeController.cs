using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScopeController : MonoBehaviour {

	// Use this for initialization

	public Animator animator;
	private bool IsScope = false;
	public GameObject scopeoverlay;
	public Camera maincamera;
	public GameObject weaponcamera;

	private float zoomFOV = 15f;
	private float normalFOV ;

	void Start(){
		
	
	}
	void Update(){
	

		if  (Input.GetMouseButtonDown(2)) {
			Debug.Log("Mouse click");
			IsScope = !IsScope;
			animator.SetBool ("Scoped", IsScope);
		
			if (IsScope)
				StartCoroutine ("OnScoped");
			else
				Unscoped ();
		}

	}

	void Unscoped(){

		scopeoverlay.SetActive (false);
		weaponcamera.SetActive (true);
	}

	IEnumerator OnScoped(){
	
		yield return new WaitForSeconds (.25f);
		scopeoverlay.SetActive (true);
		weaponcamera.SetActive (false);
		normalFOV = maincamera.fieldOfView;
		maincamera.fieldOfView = zoomFOV;
	}

}
