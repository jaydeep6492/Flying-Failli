using UnityEngine;

public class GamePlayBackground : MonoBehaviour
{
    #region Private Constants Variables
    
    private const float ChangePosition = -5.44f;

    #endregion

    #region Private Variables

    private Vector3 m_StartingPosition;

    #endregion

    #region Public Static Variable

    public static float BackgroundSpeed = 7f;

    #endregion

    #region Unity CallBack

    void Start()
    {
        m_StartingPosition = new Vector3(38.48f, 0, 0);
    }

    void Update()
    {
        var transform1 = transform;
        transform1.localPosition = transform1.localPosition - new Vector3(Time.deltaTime * BackgroundSpeed, 0, 0);
        if (transform.localPosition.x <= ChangePosition)
        {
            transform.localPosition = m_StartingPosition;
        }
    }

    #endregion

}
