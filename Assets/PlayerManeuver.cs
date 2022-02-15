using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerManeuver : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 3;
    private Vector2 movement;
    public Animator animator;
    private SpriteRenderer spriteRenderer;
    public bool isMobile;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if(isMobile == true){
            movement = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), 0);
        }else{
            movement = new Vector2(Input.GetAxis("Horizontal"), 0);
        }
        animator.SetFloat("Speed", Mathf.Abs(movement.x));
        if (movement.x < -0.01){
            spriteRenderer.flipX = true;
        }
        if (movement.x > 0.01){
            spriteRenderer.flipX = false;
        }
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);
    }

    private void moveCharacter(Vector2 direction)
    {

        // rb.MovePosition((Vector2)transform.position + (direction * speed * Time.fixedDeltaTime));
        // rb.AddForce(direction * speed);
        // rb.velocity = direction * speed;
    }
}
