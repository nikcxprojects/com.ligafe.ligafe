using UnityEngine;

public class DestroyIt : MonoBehaviour
{
    private void Start()
    {
        var destroyTime = gameObject.name.StartsWith("un") ? 0.8f : 1.3f;
        Destroy(gameObject, destroyTime);
    }
}
