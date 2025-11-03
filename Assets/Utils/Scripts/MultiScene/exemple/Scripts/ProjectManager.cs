using UnityEngine;

public class ProjectManager : MonoBehaviour
{
    void Start()
    {
        SceneController.Instance.NewTransition()
            .Load(SceneDatabase.Slots.MainMenu, SceneDatabase.Scenes.MainMenu)
            .Perform();
    }
}
