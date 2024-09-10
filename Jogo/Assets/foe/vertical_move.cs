using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vertical_move : MonoBehaviour
{
    public float playerVelocity;
    private Rigidbody2D foeBody;
    private PlayerDirection playerDirection;
    private bool onlyOneCollision;
    
    // Start is called before the first frame update
    void Start()
    {
        foeBody = GetComponent<Rigidbody2D>();
        playerDirection = PlayerDirection.Right;
        this.GoToTheRight(playerVelocity);
        onlyOneCollision = true;
    }
    
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            onlyOneCollision = !onlyOneCollision;
            if (playerDirection == PlayerDirection.Right)
            {
                playerDirection = this.GoToTheLeft(playerVelocity);
            }
            else if (playerDirection == PlayerDirection.Left)
            {
                playerDirection = this.GoToTheRight(playerVelocity);
            }
        }
       
    }

    PlayerDirection GoToTheLeft(float velocity)
    {
        foeBody.AddForce(Vector2.zero);
        foeBody.AddForce(new Vector2(0,velocity));
        return PlayerDirection.Left;
    }

    PlayerDirection GoToTheRight(float velocity)
    {
        foeBody.AddForce(Vector2.zero);
        foeBody.AddForce(new Vector2(0,-velocity));
        return PlayerDirection.Right;
    }

    private enum PlayerDirection
    {
        Left,
        Right
    }

}
