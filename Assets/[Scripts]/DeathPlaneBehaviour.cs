using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlaneBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform PlayerSpawnpoint;

    private void OnCollisionEnter2D(Collision2D otherCollider)
    {
        if(otherCollider.gameObject.CompareTag("Player"))
        {
            otherCollider.transform.position = PlayerSpawnpoint.position;
        }
        else
        {
            otherCollider.gameObject.SetActive(false);
        }
    }
}
