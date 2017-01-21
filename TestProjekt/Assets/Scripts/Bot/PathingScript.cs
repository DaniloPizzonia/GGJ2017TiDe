using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace unsernamespace {
    public class PathingScript : MonoBehaviour
    {
        [SerializeField]
        private Bot bot;

		[SerializeField]
		private UnityEvent onExitReach = new UnityEvent();
		public UnityEvent OnExitReach { get { return onExitReach; } }
		// Please lock the rotation of the enemy!


		// GameObject, that includes every pathNode as a child
		GameObject pathNodeParent;

        // Transform of the current pathNode the enemy is walking to
        Transform targetPathNode = null;

        // Current Child used for the transform
        int currentPathNodeIndex;
        void Start()
        {
            pathNodeParent = GameObject.FindGameObjectWithTag("Path");
        }


        void GetNextPathNode()
        {
            if (currentPathNodeIndex < pathNodeParent.transform.childCount)
            {
                targetPathNode = pathNodeParent.transform.GetChild(currentPathNodeIndex);
                currentPathNodeIndex++;
            }

            else
            {
                targetPathNode = null;
                ExitReached();
            }
        }


        void ExitReached()
        {
			onExitReach.Invoke();
            Destroy(gameObject);
        }


        void Update()
        {
            // Assign PathNode
            if (targetPathNode == null)
            {
                GetNextPathNode();

                if (targetPathNode == null)
                {
                    ExitReached();
                    return;
                }
            }


            Vector3 nextPathVector = targetPathNode.position - this.transform.localPosition;


            float distance = bot.Speed * Time.deltaTime;

            if (nextPathVector.magnitude <= distance)
            {
                targetPathNode = null;
            }

            // Movement
            transform.Translate(nextPathVector.normalized * distance, Space.World);

/*            // Rotation
            Quaternion rotation = Quaternion.LookRotation(nextPathVector);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, rotation, Time.deltaTime * 5);*/

        }



    }

}
