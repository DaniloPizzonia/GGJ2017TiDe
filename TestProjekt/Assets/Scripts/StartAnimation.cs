using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour 
{
	// Particle System Prefab that gets spawn on space -> Destroy later!
	public GameObject particleSystemGO;

	// need to check if particlesystem is alive
	ParticleSystem shootParticleSystem;

	// transform for the particleSystemGO;
	public Transform shootPivot;

	public GameObject animationGO;
	Animator animator;

	GameObject clone;

	bool isParticleOn = false;

	float timer;
	float particleEnd = 3;


	void Start()
	{
		animator = animationGO.GetComponent<Animator> ();
		shootParticleSystem = particleSystemGO.GetComponent<ParticleSystem> ();

		timer = 0;
	}
		
	void Update()
	{

		if (isParticleOn)
		{
			timer += Time.deltaTime;

			if (timer < 3)
			{
				isParticleOn = false;
				timer = 0;
			}
		}

/*		if (Input.GetKeyDown(KeyCode.Space))
		{
			TriggerAnimation ();
		}	*/
	}

	public void TriggerAnimation()
	{
		
		animator.SetTrigger ("Shoot");

		if (!isParticleOn) {
			clone = (GameObject)Instantiate (particleSystemGO, shootPivot.position, shootPivot.rotation);
			clone.transform.SetParent (shootPivot);
			Destroy (clone, 4.0f);

			isParticleOn = true;
		}
	}
}
