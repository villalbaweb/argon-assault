using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX = null;
    [SerializeField] Transform runtimeSpawnedParent = null;

    private void OnParticleCollision(GameObject other) 
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = runtimeSpawnedParent;
        
        Destroy(gameObject);    
    }
}
