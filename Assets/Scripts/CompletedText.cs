using UnityEngine;
using UnityEngine.UI;

public class CompletedText : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Text>().text = $"LEVEL {LevelBtn.currentLevel} COMPLETE!";
    }
}
