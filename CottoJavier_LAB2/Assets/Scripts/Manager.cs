using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject prefab;
    private GameObject newObj;

    public GameObject pauseMenu;
    private bool isPaused = true;



    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;

        if (prefab)
            newObj = Instantiate(prefab, new Vector3(0, 3, 0), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();

        if(Input.GetKeyDown(KeyCode.Return) && !newObj)
            newObj = Instantiate(prefab, new Vector3(0, 3, 0), Quaternion.identity);

    }

    public void TogglePause() 
    {

        if (pauseMenu)
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 1.0f : 0.0f;
        }
    
    }

    public void MenuInicio() {

        SceneManager.LoadScene("MainMenu");

    }

    public void IniciarJuego() {

        SceneManager.LoadScene("SampleScene");
    }

    public void RestartScene() 
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

}
