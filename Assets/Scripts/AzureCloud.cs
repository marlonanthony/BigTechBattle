using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzureCloud : MonoBehaviour
{
    [SerializeField]
    private GameObject rain;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Start()
    {
        StartCoroutine(TheBringerOfRain());
        StartCoroutine(RemoveCloud());
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(player.transform.position.x, 3f, 1f);
    }

    IEnumerator TheBringerOfRain()
    {
        while (true)
        {
            Instantiate(rain, new Vector3(transform.position.x, 2.7f, transform.position.z), transform.rotation);
            Instantiate(rain, new Vector3(transform.position.x - 2f, 2.7f, transform.position.z), transform.rotation);
            Instantiate(rain, new Vector3(transform.position.x + 2f, 2.7f, transform.position.z), transform.rotation);
            Instantiate(rain, new Vector3(transform.position.x - 5f, 2.7f, transform.position.z), transform.rotation);
            Instantiate(rain, new Vector3(transform.position.x - 4f, 2.7f, transform.position.z), transform.rotation);
            Instantiate(rain, new Vector3(transform.position.x - 3f, 2.7f, transform.position.z), transform.rotation);
            Instantiate(rain, new Vector3(transform.position.x + 5f, 2.7f, transform.position.z), transform.rotation);
            Instantiate(rain, new Vector3(transform.position.x + 4f, 2.7f, transform.position.z), transform.rotation);
            Instantiate(rain, new Vector3(transform.position.x + 3f, 2.7f, transform.position.z), transform.rotation);
            yield return new WaitForSeconds(1);

        }
    }

    IEnumerator RemoveCloud()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
