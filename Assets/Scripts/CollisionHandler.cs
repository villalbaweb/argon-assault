using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    // config
    [SerializeField] float loadDelay = 1f;

    // cache
    PlayerController _playerController;

    private void Awake() 
    {
        _playerController = GetComponent<PlayerController>();
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
        _playerController.SetIsAlive(false);
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
