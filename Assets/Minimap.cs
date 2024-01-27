using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{

    public RectTransform minimapPoint_1;
    public RectTransform minimapPoint_2;

    public Transform world_point_1;
    public Transform world_point_2;

    public RectTransform playerMinimap;
    public Transform playerWorld;

    private float minimapRatio;

    // Start is called before the first frame update
    void Awake()
    {
        CalculateMapRatio(); 
    }

    // Update is called once per frame
    void Update()
    {
        playerMinimap.anchoredPosition = minimapPoint_1.anchoredPosition + new Vector2((playerWorld.position.x - world_point_1.position.x) * minimapRatio,
            (playerWorld.position.z - world_point_1.position.z) * minimapRatio);

    }

    public void CalculateMapRatio()
    {
        Vector3 distanceWorldVector = world_point_1.position - world_point_2.position;
        distanceWorldVector.y = 0f;
        float distanceWorld = distanceWorldVector.magnitude;

        float distanceMinimap = Mathf.Sqrt(
            Mathf.Pow((minimapPoint_1.anchoredPosition.x - minimapPoint_2.anchoredPosition.x), 2) +
            Mathf.Pow((minimapPoint_1.anchoredPosition.y - minimapPoint_2.anchoredPosition.y), 2)
            );

        minimapRatio = distanceMinimap / distanceWorld;
    }
}
