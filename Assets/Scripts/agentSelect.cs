using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class agentSelect : MonoBehaviour {

	private NavMeshAgent goodGuy;
	private bool set = false;
	private bool selected = false;
	private Vector3 MoveTo;

	// Use this for initialization
	void Start () {
		goodGuy = gameObject.GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (selected && set) {
			set = true;
			goodGuy.SetDestination (MoveTo);
		}
	}

	void Select(int x){
		selected = true;
	}

	void Deselect(int x){
		selected = false;
	}

	void Destination(Vector3 d){
		MoveTo = d;
		set = true;
	}
}