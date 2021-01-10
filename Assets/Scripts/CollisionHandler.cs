using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        print($"{gameObject.name} trigger into {other.gameObject.name}");
    }
}
