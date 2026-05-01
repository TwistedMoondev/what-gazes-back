using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private float xSense = 1;
    [SerializeField] private float ySense = 1;

    private float xRotation;
    private float yRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visable = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * xSense;
        float mouseY = Input.GetAxis("Mouse Y") * ySense;
        
        yRotation += mouseX;
        xRotation -= mouseY;
        mouseX = Mathf.Clamp(xRotation, -90, 90);
    }

    void LateUpdate() {
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }

    //public transform cameraTransform;
    public float mouseSense = 4f;
    public float maxLookAngle = 85f;
    public float rotationX;
    void Look() {
        float mouseX = Input.GetAxis("Mouse X") * mouseSense;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSense;

        transform.Rotate(0, mouseX, 0);

        rotationX -= mouseY;

        rotationX = Mathf.Clamp(rotationX, -maxLookAngle, maxLookAngle);
        transform.localRotation = Quaternion.Euler(rotationX, mouseY, 0f);
    }
}

