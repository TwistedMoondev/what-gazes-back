using UnityEngine;
using UnityEngine.UI; 
using System.Collections;
public class ProjectileScript : MonoBehaviour
{
    public float speed;
    public float duration = 1;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ProjectileDuration(duration));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        
        
    }

    IEnumerator ProjectileDuration(float projectileLifeTime)
    {
        
        yield return new WaitForSeconds(projectileLifeTime);
        Destroy(gameObject);
        
    }
/*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("OoB"))
        {
            Destroy(other.gameObject);
        }
    }
    */
}
