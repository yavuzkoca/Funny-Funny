using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFinishedParticle : MonoBehaviour {

    private ParticleSystem thisParticleSystem;

	void Start () {
        thisParticleSystem = GetComponent<ParticleSystem>();
	}
	
	void Update () {
        if (thisParticleSystem.isPlaying)
            return;
        Destroy(gameObject);
	}
}
