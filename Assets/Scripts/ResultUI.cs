using UnityEngine;

public class ResultUI : MonoBehaviour
{
    public static ResultUI Instance
    {
        get => FindObjectOfType<ResultUI>();
    }

    public static void Instant(string result)
    {
        var prefab = Resources.Load<GameObject>(result);
        Instantiate(prefab);
    }
}
