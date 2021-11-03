using UnityEngine;

public class MissileObstaclesScript : MonoBehaviour
{
    #region Public Variables

    public float missileSpeed;
    
    public Transform parentTransformGameCandidate;

    #endregion

    #region Unity CallBack

    // Start is called before the first frame update
    void Start()
    {
        transform.parent.localPosition = new Vector3((Screen.width/984f),Random.Range(-1.25f, 2.5f),0);
        transform.localPosition = new Vector3(Random.Range(150f, 200f),0,0);
        gameObject.transform.parent.GetComponent<SpriteRenderer>().enabled = enabled;
        Invoke(nameof(CreateInstantiateMissileObstacles),GameCanvasScript.SpanSpeed);
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
        var transform1 = transform;
        if (transform.localPosition.x < -130)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
        if ((int)Mathf.Round(transform.localPosition.x)== 0)
        {
            gameObject.transform.parent.GetComponent<SpriteRenderer>().enabled = !enabled;
        }
        transform1.localPosition = transform1.localPosition - new Vector3(missileSpeed*Time.deltaTime, 0, 0);
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Creating Instantiate Of Missile
    /// </summary>
    void CreateInstantiateMissileObstacles()
    {
       Instantiate(gameObject.transform.parent.gameObject, parentTransformGameCandidate, true);
    }

    #endregion
    
}
