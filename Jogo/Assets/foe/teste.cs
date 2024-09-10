using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teste : MonoBehaviour
{
    public float playerVelocity;
    private Rigidbody2D foeBody;
    private PlayerDirection playerDirection;
    
    
    // Start is called before the first frame update
    void Start()
    {
        foeBody = GetComponent<Rigidbody2D>();
        playerDirection = PlayerDirection.Right;
        this.GoToTheRight(playerVelocity);
        
    }
    
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
           
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
        foeBody.AddForce(new Vector2(-velocity, 0));
        return PlayerDirection.Left;
    }

    PlayerDirection GoToTheRight(float velocity)
    {
        foeBody.AddForce(Vector2.zero);
        foeBody.AddForce(new Vector2(velocity, 0));
        return PlayerDirection.Right;
    }

    private enum PlayerDirection
    {
        Left,
        Right
    }

}
