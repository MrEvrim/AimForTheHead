using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Lumin;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float fastMoveSpeedMultiplier = 2f; // Hızlı koşma hızı çarpanı
    public CharacterController characterController;
    public Animator animator;

    public Texture2D cursorTexture; // Yeni fare imgesi
    public CursorMode cursorMode = CursorMode.Auto; // Fare imgesi modu
    public Vector2 hotSpot = Vector2.zero;

    public float jumpHeight = 2f;
    public float timeToJumpApex = 0.4f;
    float gravity;
    Vector3 velocity;
    bool isJumping = false; // Zıplama durumu
    bool isSprinting = false; // Hızlı koşma durumu

    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
    }

    void Update()
    {
        Move();
        Look();
        if (characterController.isGrounded) // Karakter yerdeyse
        {
            velocity.y = 0;
            isJumping = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping) // Eğer Space tuşuna basıldıysa ve karakter zıplamıyorsa
        {
            Jump();
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Animations();
    }

    void Move()
    {
        float currentMoveSpeed = moveSpeed; // Başlangıçta normal koşma hızı

        if (Input.GetKey(KeyCode.LeftShift)) // Sol shift tuşuna basılırsa
        {
            isSprinting = true; // Hızlı koşma durumunu aktifleştir
            currentMoveSpeed *= fastMoveSpeedMultiplier; // Hızlı koşma hızını uygula
        }
        else
        {
            isSprinting = false; // Hızlı koşma durumunu devre dışı bırak
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(x, 0, z).normalized; // Global yön vektörü oluştur
        dir *= currentMoveSpeed * Time.deltaTime;
        characterController.Move(dir);
    }

    void Animations()
    {
        // Yürüme animasyonunu ayarla
        bool isWalking = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
        animator.SetBool("IsWalking", isWalking);

    }

    void Look()
    {
        // Fare pozisyonunu al
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        // Kameradan fareye doğru bir ışın gönder ve bu ışının düzleme olan kesişim noktasını bul
        if (groundPlane.Raycast(cameraRay, out float rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            // Karakterin yalnızca yatay düzlemde dönmesini sağlamak için yönü sıfırla
            pointToLook.y = transform.position.y;
            // Karakteri fare pozisyonuna doğru çevir
            transform.LookAt(pointToLook);
        }
    }

    void Jump()
    {
        isJumping = true; // Zıplama durumunu aktif hale getir

        float jumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * jumpHeight); // Zıplama hızını hesapla
        velocity.y = jumpVelocity; // Y ekseninde zıplama hızı
    }
}