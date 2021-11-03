using UnityEngine;

public class UmxCoinAbility : MonoBehaviour
{

    #region Public Variables

    public float abilitySpeed;
    
    #endregion
    #region Unity Callback
    // Start is called before the first frame update
    void Start()
    {
        abilitySpeed = 3f;
        transform.localPosition = new Vector3(Random.Range(20f,30f),Random.Range(-1.3f,2f),0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            GetComponent<SpriteRenderer>().enabled = !enabled;
            transform.GetChild(0).localPosition += new Vector3(60, 0, 0);
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition -= new Vector3(abilitySpeed*Time.deltaTime,0,0);
        if(transform.localPosition.x<=-22f)
            Destroy(gameObject);
    }

    #endregion
   
}
