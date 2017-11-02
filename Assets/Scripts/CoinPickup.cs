using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    public int pointsToAdd;
    public GameObject CoinParticle;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() == null) return;

        Instantiate(CoinParticle, gameObject.transform.position, gameObject.transform.rotation);
        ScoreManager.AddPoints(pointsToAdd);
        Destroy(gameObject);
    }
}
