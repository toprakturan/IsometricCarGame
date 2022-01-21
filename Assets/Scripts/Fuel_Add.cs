using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel_Add : MonoBehaviour
{
    Player player;
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Add amount of fuel
            player.AddFuel(100f);
            Destroy(gameObject);
        }
    }


}
