using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public GameObject currentCheckpoint;

    private PlayerController player;

	void Start () {
        player = FindObjectOfType<PlayerController>();
	}
	
	void Update () {
		
	}

    public void RespawnPlayer()
    {
        Debug.Log("Player Respawn");
        player.transform.position = currentCheckpoint.transform.position;
    }
}
