using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject prefabSpawn;

    private string objectName = "Platform";
    private float posX = 15, posY = 40, moveSpeed = 5, seconds = 1.5f;

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

    IEnumerator SpawnObjectInterval(string name, float posX, float seconds)
    {
        while (true)
        {
            posY = Random.Range(0, 2) == 0 ? 40 : 42;
            SpawnGameObject(name, posX, posY);

            yield return new WaitForSeconds(seconds);
        }
    }

    void SpawnGameObject(string name, float posX, float posY)
    {
        GameObject spawnedPrefab = Instantiate(prefabSpawn);

        spawnedPrefab.transform.position = new Vector2(posX, posY);
        spawnedPrefab.name = name;
    }

    void MoveLeftAndDestroyGameObject()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }
}
