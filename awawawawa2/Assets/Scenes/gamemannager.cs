using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gamemannager : MonoBehaviour
{
    public GameObject menuPrincipal;
    public GameObject menuGameOver;

    public GameObject columna;
    public GameObject obstaculo;
    public GameObject obstaculito;
    public bool gameOver = false;
    public bool start = false;

    public Renderer fondo;

    public float velocidad = 2;

    public List<GameObject> cols;
    public List<GameObject> obstaculos;
    void Start()
    {
        for (int i = 0 ; i < 21 ; i++)
        { 
           cols.Add (Instantiate(columna, new Vector2(-10 + i, -3), Quaternion.identity));
        }

        obstaculos.Add(Instantiate(obstaculo, new Vector2(14, -2), Quaternion.identity));
        obstaculos.Add(Instantiate(obstaculito, new Vector2(20, -2), Quaternion.identity));
    }
    void Update()
    {
        if (start == false)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                start = true;
            }
        }

        if (start == true && gameOver == true)
        {
            menuGameOver.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (start == true && gameOver == false)
        {
            menuPrincipal.SetActive(false);

            fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.020f, 0) * Time.deltaTime;

            for (int i = 0; i < cols.Count; i++)
            {
                if (cols[i].transform.position.x <= -10)
                {
                    cols[i].transform.position = new Vector3(10, -3, 0);
                }
                cols[i].transform.position = cols[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }

            for (int i = 0; i < obstaculos.Count; i++)
            {
                if (obstaculos[i].transform.position.x <= -10)
                {
                    float randomObs = Random.Range(11, 18);
                    obstaculos[i].transform.position = new Vector3(randomObs, -2, 0);
                }
                obstaculos[i].transform.position = obstaculos[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }
        }
    }
}
