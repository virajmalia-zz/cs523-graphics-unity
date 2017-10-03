using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace CompletedProject
{

	public class ClickToMove : MonoBehaviour
	{
		private NavMeshAgent navMeshAgent;
		private Transform target;

		// Use this for initialization
		void Awake()
		{
			navMeshAgent = GetComponent<NavMeshAgent>();
		}

		// Update is called once per frame
		void Update()
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Input.GetButtonDown("Fire1"))
			{
				if (Physics.Raycast(ray, out hit, 1000)){
					navMeshAgent.destination = hit.point;
				}
			}
		}
	}

}