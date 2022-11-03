using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawn : MonoBehaviour
{

    [SerializeField] Transform[] points;
    public GameObject cube;

    int i;
    int k;
    int l;
    int m;
    int n;
    int o;

    bool first, second, third, forth, zero;
    bool volta;

    string name;

    void Start()
    {

        k = -1;
        l = -1;
        m = -1;
        n = -1;
        o = -1;
        first = false;
        second = false;
        third = false; 
        forth = false;
        volta = false;
        zero = false;
        StartCoroutine(Nasce());

    }

    void Update()
    {

    }

    IEnumerator Nasce()
    {

        yield return new WaitForSeconds(6);

        for (int j = 0; j < 5; j++)
        {

            i = Random.Range(0, points.Length);

            if (i != k && i != l && m != i && n != i && o != i)
            {

                name = "CelulaEnergetica";
                cube.gameObject.tag = name;
                Instantiate(cube, points[i].position, points[i].rotation);

            }
            else
            {

                if(j > 0)
                {

                    j--;

                }
                
                volta = true;

            }
            if(j == 0 &&(zero == false|| volta == true))
            {

                o = i;
                zero = true;
                volta = false;

            }
            else if (j == 1 && (first == false || volta == true))
            {

                k = i;
                first = true;
                volta = false;

            }
            else if (j == 2 && (second == false || volta == true))
            {

                l = i;

                second = true;
                volta = false;

            }
            else if (j == 3 && (third == false || volta == true))
            {

                m = i;

                third = true;
                volta = false;

            }
            else if (j == 4 && (forth == false || volta == true))
            {

                n = i;

                forth = true;
                volta = false;

            }

        }

    }

}
