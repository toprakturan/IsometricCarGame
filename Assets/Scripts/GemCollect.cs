using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollect : MonoBehaviour
{

    Player player;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    //Check collision between player and gem. And then gem will be destroy.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GemCollider"))
        {
            player.GemCounterMethod();
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
