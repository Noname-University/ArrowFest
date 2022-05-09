using UnityEngine;
using Utilities;

public class ArrowManager : MonoSingleton<ArrowManager>
{
    #region SerializedFields

    [SerializeField]
    private GameObject arrowPrefab;

    [SerializeField]
    private int maxArrowCount;

    #endregion

    #region Variables

    private GameObject[] arrows;

    private int currentArrowCount;

    private int ring;
    private int ringCapacity = 0;

    #endregion

    #region Props

    public int CurrentArrowCount => currentArrowCount;

    #endregion

    #region Unity Methods

    private void Start()
    {
        arrows = new GameObject[maxArrowCount];

        for (int i = 0; i < maxArrowCount; i++)
        {
            var arrow = Instantiate(arrowPrefab, GetArrowPosition(i), Quaternion.identity, PlayerController.Instance.transform);
            arrows[i] = arrow;
            arrow.SetActive(false);
        }

        arrows[0].SetActive(true);
        currentArrowCount = 1;
    }

    #endregion

    #region Methods

    private Vector3 GetArrowPosition(int i)
    {
        if (i == 0) return Vector3.zero;

        currentArrowCount++;
        if (currentArrowCount > ringCapacity)
        {
            ring++;
            ringCapacity = (int)(Mathf.PI * ring * .075f * 2 / 0.08f);
            currentArrowCount = 0;
        }

        float angle = ((float)currentArrowCount / (float)ringCapacity) * 360f;

        float x = Mathf.Cos(Mathf.Deg2Rad * angle) * ring * .075f;
        float y = Mathf.Sin(Mathf.Deg2Rad * angle) * ring * .075f;

        return new Vector3(x, y, 0);
    }

    public void IncreaseArrows(int count)
    {
        for (int i = 0; i < count; i++)
        {
            arrows[currentArrowCount++].gameObject.SetActive(true);
        }
    }

    public void DecreaseArrows(int count)
    {
        if (currentArrowCount <= count)
        {
            Debug.Log("gg");
        }
        for (int i = 0; i < count; i++)
        {
            arrows[--currentArrowCount].gameObject.SetActive(false);
        }
    }

    public void SetArrows(int newCount)
    {
        for (int i = 0; i < newCount; i++)
        {
            arrows[i].SetActive(true);
        }
        for (int i = newCount; i < maxArrowCount; i++)
        {
            arrows[i].SetActive(false);
        }

        currentArrowCount = newCount;
    }

    #endregion

    #region Callbacks

    #endregion
}