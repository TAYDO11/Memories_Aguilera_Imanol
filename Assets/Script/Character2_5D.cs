using UnityEngine;

public class Character2_5D : MonoBehaviour
{
    public float moveSpeed;
    Vector2 moveInput;

    public float jumpForce;
    [SerializeField] bool jumpInput;

    public Transform grdChecker;
    public LayerMask ground;
    public float rayLength;

    [SerializeField] bool grounded;
    [SerializeField] bool backTurned;

    public bool flipped;
    public float flipSpeed;

    Quaternion flipLeft = Quaternion.Euler(0, -180, 0);
    Quaternion flipRight = Quaternion.Euler(0, 0, 0);

    Rigidbody theRB;
    Animator theAnim;

    void Start()
    {
        theRB = GetComponent<Rigidbody>();
        theAnim = GetComponent<Animator>();
    }

    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        // Animation
        theAnim.SetFloat("MoveSpeed", theRB.linearVelocity.magnitude);

        // Flip left / right
        if (!flipped && moveInput.x < 0)
            flipped = true;
        else if (flipped && moveInput.x > 0)
            flipped = false;

        if (flipped)
            transform.rotation = Quaternion.Slerp(transform.rotation, flipLeft, flipSpeed * Time.deltaTime);
        else
            transform.rotation = Quaternion.Slerp(transform.rotation, flipRight, flipSpeed * Time.deltaTime);

        // Back / Front
        if (!backTurned && moveInput.y > 0)
            backTurned = true;
        else if (backTurned && moveInput.y < 0)
            backTurned = false;

        theAnim.SetBool("BackTurned", backTurned);

        // Jump input
        if (Input.GetKeyDown(KeyCode.Escape) && grounded)
            jumpInput = true;

        theAnim.SetBool("Grounded", grounded);
    }

    private void FixedUpdate()
    {
        // ✅ Déplacement correct Unity 6
        theRB.linearVelocity = new Vector3(
            moveInput.x * moveSpeed,
            theRB.linearVelocity.y,
            moveInput.y * moveSpeed
        );

        // Sol
        grounded = Physics.Raycast(
            grdChecker.position,
            Vector3.down,
            rayLength,
            ground
        );

        Debug.DrawRay(grdChecker.position, Vector3.down * rayLength, Color.red);

        if (jumpInput)
            Jump();
    }

    void Jump()
    {
        // ✅ on conserve X/Z sinon le perso se fige en saut
        theRB.linearVelocity = new Vector3(
            theRB.linearVelocity.x,
            jumpForce,
            theRB.linearVelocity.z
        );

        jumpInput = false;
    }
}