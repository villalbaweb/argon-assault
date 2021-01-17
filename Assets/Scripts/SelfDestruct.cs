using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float timeToDestroy = 3f;

    private void Awake() 
    {
        Destroy(gameObject, timeToDestroy);
    }
}
