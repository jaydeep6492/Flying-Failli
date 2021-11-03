using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCanvasScript : MonoBehaviour
{
    
    #region Private Constatnt Variable

    private const int HardnessLevel = 50;
    
    #endregion
    
    #region Public Variables

    public GameObject gamePlayBackground;
    public GameObject gameCandidate;
    public GameObject panelMainMenu;
    public GameObject cameraObject;

    public Sprite volumeOff;
    public Sprite volumeOn;

    #endregion

    #region Public Static Variable;

    public static float SpanSpeed;

    public static bool IsLoadMainMenu =true;
    public static bool GameVolumeOn=true;

    #endregion

    #region Unity CallBack

    // Start is called before the first frame update
    void Start()
    {
        SpanSpeed = 2.2f;
        if (IsLoadMainMenu)
        {
            panelMainMenu.SetActive(IsLoadMainMenu);
            IsLoadMainMenu = false;
        }
        else
        {
            GamePlay();
        }
    }

    private void Update()
    {
        if (PlayerScript.PlayerScore % HardnessLevel == 0 && PlayerScript.PlayerScore > 1 && SpanSpeed>=1)
        {
            SpanSpeed -= 0.01f;
        }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// On Play Button Click Game Play Start
    /// </summary>
    public void GamePlay()
    {
        gamePlayBackground.SetActive(true);
        gameCandidate.SetActive(true);
        panelMainMenu.SetActive(false);
    }
    
    /// <summary>
    /// On Pause Button Click Game Play Stop & Active Main Menu Panel Of GameCanvas
    /// </summary>
    public void GamePause()
    {
        gamePlayBackground.SetActive(false);
        gameCandidate.SetActive(false);
        panelMainMenu.transform.GetChild(1).GetComponent<Text>().text = "Tap To Resume";
        panelMainMenu.transform.GetChild(4).gameObject.SetActive(true);  //Set Active Restart Button Of Main Menu Panel Only On Pause Button Click
        panelMainMenu.SetActive(true);
    }
    
    /// <summary>
    /// On Exit Button Click Exiting Game
    /// </summary>
    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
    
    /// <summary>
    /// On Main Menu Button Click Load Scene With MainMenuPanel
    /// </summary>
    public void MainMenu()
    {
        IsLoadMainMenu = true;
        PlayerScript.PlayerScore = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    /// <summary>
    /// On Click Restart Button Load Scene Without MainMenuPanel
    /// </summary>
    public void RestartGame()
    {
        PlayerScript.PlayerScore = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// On Volume Button Click Sound Will On & Off
    /// </summary>
    public void GameVolume(GameObject soundButton)
    {
        if (GameVolumeOn)
        {
            GameObject.Find("Audio").GetComponent<AudioSource>().mute = true;
            soundButton.GetComponent<Image>().sprite = volumeOff;
            GameVolumeOn = false;
        }
        else
        {
            GameObject.Find("Audio").GetComponent<AudioSource>().mute = false;
            soundButton.GetComponent<Image>().sprite = volumeOn;
            GameVolumeOn = true;
        }
    }

    public IEnumerator CameraShake()
    {
        Vector3 originalsPosition = cameraObject.transform.position;
        float shakeTime = 0.0f;
        float duration = 2f;
        while (shakeTime < duration)
        {
            cameraObject.transform.position = cameraObject.transform.position + new Vector3(Random.Range(-0.08f, 0.08f), Random.Range(-0.001f, 0.001f), 0);
            shakeTime += Time.deltaTime;
            yield return new WaitForSeconds(0.001f);
        }
        cameraObject.transform.position = originalsPosition;

    }

    #endregion
    
}