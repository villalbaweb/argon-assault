using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX = null;
    [SerializeField] Transform runtimeSpawnedParent = null;
    [SerializeField] int scorePoints = 5;

    ScoreBoard _scoreBoard;

    private void Awake() 
    {
        _scoreBoard = FindObjectOfType<ScoreBoard>();    
    }

    private void OnParticleCollision(GameObject other) 
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = runtimeSpawnedParent;

        _scoreBoard?.IncreaseScore(scorePoints);

        Destroy(gameObject);    
    }
}
