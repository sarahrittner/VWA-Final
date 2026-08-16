using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlimeSpawner : MonoBehaviour
{
    [Header("Spawn Bereich")]
    public float width = 10f;
    public float height = 5f;

    [Header("Items")]
    public GameObject[] slimes;

    // Wie viele Items maximal gleichzeitig da sein sollen
    public int maxSlimes = 5;

    [Header("Respawn")]
    public float respawnTime = 50f;

    // Hier merken wir uns alle gespawnten Items
    private List<GameObject> spawnedItems = new List<GameObject>();

    private void Start()
    {
        // Am Anfang alle Items spawnen
        for (int i = 0; i < maxSlimes; i++)
        {
            SpawnRandomSlime();
        }

        // Respawn-Prüfung starten
        StartCoroutine(CheckForRespawn());
    }

    private IEnumerator CheckForRespawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);

            // Zerstörte Items aus der Liste entfernen
            spawnedItems.RemoveAll(item => item == null);

            // Fehlende Items wieder auffüllen
            while (spawnedItems.Count < maxSlimes)
            {
                SpawnRandomSlime();
            }
        }
    }

    private void SpawnRandomSlime()
    {
        float randomX = Random.Range(
            transform.position.x - width / 2,
            transform.position.x + width / 2
        );

        float randomY = Random.Range(
            transform.position.y - height / 2,
            transform.position.y + height / 2
        );

        Vector2 randomPosition = new Vector2(randomX, randomY);

        // Zufälliges Item auswählen
        int randomIndex = Random.Range(0, slimes.Length);

        GameObject newItem = Instantiate(
            slimes[randomIndex],
            randomPosition,
            Quaternion.identity
        );

        spawnedItems.Add(newItem);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireCube(
            transform.position,
            new Vector3(width, height, 0)
        );
    }
}
