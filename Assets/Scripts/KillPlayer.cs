using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    public LevelManager levelManager;
    public LevelManager2 levelManager2;

    void Start () {
        levelManager = FindObjectOfType<LevelManager>();
	}
	
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player"){
            levelManager.RespawnPlayer();
        }
        if (other.name == "Player2"){
            levelManager2.RespawnPlayer();    
        }
    }
}
