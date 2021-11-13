using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform PlayerSpawnpoint;

    void Start()
    {
        Player.position = PlayerSpawnpoint.position;
    }
}
