using UnityEngine;
using UnityEngine.UI; 
using System.Collections;
public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce = 10;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public float gravityModifier;
    public bool isOnGround = true;

    public bool dashing = false;
    public float dashCD;

    public GameObject projectilePrefab;
    public GameObject shootingPoint;
    public float fireRate;
    public float ammo;
    public bool fireRateCD;
    public float dashSpeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        Physics.gravity *= gravityModifier;


        
    }

    // Update is called once per frame
    void Update()
    {
        

        
        float horizontalInput = Input.GetAxis("Horizontal");
        //transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        Vector3 horizontalVelocity = transform.right * speed * horizontalInput;

        float verticalInput = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        Vector3 verticalVelocity = transform.forward * speed * verticalInput;

        playerRb.linearVelocity = verticalVelocity + horizontalVelocity;

        float xTurnspeed = Input.GetAxis("Mouse X") * 1000;
        playerRb.transform.Rotate(Vector3.up, Time.deltaTime * xTurnspeed );

        float yTurnspeed = Input.GetAxis("Mouse Y") * 1000;
        focalPoint.transform.Rotate(Vector3.left, Time.deltaTime * yTurnspeed );
        
        if(Input.GetKeyDown(KeyCode.LeftShift) && !dashing){
            playerRb.linearVelocity = transform.forward * dashSpeed;
            dashing = true;
            StartCoroutine(DashCooldown());
            Debug.Log("dash");

        } 

        if(Input.GetKeyDown(KeyCode.Space)) {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
        
        if(Input.GetKey(KeyCode.Mouse0) && !fireRateCD){
           StartCoroutine(FireRate());
           Debug.Log("shoot");
        }

        Cursor.lockState = CursorLockMode.Locked;
        if(Input.GetKeyDown(KeyCode.Space)){
           Cursor.lockState = CursorLockMode.None; 
        }
        
    }

    void FixedUpdate() {
        
    }
    IEnumerator DashCooldown()
    {
        dashing = true;
        yield return new WaitForSeconds(dashCD);
        dashing = false;
    }

    IEnumerator FireRate()
    {
        fireRateCD = true;
        Instantiate(projectilePrefab, shootingPoint.transform.position, focalPoint.transform.rotation);
        yield return new WaitForSeconds(fireRate);
        fireRateCD = false;
        
    }

    IEnumerator Reload()
    {
        fireRateCD = true;
        Instantiate(projectilePrefab, shootingPoint.transform.position, focalPoint.transform.rotation);
        yield return new WaitForSeconds(fireRate);
        fireRateCD = false;
        
    }

    

    private void OnCollisionEnter(Collision collision) {
        //if(collision.gameObject.CompareTag("ground")) {
        //    isOnGround = true;
        //}
    }

}
