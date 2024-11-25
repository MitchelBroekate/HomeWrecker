using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Movement Variables
    [Header("Config Variables")]
    [SerializeField] float moveSpeed;

    //Used inside script
    Vector2 moveDirection;
    Rigidbody rb;
    #endregion

    #region Camera Variables
    [Header("Config Variables")]
    [SerializeField] float mouseSens;

    [Header("Linked Variables")]
    [SerializeField] Transform cam;
    float xRotation = 0f;
    #endregion 
    
    bool playerLock;

    /// <summary>
    /// This function gets the ridgedbody component and locks the Cursor for the FPS Mode
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    /// <summary>
    /// The Update function updates the walk and camera function for the player movement, also checks if the movement is locked
    /// </summary>
    private void Update()
    {
        if(!playerLock)
        {
            Walk();
            CameraMovement();
        }
    }  

    /// <summary>
    /// This function sets the velocity for any walking direction.
    /// </summary>
    void Walk()
    {
        Vector3 playerV = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.y * moveSpeed);
        rb.velocity = transform.TransformDirection(playerV);
    } 

    /// <summary>
    /// This function sets the movement vector2 in a vector2 variable.
    /// </summary>
    /// <param name="value"></param>
    void OnMovement(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }

    /// <summary>
    /// this function sets the movement for the camera and sets the clamp for the camera movement
    /// </summary>
    void CameraMovement()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

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
