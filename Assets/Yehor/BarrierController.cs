using UnityEngine;

public class BarrierController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Deer"))
        {
            Debug.Log("Deer detected, disabling barrier.");
            gameObject.SetActive(false);  // Disable the barrier object
        }

        if (other.gameObject.CompareTag("Carrot"))
        {
            Debug.Log("Carrot");
            GetComponent<Collider>().isTrigger = true;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player");
            GetComponent<Collider>().isTrigger = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Deer"))
        {
            Debug.Log("Deer detected, disabling barrier.");
            gameObject.SetActive(false);  // Disable the barrier object
        }

        if (collision.gameObject.CompareTag("Carrot"))
        {
            Debug.Log("2");
            GetComponent<Collider>().isTrigger = true;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Palyer");
            GetComponent<Collider>().isTrigger = false;
        }

    }

}
