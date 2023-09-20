using UnityEngine;

public class SceneSetup : MonoBehaviour
{
    private void Start()
    {
        Instantiate(Resources.Load<GameObject>("unhide"));
    }
}
