using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject prefabSpawn;

    private string objectName = "Platform";
    private float posX = 14.5f, posY, lastPosY = 40, moveSpeed = 5, seconds = 1.5f;
    float[] possibleHeights = { 40, 41.75f, 43.5f };
    int lastIndex, maxRange;

    void Start()
    {
        if (this.name != objectName)
        {
            StartCoroutine(SpawnObjectInterval(objectName, posX, seconds));
        }
    }

    void Update()
    {
        if (this.name == objectName)
        {
            MoveLeftAndDestroyGameObject();
        }
    }

    private IEnumerator SpawnObjectInterval(string name, float posX, float seconds)
    {
        while (true)
        {
            lastIndex = System.Array.IndexOf(possibleHeights, lastPosY);
            maxRange = lastIndex == 0 ? 2 : possibleHeights.Length;

            posY = possibleHeights[Random.Range(0, maxRange)];
            lastPosY = posY;

            SpawnGameObject(name, posX, posY);

            yield return new WaitForSeconds(seconds);
        }
    }

    private void SpawnGameObject(string name, float posX, float posY)
    {
        GameObject spawnedPrefab = Instantiate(prefabSpawn);

        spawnedPrefab.transform.position = new Vector2(posX, posY);
        spawnedPrefab.name = name;
    }

    private void MoveLeftAndDestroyGameObject()
    {
        transform.Translate(moveSpeed * Time.deltaTime * Vector3.left);

        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }
}
