using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float RunForce;
    [SerializeField] private Transform LookAheadPoint;
    [SerializeField] private Transform LookInFrontPoint;
    [SerializeField] private LayerMask GroundLayerMask;
    [SerializeField] private LayerMask WallLayerMask;
    [SerializeField] private bool isGroundAhead;
    [SerializeField] private bool isWallAhead;

    private Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        LookAhead();
        LookInFront();
        Move();
    }

    private void LookAhead()
    {
        var hit = Physics2D.Linecast(transform.position, LookAheadPoint.position, GroundLayerMask);
        isGroundAhead = (hit) ? true : false;
    }

    private void LookInFront()
    {
        var hit = Physics2D.Linecast(transform.position, LookInFrontPoint.position, WallLayerMask);
        if(hit)
        {
            Flip();
        }
    }

    private void Move()
    {
        if(isGroundAhead)
        {
            rigidbody.AddForce(Vector2.left * RunForce * transform.localScale.x);
            rigidbody.velocity *= 0.9f;
        }
        else
        {
            Flip();
        }
    }

    private void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
    }

    private void OnCollisionEnter2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(otherCollider.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(null);
        }
    }

    // UTILITIES

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, LookAheadPoint.position);
        Gizmos.DrawLine(transform.position, LookInFrontPoint.position);
    }

}
