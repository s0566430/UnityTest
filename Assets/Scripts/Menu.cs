using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) {
            if (!menu.activeSelf) {
                Time.timeScale = 0;
                menu.SetActive(true);                
            }
            else ReturnToGame();
        }
    }

    public void ReturnToGame() {
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ReturnToGame();
    }
}
