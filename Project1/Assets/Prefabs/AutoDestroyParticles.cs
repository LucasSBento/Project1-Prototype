using UnityEngine;

public class AutoDestroyParticles : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2f);
    }
}
