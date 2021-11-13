using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformBehaviour : MonoBehaviour
{
    [SerializeField] private PlatformDirection Direction;
    [SerializeField] private float Speed;
    [SerializeField] private float Distance;
    [SerializeField] private float DistanceOffset = 0.05f;
    [SerializeField] private bool isLooping = true;

    private Vector2 startingPosition;
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
        if(isLooping)
        {
            isMoving = true;
        }
    }

    private void MovePlatform()
    {
        float PingPongValue = (isMoving) ? Mathf.PingPong(Time.time * Speed, Distance) : Distance;

        if ((!isLooping) && (PingPongValue >= Distance - DistanceOffset))
        {
            isMoving = false;
        }

        switch (Direction)
        {
            case PlatformDirection.HORIZONTAL:
                transform.position = new Vector2(startingPosition.x + PingPongValue, transform.position.y);
                break;
            case PlatformDirection.VERTICAL:
                transform.position = new Vector2(transform.position.x, startingPosition.y + PingPongValue);
                break;
            case PlatformDirection.DIAGONAL_UPRIGHT:
                transform.position = new Vector2(startingPosition.x + PingPongValue, startingPosition.y + PingPongValue);
                break;
            case PlatformDirection.DIAGONAL_DOWNRIGHT:
                transform.position = new Vector2(startingPosition.x + PingPongValue, startingPosition.y - PingPongValue);
                break;
            case PlatformDirection.DIAGONAL_UPLEFT:
                transform.position = new Vector2(startingPosition.x - PingPongValue, startingPosition.y + PingPongValue);
                break;
            case PlatformDirection.DIAGONAL_DOWNLEFT:
                transform.position = new Vector2(startingPosition.x - PingPongValue, startingPosition.y - PingPongValue);
                break;

        }

    }
}
