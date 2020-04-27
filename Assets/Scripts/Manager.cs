using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Manager : MonoBehaviour
{
    public AudioManager audioManager;

    private GameObject scoreText;
    private GameObject reticle;
    private Image reticleImage;
    private Text score;
    private int cont = 0;
    public GameObject pauseMenu;
    private bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        scoreText = GameObject.FindWithTag("Text");
        reticle = GameObject.FindWithTag("Reticle");

        score = scoreText.GetComponent<Text>();
        reticleImage = reticle.GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (audioManager)
            {
                audioManager.PlayShootSFX();
            }

            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;

            if (Physics.Raycast(myRay, out hitinfo))
            {
                if (hitinfo.collider.CompareTag("Target"))
                {
                    if (score)
                    {
                        cont++;
                        score.text = "Score: " + cont.ToString();
                        Destroy(hitinfo.collider.gameObject);
                        if (audioManager && cont!= 8)
                        {
                            audioManager.PlayTargetSFX();
                        } else
                        {
                            audioManager.PlayCompleteSFX();
                        }
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (audioManager)
            {
                audioManager.PlayJumpSFX();
            }
        }
    }

    public void TogglePause()
    {

        if (audioManager && isPaused)
        {
            audioManager.PlayPauseOnSFX();
        }
        else
        {
            audioManager.PlayPauseOffSFX();
        }

        if (pauseMenu)
        {
            reticleImage.enabled = isPaused;
            isPaused = !isPaused;
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            Time.timeScale = isPaused ? 0.0f : 1.0f;
        }

    }

    public void ChangeScene(int _sceneIndex)
    {
        SceneManager.LoadScene(_sceneIndex);
    }
}
