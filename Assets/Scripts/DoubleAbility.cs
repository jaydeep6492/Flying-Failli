using UnityEngine;
using UnityEngine.UI;

public class DoubleAbility : MonoBehaviour
{
    // Start is called before the first frame update

    #region Public Variable

    public float abilityTime;
    public float abilitySpeed;

    #endregion
    
    #region Private Variable
    
    private GameObject m_PlayerObject;
    
    private Button m_PanelGameControl;
    
    private float m_AddPosition;
    
    #endregion

    #region Unity CallBack

    private void Start()
    {
        abilityTime = 7f;
        abilitySpeed = 3f;
        transform.localPosition = new Vector3(Random.Range(10f,20f),2.61f,0);
        m_PlayerObject = GameObject.Find("Player");
        m_PanelGameControl = GameObject.Find("Panel - GameControl").GetComponent<Button>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" && m_PlayerObject.GetComponent<SpriteRenderer>().enabled)
        {
            GetComponent<SpriteRenderer>().enabled = !enabled;
            m_PlayerObject.GetComponent<PolygonCollider2D>().enabled = false;
            m_PlayerObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            m_PlayerObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            m_PlayerObject.transform.GetChild(1).gameObject.SetActive(true);
            GamePlayBackground.BackgroundSpeed *= 2;
            PlayerScript.TimeDelay /= 2;
            m_PanelGameControl.enabled = !enabled;
            Invoke(nameof(DisableDoubleAbility),abilityTime);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.y >= 2.5f)
        {
            m_AddPosition = -0.003f;
        }
        else if(transform.localPosition.y <= -1.36f)
        {
            m_AddPosition = 0.003f;
        }
        transform.localPosition += new Vector3(-(abilitySpeed*Time.deltaTime),m_AddPosition,0);
    }
    
    #endregion
    
    #region Public Methods

    /// <summary>
    /// Changing Double Ability To Normal Game PLay
    /// </summary>
    public void DisableDoubleAbility()
    {
        m_PanelGameControl.enabled = enabled;
        m_PlayerObject.transform.GetChild(1).gameObject.SetActive(false);
        m_PlayerObject.GetComponent<Rigidbody2D>().gravityScale = 0.4f;
        PlayerScript.TimeDelay *= 2;
        GamePlayBackground.BackgroundSpeed /= 2;
        m_PlayerObject.GetComponent<PolygonCollider2D>().enabled = true;
        Destroy(gameObject);
    }
    
    #endregion
}
