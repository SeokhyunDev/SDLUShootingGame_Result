using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Play();
        }
    }
    public void Play()
    {
        SceneManager.LoadScene("Play");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GoToMain()
    {
        SceneManager.LoadScene("GameStart");
    }
}
