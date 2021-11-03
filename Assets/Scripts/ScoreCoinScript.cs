using UnityEngine;

public class ScoreCoinScript : MonoBehaviour
{
    
    #region Unity CallBack

    // Start is called before the first frame update
    void Start()
    {
       RandomPosition();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            RandomPosition();
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        var transform1 = transform;
        transform1.localPosition = transform1.localPosition - new Vector3(Time.deltaTime*4, 0, 0);
        if (transform.localPosition.x < -7.7f)
        {
          RandomPosition();
        }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Creating Instantiate Of Score Coin
    /// </summary>
    private void RandomPosition()
    {
        transform.localPosition = new Vector3(Random.Range(50f, 70f),Random.Range(-1.25f, 2.5f),0);
    }

    #endregion
    
}
