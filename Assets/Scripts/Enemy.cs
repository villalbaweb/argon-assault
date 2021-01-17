using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX = null;
    [SerializeField] GameObject hitVFX = null;
    [SerializeField] Transform runtimeSpawnedParent = null;
    [SerializeField] int scorePoints = 5;
    [SerializeField] int hitPoints = 2;

    ScoreBoard _scoreBoard;

    private void Awake() 
    {
        _scoreBoard = FindObjectOfType<ScoreBoard>();    
    }

    private void OnParticleCollision(GameObject other) 
    {
        ProcessHit();

        if(hitPoints < 1)
        {
            ProcessEnemyKill();
        }
    }

    private void ProcessHit()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = runtimeSpawnedParent;

        hitPoints--;
        _scoreBoard?.IncreaseScore(scorePoints);
    }

    private void ProcessEnemyKill()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = runtimeSpawnedParent;

        Destroy(gameObject);
    }
}
