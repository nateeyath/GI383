using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementController2D : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D rb2d;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private float jumpVelocity;

    [SerializeField]
    private Vector3 footOffset;

    [SerializeField]
    private float footRadius;

    [SerializeField]
    private LayerMask groundLayerMask;


    private bool isOnGround;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal") * moveSpeed;
        rb2d.linearVelocity = new Vector2(moveHorizontal, rb2d.linearVelocity.y);
        Debug.Log(moveHorizontal);

        if (moveHorizontal != 0)
        {
            spriteRenderer.flipX = moveHorizontal < 0;
        }

        if (isOnGround && Input.GetButtonDown("Jump"))
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpVelocity);
        }
    }

    private void FixedUpdate()
    {
        Collider2D hitCollider = Physics2D.OverlapCircle(transform.position + footOffset, footRadius, groundLayerMask);
        isOnGround = hitCollider != null;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + footOffset, footRadius);
    }
}