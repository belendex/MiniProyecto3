using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //SETTINGS ROTATION CAMERA
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    [Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
    public GameObject CinemachineCameraTarget;
    [SerializeField] private float mouseSensitivity;
    //SETTINGS MOVEMENT
    [SerializeField] private float speed = 4;
    [SerializeField] private float sprintSpeed = 6;
    private Vector2 moveInput;

    //SETTINGS JUMP
    private bool canJump;
    [SerializeField] private int jumpForce = 5;
    private Rigidbody rb;

    //SETTINGS FIRE
    public Transform firePoint; // Punto de disparo
    public GameObject bulletPrefab; // Prefab de la bala
    public int bulletSpeed = 50;
    public bool isReadyToFire = false;
    [SerializeField] private GameObject gunRoot;
    private float tiempoTranscurrido = 0f;


    private float currentLerpTime;
    public Animator animator;
    public bool isZoom= false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        RotateCamera();

    }

    private void Move()
    {
        Vector3 moveDirection = new Vector3(moveInput.x, 0f, moveInput.y).normalized;

        animator.SetBool("Walk", moveDirection != Vector3.zero);
        animator.SetFloat("EjeX", moveInput.x);
        animator.SetFloat("EjeY", moveInput.y);
        animator.SetBool("Jumping", !canJump);
        if (moveDirection != Vector3.zero)
        {
            if (UnityEngine.Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(moveDirection * sprintSpeed * Time.deltaTime);

            }
            else
            {
                transform.Translate(moveDirection * speed * Time.deltaTime);
            }
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && canJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
        }
    }

    private void RotateCamera()
    {
        yaw += speedH * UnityEngine.Input.GetAxis("Mouse X");
        pitch -= speedV * UnityEngine.Input.GetAxis("Mouse Y");

        pitch = Mathf.Clamp(pitch, -40f, 40f);

        if (isZoom==true)
        {
            transform.eulerAngles= new Vector3 (0f, yaw, 0f);

        }
        else
        {
            CinemachineCameraTarget.transform.eulerAngles = new Vector3 (0f,yaw, 0f);
        }
        CinemachineCameraTarget.transform.localRotation = Quaternion.Euler(pitch,0f , 0f);
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            canJump = true;
        }
    }

    
}