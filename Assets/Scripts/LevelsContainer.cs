using UnityEngine;

public class LevelsContainer : MonoBehaviour
{
    public static int TotalLevels
    {
        get => PlayerPrefs.GetInt("totallevels", 0);
        set => PlayerPrefs.SetInt("totallevels", value);
    }

    private void Start()
    {
        var count = 0;

        foreach (Transform t in transform)
        {
            if (!t.GetComponent<LevelBtn>())
            {
                continue;
            }

            count++;
        }

        TotalLevels = count;
    }
}
