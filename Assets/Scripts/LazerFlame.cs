using UnityEngine;

public class LazerFlame : MonoBehaviour
{
    #region Public Variables
    
    public PlayerScript playerScript;
    public float lazerSpeed;

    #endregion

    #region Unity CallBack

    private void Start()
    {
        transform.parent.localPosition = new Vector3(40,Random.Range(-1.25f, 1.25f),0);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            playerScript.PlayerDead();
        }
    }
    void Update()
    {
        transform.parent.localPosition -= new Vector3(lazerSpeed*Time.deltaTime,0,0);
        if(transform.parent.localPosition.x <=-8f)
            transform.parent.localPosition = new Vector3(20,Random.Range(-1.25f, 2f),0);
    }

    #endregion
    
}
