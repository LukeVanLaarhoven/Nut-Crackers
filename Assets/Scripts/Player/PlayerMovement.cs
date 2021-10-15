using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D boxCollider;

    public float speed;
    public float jumpForce;
    public float jumpButtonReleaseDamping;
    public float extraHeight;
    public float hangTime;
    private float hangCounter;
    private float h;

    private bool isAimingDiagonally;

    [SerializeField]
    private LayerMask platformLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        #region groundCheck
        //check for grounded and add some hangtime to still jump if not on platform annymore
        if (IsGrounded())
        {
            hangCounter = hangTime;
        }
        else
        {
            hangCounter -= Time.deltaTime;
        }
        #endregion

        #region jumping
        //jumping
        if (Input.GetButtonDown("Jump") && hangCounter > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpButtonReleaseDamping);
        }
        #endregion

        #region flipping
        //flipping the transform to face the correct side to shoot
        if (GetHorizontalAxis() >= 0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (GetHorizontalAxis() <= -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        #endregion

        #region Shoot
        // shooting the weapon
        if (Input.GetAxis("Fire1") >= 0.001f)
        {
            Shoot();
        }
        #endregion

        #region aiming
        // aming up
        if (GetVerticalAxis() >= 0.01f && !isAimingDiagonally)
        {
            AimUp();
        }

        if (GetVerticalAxis() >= 0.01f && GetHorizontalAxis() >= 0.01f)
        {
            isAimingDiagonally = true;
            AimDiagonallyRight();
        }
        else
        {
            isAimingDiagonally = false;
        }

        if (GetVerticalAxis() >= 0.01f && GetHorizontalAxis() <= -0.01f)
        {
            isAimingDiagonally = true;
            AimDiagonallyLeft();
        }
        else
        {
            isAimingDiagonally = false;
        }

        if (GetVerticalAxis() <= -0.01f)
        {
            Duck();
        }

        #endregion
    }

    private void FixedUpdate()
    {
        //moving
        transform.Translate(h, 0, 0);
    }

    private bool IsGrounded()
    {
        Vector2 size = new Vector2(boxCollider.bounds.size.x - 0.1f, boxCollider.bounds.size.y);
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, size, 0f, Vector2.down, extraHeight, platformLayerMask);

        Color raycolor;
        if (raycastHit.collider != null)
        {
            raycolor = Color.green;
        }
        else
        {
            raycolor = Color.red;
        }

        Debug.DrawRay(boxCollider.bounds.center, Vector2.down * (boxCollider.bounds.extents.y + extraHeight), raycolor);

        return raycastHit.collider != null;
    }

    public void AimUp()
    {
        print("Aiming up");
    }

    public void AimDiagonallyRight()
    {
        print("Aiming diagonally Rightways");
    }

    public void AimDiagonallyLeft()
    {
        print("Aiming diagonally Leftways");
    }

    public void Duck()
    {
        print("Duck");
    }

    void Shoot()
    {

    }

    private float GetHorizontalAxis()
    {
        return Input.GetAxis("Horizontal");
    }

    private float GetVerticalAxis()
    {
        return Input.GetAxis("Vertical");
    }
}
