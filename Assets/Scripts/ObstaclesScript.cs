using UnityEngine;

public class ObstaclesScript : MonoBehaviour
{
    
    #region Public Variable

    public float obstaclesSpeed;
    public Transform parentTransformGameCandidate;
   
    #endregion

    #region Unity CallBack
    // Start is called before the first frame update
    void Start()
    {
        PlayerScript.HighScore = PlayerPrefs.GetInt("HighScore");
        transform.localPosition = new Vector3(3,Random.Range(-1.25f, 2.5f),0);
        Invoke(nameof(CreateInstantiateObstacles),GameCanvasScript.SpanSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerScript objPlayerScript = collision.collider.GetComponent<PlayerScript>();
        if (objPlayerScript != null && objPlayerScript.transform.GetComponent<SpriteRenderer>().enabled == enabled)
        {
            objPlayerScript.PlayerDead();
        }
    }
    // Update is called once per frame
    void Update()
    {
        var obstacleTransform = transform;
        obstacleTransform.localPosition = obstacleTransform.localPosition - new Vector3(obstaclesSpeed*Time.deltaTime, 0, 0);
        if ( transform.localPosition.x <= -15f)
        {
            Destroy(gameObject);
            //Debug.Log("Destroy");
        }
    }

    #endregion

    #region Private Methods
    /// <summary>
    /// Creating Instantiate Of Obstacles
    /// </summary>
    void CreateInstantiateObstacles()
    {
        Instantiate(gameObject, parentTransformGameCandidate, true);
    }
    #endregion
    
}
