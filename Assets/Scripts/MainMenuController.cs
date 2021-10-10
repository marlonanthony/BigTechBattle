using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        var clickedButtonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        int characterIndex = int.Parse(clickedButtonName);
        GameManager.instance.CharIndex = characterIndex;
        SceneManager.LoadScene("Gameplay");
    }
}
