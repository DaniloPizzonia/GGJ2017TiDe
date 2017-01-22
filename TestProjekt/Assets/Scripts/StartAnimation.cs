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


	void Start()
	{
		animator = animationGO.GetComponent<Animator> ();
		shootParticleSystem = particleSystemGO.GetComponent<ParticleSystem> ();
	}
		

	public void TriggerAnimation()
	{
		animator.SetTrigger ("Shoot");

		clone = (GameObject)Instantiate (particleSystemGO, shootPivot);
		Destroy (clone,1.0f);
	}
}
