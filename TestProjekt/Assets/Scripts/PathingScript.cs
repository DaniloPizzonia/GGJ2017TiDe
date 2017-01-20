using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathingScript : MonoBehaviour 
{
	// Please lock the rotation of the enemy!


	// GameObject, that includes every pathNode as a child
	GameObject pathNodeParent;

	// Transform of the current pathNode the enemy is walking to
	Transform targetPathNode = null;

	// Current Child used for the transform
	int currentPathNodeIndex;

	float speed = 5;

	void Start ()
	{
		pathNodeParent = GameObject.FindGameObjectWithTag ("Path");
	}


	void GetNextPathNode()
	{
		if (currentPathNodeIndex < pathNodeParent.transform.childCount)
		{
			targetPathNode = pathNodeParent.transform.GetChild (currentPathNodeIndex);
			currentPathNodeIndex++;
		}

		else
		{
			Debug.Log ("Exit reached.");
			targetPathNode = null;
			ExitReached ();
		}
	}


	void ExitReached()
	{
		Destroy (gameObject);
	}


	void Update()
	{
		// Assign PathNode
		if (targetPathNode == null)
		{
			GetNextPathNode ();

			// If no PathNodes are set
			if (targetPathNode == null)
			{
				Debug.LogError ("Cannot found PathNodes!");
				ExitReached ();
				return;
			}
		}


		Vector3 nextPathVector = targetPathNode.position - this.transform.localPosition;

		Debug.Log ("TargetPos:  " + targetPathNode.position + "EnemyPos: " + this.transform.localPosition + "Movement: " + nextPathVector);

		float distance = speed * Time.deltaTime;

		if (nextPathVector.magnitude <= distance)
		{
			// When Node reached, assign targetPathNode = null to assign new PathNode
			Debug.Log ("Node Reached: " + targetPathNode.name);
			targetPathNode = null;
		}

		// Movement
		transform.Translate (nextPathVector.normalized * distance, Space.World);

		// Rotation
		Quaternion rotation = Quaternion.LookRotation (nextPathVector);
		this.transform.rotation = Quaternion.Lerp(this.transform.rotation, rotation, Time.deltaTime * 5);

	}





}
