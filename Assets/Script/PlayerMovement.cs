using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody theRB;
    public float moveSpeed, jumpForce;

    private Vector2 moveInput;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();

        theRB.linearVelocity = new Vector3(moveInput.x *  moveSpeed, theRB.linearVelocity.y, moveInput.y * moveSpeed);
    }
}
