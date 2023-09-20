using UnityEngine;

public class Hole : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ball.inHole = true;
        
        if(LevelBtn.currentLevel < LevelsContainer.TotalLevels)
        {
            ResultUI.Instant("win-ui");
            if (LevelBtn.currentLevel != LevelBtn.OpenedCount)
            {
                return;
            }

            LevelBtn.OpenedCount++;
        }
        else
        {
            ResultUI.Instant("home-ui");
        }
    }
}
