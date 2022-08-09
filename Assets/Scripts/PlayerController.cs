using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator playerAnimator;

    public float moveSpeed = 1f;
    public float jumpSpeed = 1f;
    public float jumpFrequency = 1f;
    public float nextJumpTime;

    bool facingRight = true;
    public bool isGrounded = false;

    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;

    private void Awake()
    {
        //print("AWAKE metodu çalýþtý");
    }

    void Start()
    {
        //print("START metodu çalýþtý");

        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent < Animator>();
    }


    void Update()
    {
        HorizontalMove();
        OnGroundCheck();

        //YÜZÜNÜ ÇEVÝRME BURADA ÇAÐIRILIYOR
        if (playerRB.velocity.x < 0 && facingRight)
        {
            FlipFace();
        }
        else if (playerRB.velocity.x > 0 && !facingRight)
        {
            FlipFace();
        }

        //ZIPLAMA BURADA KONTROL EDÝYORUZ
        if (Input.GetAxis("Vertical") > 0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            Jump();
        }

        //MOUSE ÝLE HAREKET BURADA ÇAÐIRILIYOR
        /*if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x > Screen.width / 2)
            {
                //karakteri saða yürüt
                HorizontalMoveMouse();
            }
            else
            {
                //karakteri sola yürüt
                HorizontalMoveMouse();
            }
        }*/
    }

    private void FixedUpdate()
    {
        
    }

    //YATAY HAREKET
    void HorizontalMove()
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed,playerRB.velocity.y);
        playerAnimator.SetFloat("playerSpeed", Mathf.Abs(playerRB.velocity.x));
    }

    //MOUSE ÝLE X EKSENÝNDE HAREKET
    /*void HorizontalMoveMouse()
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Mouse X") * moveSpeed, playerRB.velocity.y);
        playerAnimator.SetFloat("playerSpeed", Mathf.Abs(playerRB.velocity.x));
    }*/

    //YÜZÜNÜ ÇEVÝR
    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }

    //ZIPLAMA
    void Jump()
    {
        playerRB.AddForce(new Vector2(0f,jumpSpeed));
    }

    //ZEMÝN KONTROL ETME
    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, 
                                             groundCheckRadius, groundCheckLayer);
        playerAnimator.SetBool("isGroundedAnim", isGrounded);
    }
}
