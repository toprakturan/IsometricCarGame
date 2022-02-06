using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{

    Player player;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    //Collision check with gem - player
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.GemCounterMethod();
            Destroy(gameObject);
        }
    }

}
