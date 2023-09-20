using UnityEngine;
using UnityEngine.UI;

public class CurrentLevelText : MonoBehaviour
{
    private void Start()
    {
        var text = GetComponent<Text>();
        text.text = $"LVL. {LevelBtn.currentLevel}";
    }
}
