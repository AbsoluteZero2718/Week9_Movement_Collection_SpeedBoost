using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    public bool is_coin = true, is_speed = true;
    public int boost;

     void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement playerMove = other.GetComponent<PlayerMovement>();

            if (is_coin)
            {
                playerMove.score++;
                Destroy(gameObject);
            }

        }
    }


}
