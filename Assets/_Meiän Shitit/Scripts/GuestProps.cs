using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestProps : MonoBehaviour
{

    public Material[] skinList;
    public Material[] jacketList;
    public Material[] shirtList;
    public Material[] pantsList;
    public Material[] hairColours;
    public GameObject[] hairList;
    public GameObject[] moustachekchekheList;
    public GameObject[] props;

    public GameObject jacket;
    public GameObject shirt;
    public GameObject pants;
    public GameObject skin;
    public GameObject bomb;
    GameObject hair;


    void OnEnable()
    {
        int i = (int)Random.Range(0, hairList.Length + 1);

        if (i < hairList.Length)
        {
            if (hairList[i].name == "tophat")
            {
                hairList[i].SetActive(true);
            }
            else
            {
                hair = hairList[i];
                hair.SetActive(true);
                i = (int)Random.Range(0, hairColours.Length);
                hair.GetComponent<Renderer>().material = hairColours[i];
            }

        }

        i = (int)Random.Range(0, moustachekchekheList.Length + 1);

        if (i < moustachekchekheList.Length)
        {
            moustachekchekheList[i].SetActive(true);
            if (hair != null)
            {
                moustachekchekheList[i].GetComponent<Renderer>().material = hair.GetComponent<Renderer>().material;
            }

        }

        i = (int)Random.Range(0, jacketList.Length + 1);

        if (i < jacketList.Length)
        {
            jacket.SetActive(true);
            jacket.GetComponent<Renderer>().material = jacketList[i];
        }
        

        i = (int)Random.Range(0, shirtList.Length + 1);

        if (i < shirtList.Length)
        {
            shirt.SetActive(true);
            shirt.GetComponent<Renderer>().material = shirtList[i];
        }


        i = (int)Random.Range(0, pantsList.Length + 1);

        if (i < pantsList.Length)
        {
            pants.SetActive(true);
            pants.GetComponent<Renderer>().material = pantsList[i];
        }

        i = (int)Random.Range(0, skinList.Length);
        skin.GetComponent<Renderer>().material = skinList[i];

        i = (int)Random.Range(0, props.Length * 2);

        if (i < props.Length)
        {
            props[i].SetActive(true);
        }


        i = (int)Random.Range(0, 8);

        if (i < 3)
        {
            bomb.SetActive(true);
        }

    }

}




