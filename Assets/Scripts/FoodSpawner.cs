using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    public int foodCount = 50;
    public float boundarySize = 500f;
    public Transform field;

    void Start()
    {
        for (int i = 0; i < foodCount; i++)
        {
            // Randomly spawn food in the center of the boundary
            float x = Random.Range(-boundarySize + 100, boundarySize - 100);
            float y = Random.Range(-boundarySize + 100, boundarySize - 100);

            Vector3 spawnPosition = new Vector3(x, y, 0f);
            print(spawnPosition);
            GameObject food = Instantiate(foodPrefab, field.transform.position, Quaternion.identity, field);
            food.transform.localPosition = spawnPosition;

            //// Calculate the position in world space
            //float x = Random.Range(-boundarySize - 50, boundarySize - 50);
            //float y = Random.Range(-boundarySize - 50, boundarySize - 50);
            //Vector2 spawnPosition = new Vector2(x, y);
            //print(spawnPosition);

            //// Convert the spawn position from world space to local space
            //Vector3 worldPosition = new Vector3(spawnPosition.x, spawnPosition.y, 0);  // Assuming Z=0 for 2D space
            //Vector3 localPosition = field.InverseTransformPoint(worldPosition);  // Convert to local position relative to the field Transform

            //// Instantiate the food prefab
            //GameObject food = Instantiate(foodPrefab, field.transform.position, Quaternion.identity, field);

            //// Set the food's position in local space
            //food.transform.localPosition = new Vector3(localPosition.x, localPosition.y, 0);
        }
    }
}
