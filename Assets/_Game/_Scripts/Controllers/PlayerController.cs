using System;
using UnityEngine;
using Utilities;

public class PlayerController : MonoSingleton<PlayerController>
{
    #region SerializedFields

    [SerializeField]
    private float speed;

    [SerializeField]
    private float sideSpeed;

    #endregion

    #region Variables

    #endregion

    #region Props

    #endregion

    #region Unity Methods

    private void Start()
    {
        InputController.Instance.TouchPositionChanged += OnTouchPositionChanged;
    }

    private void Update()
    {
        transform.position += new Vector3(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        var collectable = other.GetComponent<ICollectable>();
        if (collectable != null)
        {
            collectable.Collect();
        }
    }

    #endregion

    #region Methods

    #endregion

    #region Callbacks

    private void OnTouchPositionChanged(float newPositionX)
    {
        transform.position = new Vector3
        (
            Mathf.Clamp
            (
                transform.position.x + sideSpeed * Time.deltaTime * newPositionX,
                -RoadController.Instance.PlaneSideSize + 0.5f,
                RoadController.Instance.PlaneSideSize - 0.5f
            ),
            transform.position.y,
            transform.position.z
        );
    }

    #endregion
}