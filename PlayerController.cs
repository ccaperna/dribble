using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject focalPoint;
    public GameObject puIndicator;
    public float speed = 5;
    public bool haspu = false;
    private float puStrength = 12;
    private Vector3 offset = new Vector3(0, -0.5f, 0); //pU offset

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float zIn = Input.GetAxis("Vertical");
        rb.AddForce(focalPoint.transform.forward * zIn * speed);
        puIndicator.gameObject.transform.position = transform.position + offset;
    }

    IEnumerator powerUpCountdown()
    {
        yield return new WaitForSeconds(5);
        haspu = false;
        puIndicator.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            haspu = true;
            puIndicator.gameObject.SetActive(true);
            StartCoroutine(powerUpCountdown());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && haspu == true)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPl = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(awayFromPl * puStrength, ForceMode.Impulse);
            Debug.Log("Collided with " + collision.gameObject.name + " and powerup set to " + haspu);
        }
    }
}
