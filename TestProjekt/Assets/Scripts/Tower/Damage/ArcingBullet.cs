using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace unsernamespace
{
	
	public class ArcingBullet : Bullet
	{
		private float speedY;
		private Vector3 origin;

		public GameObject explosionPrefab;

		public override void Bind (DamageEffect damage, Bot target)
		{
			base.Bind (damage, target);

			origin = transform.position;
			speedY = speed;
		}
		
		protected override void UpdateTrajectory ()
		{
			Vector3 targetDir = target.transform.position - transform.position;

			speedY -= 9.81f * Time.deltaTime;

			if((transform.position - origin).sqrMagnitude > 2.0f)
			{
				speedY *= 0.9f;
			}

			Vector3 velocity = targetDir.normalized * speed + Vector3.up * speedY;

			transform.position += velocity * Time.deltaTime;
		}
	
		protected override void ImpactParticles (Collision col)
		{
			Vector3 pos = col.contacts [0].point;
			Vector3 nor = col.contacts [0].normal;

			Quaternion rot = Quaternion.LookRotation (nor);

			GameObject clone = Instantiate (explosionPrefab, pos, rot);
			Destroy (clone, 2f);
		}
	}

}
