using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPreffManager : MonoBehaviour
{

    public GameObject SC1;
    public GameObject SC2;
    public GameObject SC3;
    public GameObject SC4;
    public GameObject SC5;
    public GameObject SC6;

    public GameObject SClev1;
    public GameObject SClev2;
    public GameObject SClev3;



    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("SC1", 1);
        PlayerPrefs.SetInt("SC2", 1);
        PlayerPrefs.SetInt("SC3", 1);
        PlayerPrefs.SetInt("SC4", 1);
        PlayerPrefs.SetInt("SC5", 1);
        PlayerPrefs.SetInt("SC6", 1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CheckLev1()
    {
        SClev1.SetActive(true);
        SClev2.SetActive(false);
        SClev3.SetActive(false);

        int temp1 = PlayerPrefs.GetInt("SC1");
        int temp2 = PlayerPrefs.GetInt("SC2");

        if(temp1 == 1)
        {
            SC1.SetActive(true);
        }
        else
        {
            SC1.SetActive(false);
        }
        if (temp2 == 1)
        {
            SC2.SetActive(true);
        }
        else
        {
            SC2.SetActive(false);
        }
    }
    public void CheckLev2()
    {
        SClev1.SetActive(false);
        SClev2.SetActive(true);
        SClev3.SetActive(false);

        int temp1 = PlayerPrefs.GetInt("SC3");
        int temp2 = PlayerPrefs.GetInt("SC4");
        Debug.Log("k");
        if (temp1 == 1)
        {
            Debug.Log("ye");

            SC3.SetActive(true);
        }
        else
        {
            Debug.Log("ne");

            SC3.SetActive(false);
        }
        if (temp2 == 1)
        {
            SC4.SetActive(true);
        }
        else
        {
            SC4.SetActive(false);
        }
    }
    public void CheckLev3()
    {
        SClev1.SetActive(false);
        SClev2.SetActive(false);
        SClev3.SetActive(true);

        int temp1 = PlayerPrefs.GetInt("SC5");
        int temp2 = PlayerPrefs.GetInt("SC6");

        if (temp1 == 1)
        {
            SC5.SetActive(true);
        }
        else
        {
            SC5.SetActive(false);
        }
        if (temp2 == 1)
        {
            SC6.SetActive(true);
        }
        else
        {
            SC6.SetActive(false);
        }
    }
}
