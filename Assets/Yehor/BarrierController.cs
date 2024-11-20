using UnityEngine;

public class BarrierController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Carrot"))
        {
            Debug.Log("Carrot");
            // Temporarily switch to trigger to allow the object to pass through
            GetComponent<Collider>().isTrigger = true;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player");
            // Temporarily switch to trigger to allow the object to pass through
            GetComponent<Collider>().isTrigger = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Carrot"))
        {
            Debug.Log("2");
            // Temporarily switch to trigger to allow the object to pass through
            GetComponent<Collider>().isTrigger = true;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Palyer");
            // Temporarily switch to trigger to allow the object to pass through
            GetComponent<Collider>().isTrigger = false;
        }
    }

}
