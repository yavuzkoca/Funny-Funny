using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStarController : MonoBehaviour {

	public float speed;
	public GameObject player;
    public GameObject enemyDeathEffect;
    public GameObject impactEffect;

    public int pointsForKill;
	
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		PlayerController playerController = player.GetComponent<PlayerController>();
		if (!playerController.moveRight){
            speed = -speed;
		}
	}
	
	
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
	}
	
	void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player" || other.tag == "CheckPoint" || other.tag == "Coin")
        {
            return;
        }

        if (other.tag == "Enemy")
        {
            Instantiate(enemyDeathEffect, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            ScoreManager.AddPoints(pointsForKill);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy (gameObject);
	}

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
