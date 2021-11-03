using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    #region Public Static Variable

    public static int PlayerScore;
    public static int HighScore;

    public static float TimeDelay;

    #endregion Public Static Variable

    #region Public Variable

    public float playerForce;

    public Text uiScoreText;

    public GameObject panelGameOver;
    public GameObject gamePlayBackground;
    public GameObject[] objectAbility;

    public Transform transformAbility;

    public GameCanvasScript gameCanvasScript;

    public AudioClip blastClip;
    public AudioClip coinPick;

    #endregion Public Variable

    #region Private Variable

    float m_Time;
    float m_AbilityTime;


    #endregion Private Property

    #region Unity CallBack

    // Start is called before the first frame update
    void Start()
    {
        HighScore = PlayerPrefs.GetInt("HighScore");
        m_Time = 0f;
        m_AbilityTime = 0f;
        TimeDelay = 1f;
        GetComponent<AudioSource>().enabled = !enabled;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.name == "LazerUpperHandle" ||
            collision.collider.gameObject.name == "LazerBottomHandle")
        {
            PlayerDead();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Score Coin") && GetComponent<SpriteRenderer>().enabled)
        {
            PlayerScore += 2;
            GetComponent<AudioSource>().clip = coinPick;
            GetComponent<AudioSource>().enabled = !enabled;
            GetComponent<AudioSource>().enabled = enabled;
            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        m_Time = m_Time + Time.deltaTime;
        m_AbilityTime += Time.deltaTime;
        if (m_Time >= TimeDelay)
        {
            m_Time = 0f;
            PlayerScore++;
            uiScoreText.text = "Score - " + PlayerScore;
        }
        if (m_AbilityTime >= TimeDelay * 10)
        {
            m_AbilityTime = 0f;
            CreateAbility();
        }

    }

    #endregion Unity CallBack

    #region Public Method

    /// <summary>
    /// Player Dead, Checking HighScore & Set Audio at Destroy
    /// </summary>
    public void PlayerDead()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = !enabled;
        GetComponent<AudioSource>().clip = blastClip;
        gameObject.GetComponent<AudioSource>().enabled = enabled;
        Destroy(transform.parent.gameObject, 1.2f);
        gamePlayBackground.SetActive(false);
        StartCoroutine(gameCanvasScript.CameraShake());
        if (PlayerScore > HighScore)
        {
            HighScore = PlayerScore;
            panelGameOver.GetComponentInChildren<Text>().color = Color.green;
            panelGameOver.GetComponentInChildren<Text>().text =
                "Hurray,You Created HighScore " + PlayerScript.HighScore;
        }
        else if (PlayerScore == HighScore)
        {
            panelGameOver.GetComponentInChildren<Text>().color = Color.white;
            panelGameOver.GetComponentInChildren<Text>().text = "You reached at HighScore " + PlayerScript.HighScore;
        }
        else
        {
            panelGameOver.GetComponentInChildren<Text>().color = Color.yellow;
            panelGameOver.GetComponentInChildren<Text>().text =
                "Better Luck Next Time,HighScore is " + HighScore;
        }

        PlayerPrefs.SetInt("HighScore", HighScore);
        panelGameOver.SetActive(true);
    }

    private void CreateAbility()
    {
        Instantiate(objectAbility[Random.Range(0, objectAbility.Length)], transformAbility, true);
    }

    /// <summary>
    /// OnClick Add Player Force
    /// </summary>
    public void UpwardForce()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerForce);
    }

    #endregion

}

