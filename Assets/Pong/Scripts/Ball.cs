using UnityEngine;

public class Ball : MonoBehaviour
{
    public AudioSource paddleCollideSound;
    public AudioSource wallCollideSound;

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Paddle")
        {
            paddleCollideSound.Play();
        }

        if (collision.gameObject.tag == "Wall")
        {
            wallCollideSound.Play();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            PickUp pickUp = other.gameObject.GetComponent<PickUp>();
            pickUp.PowerUp();
        }

        if (other.gameObject.CompareTag("PickUp2"))
        {
            other.gameObject.SetActive(false);
            PickUp pickUp = other.gameObject.GetComponent<PickUp>();
            pickUp.PowerUp2();
        }
    }
}
