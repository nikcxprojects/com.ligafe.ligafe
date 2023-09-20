using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenSceneBtn : MonoBehaviour
{
    [SerializeField] string sceneName;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            Instantiate(Resources.Load<GameObject>("hide"));
            Invoke(nameof(LoadScene), 1.0f);
        });
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
