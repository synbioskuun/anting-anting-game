using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlockMovement : MonoBehaviour
{
    [SerializeField] private GameObject waypoint;
    [SerializeField] private float speed = 2f;
    [SerializeField] private LayerMask terrainGround;
    private BoxCollider2D coll;
    private bool gravOn = false;
    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(waypoint.transform.position, transform.position) < .1f)
        {
            gravOn = false;
        }
        //every update, move upward to waypoint
        //when at waypoint, turn on gravity and prevent rising
        //once at ground, turn off gravity and move upward to waypoint
        if (Vector2.Distance(waypoint.transform.position, transform.position) > .1f && !IsGrounded())
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoint.transform.position, Time.deltaTime * speed);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, terrainGround);
    }
}
