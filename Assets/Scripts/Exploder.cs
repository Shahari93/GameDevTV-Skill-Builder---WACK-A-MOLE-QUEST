using UnityEngine;

public class Exploder : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Aww, you got me");
            Destroy(gameObject);
        }
    }
}