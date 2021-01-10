using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    // config
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem explosionParticleSystem = null;

    // cache
    PlayerController _playerController;
    MeshRenderer _meshRenderer;
    BoxCollider _boxCollider;

    private void Awake() 
    {
        _playerController = GetComponent<PlayerController>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        StartCrashSequence();
    }

    private void StartCrashSequence()
    {
        StartCoroutine(DieCoroutine());
    }

    IEnumerator DieCoroutine()
    {
        DisableComponentOnCrash();
        explosionParticleSystem.Play();
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void DisableComponentOnCrash()
    {
        _boxCollider.enabled = false;
        _meshRenderer.enabled = false;
        _playerController.enabled = false;
    }
}
