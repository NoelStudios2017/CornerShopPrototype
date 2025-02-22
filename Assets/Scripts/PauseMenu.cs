using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    private void Start()
    {
        pauseMenu.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
           pauseMenu.SetActive(!pauseMenu.activeSelf);
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
    
}
