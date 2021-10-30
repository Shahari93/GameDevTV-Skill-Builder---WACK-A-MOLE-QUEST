using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] ParticleSystem destroyEnemyParticles;
    [SerializeField] CameraShake cameraShake;
    [SerializeField] Timer timer;

    void Update()
    {
        MoveHero();
        destroyEnemyParticles.gameObject.SetActive(true);
    }

    private void MoveHero()
    {
        float xValue = moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        float yValue = moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.Translate(xValue, 0, yValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            destroyEnemyParticles.Play();
            StartCoroutine(cameraShake.ShakeCamera());
            StartCoroutine(timer.SlowDownTime());
        }
    }
}