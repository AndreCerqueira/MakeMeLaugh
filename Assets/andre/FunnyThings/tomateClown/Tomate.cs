using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tomate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeOut());

        // Gera um deslocamento aleatório em X e Y dentro dos intervalos fornecidos
        float randomX = Random.Range(-296, 295); // 295 é o limite superior exclusivo
        float randomY = Random.Range(-485, 465); // 465 é o limite superior exclusivo

        // Aplica o deslocamento à posição atual
        transform.localPosition = new Vector3(randomX, randomY, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // corroutine to fade out
    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(2f);
        // fade out
        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            Color c = GetComponent<Image>().color;
            c.a = f;
            GetComponent<Image>().color = c;
            yield return new WaitForSeconds(0.1f);
        }
        // destroy
        Destroy(gameObject);
    }
}
