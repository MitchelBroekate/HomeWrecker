using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Variables
    [Header("Config Movement Variables")]
    [SerializeField] float moveSpeed;
    [SerializeField] float sprintSpeed;
    [SerializeField] float jumpHeight;
    [SerializeField] float jumpDetection;

    [Header("Config Camera Variables")]
    [SerializeField] float mouseDPI;

    [Header("Linked Camera Variables")]
    [SerializeField] Transform cam;

    //Used inside script
    RaycastHit _hit;
    float xRotation = 0f;
    Vector2 _moveDirection;

    Rigidbody _rb;

    bool _isSprinting;
    bool _isJumping;
   
    bool playerLock;
    #endregion 
    

    /// <summary>
    /// This function gets the ridgedbody component and locks the Cursor for the FPS Mode
    /// </summary>
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;

        sprintSpeed = 1f;
    }

    /// <summary>
    /// The Update function updates the walk and camera function for the player movement, also checks if the movement is locked
    /// </summary>
    private void Update()
    {
        if(!playerLock)
        {
            Walk();
            Sprint();
            CameraMovement();
            Jumping();
            
        }
    }  

    /// <summary>
    /// This function sets the velocity for any walking direction.
    /// </summary>
    void Walk()
    {
        Vector3 playerV = new Vector3(_moveDirection.x * moveSpeed * sprintSpeed, _rb.velocity.y, _moveDirection.y * moveSpeed * sprintSpeed);
        _rb.velocity = transform.TransformDirection(playerV);
    } 

    /// <summary>
    /// This function sets the movement vector2 in a vector2 variable.
    /// </summary>
    /// <param name="value"></param>
    void OnMovement(InputValue value)
    {
        _moveDirection = value.Get<Vector2>();
    }

    void Sprint()
    {
        if(_isSprinting)
        {
            sprintSpeed = 1.5f;
        }
        else
        {
            sprintSpeed = 1f;
        }
    }

    void OnSprint(InputValue value)
    {
        _isSprinting = value.isPressed;
    }

    void Jumping()
    {
        if(Physics.Raycast(transform.position, -transform.up, out _hit, jumpDetection))
        {
            _isJumping = false;
        }
        else
        {
            _isJumping = true;
        }

    }

    void OnJump(InputValue value)
    {
        if(value.isPressed)
        {
            if(_isJumping) return;

            _rb.AddForce(transform.up * jumpHeight);
        }
    }

    /// <summary>
    /// this function sets the movement for the camera and sets the clamp for the camera movement
    /// </summary>
    void CameraMovement()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseDPI * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseDPI * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);

    }

    /// <summary>
    /// This Function sets the state of the playerLock bool
    /// </summary>
    /// <param name="allowState"></param>
    public void AllowMovement(bool allowState)
    {
        playerLock = allowState;
    }
}