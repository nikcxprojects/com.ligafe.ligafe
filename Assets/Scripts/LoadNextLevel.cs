using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadNextLevel : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            LevelBtn.currentLevel++;
            Instantiate(Resources.Load<GameObject>("hide"));
            Invoke(nameof(LoadScene), 1.0f);
        });
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("game");
    }
}
