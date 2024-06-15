using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public float waterGravityScale = 0.5f; // Giảm trọng lực trong nước
    public float waterJumpForce = 10f; // Lực nhảy khi trong nước

    private Rigidbody2D rb;
    private bool isUnderwater = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Kiểm tra xem nhân vật có trong nước không
        if (isUnderwater)
        {
            // Giảm trọng lực
            rb.gravityScale = waterGravityScale;

            // Kiểm tra nút nhảy và thực hiện nhảy lên khi trong nước
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, waterJumpForce);
            }
        }
        else
        {
            // Nếu không trong nước, khôi phục trọng lực mặc định
            rb.gravityScale = 1f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Xác định khi nhân vật đi vào nước
        if (other.CompareTag("Water"))
        {
            isUnderwater = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Xác định khi nhân vật rời khỏi nước
        if (other.CompareTag("Water"))
        {
            isUnderwater = false;
        }
    }
}
