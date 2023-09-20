using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    private void Start()
    {
        Instantiate(Resources.Load<GameObject>($"levels/{LevelBtn.currentLevel}"));
    }
}
