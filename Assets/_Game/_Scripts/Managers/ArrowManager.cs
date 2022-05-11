using System;
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
    private int line = 0;
    private float temp = 0;

    private int ringCapacity = 0;
    private int lineCapacity;

    #endregion

    #region Props

    public int CurrentArrowCount => currentArrowCount;

    #endregion

    #region Unity Methods

    private void Start()
    {
        GameManager.Instance.GameStatesChanged += OnGameStatesChanged;
        InputController.Instance.TouchPositionChanged += OnTouchPositionChanged;
        arrows = new GameObject[maxArrowCount];

        for (int i = 0; i < maxArrowCount; i++)
        {
            var arrow = Instantiate(arrowPrefab, GetArrowPosition(i), Quaternion.identity, PlayerController.Instance.transform);
            arrows[i] = arrow;
            arrow.SetActive(false);
        }
        currentArrowCount = 1;
        arrows[0].SetActive(true);
    }

    private void Update()
    {

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

        float x = Mathf.Cos(Mathf.Deg2Rad * angle) * ring * .07f;
        float y = Mathf.Sin(Mathf.Deg2Rad * angle) * ring * .07f;

        return new Vector3(x, y, 0);
    }

    public void GetFinalArrowPosition()
    {
        for (int i = -currentArrowCount / 2; i < currentArrowCount / 2 + 1; i++)
        {
            arrows[i + currentArrowCount / 2].transform.position = new Vector3((4.0f / (float)currentArrowCount * i), 0, arrows[i + currentArrowCount / 2].transform.position.z);
        }
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
            GameManager.Instance.UpdateGameState(GameStates.Fail);

        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                arrows[--currentArrowCount].gameObject.SetActive(false);
            }
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

    private void OnGameStatesChanged(GameStates newState)
    {
        if (newState == GameStates.Final)
        {
            temp = (int)Mathf.Sqrt(currentArrowCount) * 2;
            GetFinalArrowPosition();
            //new Vector3(PlayerController.Instance.transform.localScale.x / 2, PlayerController.Instance.transform.localScale.y, PlayerController.Instance.transform.localScale.z);
            if (currentArrowCount <= 0)
            {
                GameManager.Instance.UpdateGameState(GameStates.Success);
            }
        }
        if (newState == GameStates.InGame)
        {
            if (currentArrowCount <= 0)
            {
                GameManager.Instance.UpdateGameState(GameStates.Fail);
            }
        }
    }


    private void OnTouchPositionChanged(Touch touch)
    {
        if (GameManager.Instance.CurrentGameState == GameStates.Final)
        {
            GetFinalArrowPosition();
        }

    }

    #endregion
}