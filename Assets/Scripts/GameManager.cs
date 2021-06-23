using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
//using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    public GameObject[] fruits;
    public bool first = true;
    //public TextMeshProUGUI score, lastScore;
    public RectTransform panel;
    public PauseMenu pm;
    public int[] clones;
    public int cloneCounter;
    public RawImage info;
    public Texture info1, info2;
    public bool clickable = true;

    //For category
    public GameObject[] _fruits;

    private Camera cam;
    private int _score = 0;
    private int inc = 100;
    private GameObject tempObj;
    private string firstName = null;
    private int counter = 0;
    private GameObject[] covers;
    private int categ;
    void Start()
    {
        cam = Camera.main;
        categ = PlayerPrefs.GetInt("Category");
        if (categ == 0)
        {
            cam.transform.position = new Vector3(3, 1.5f, cam.transform.position.z);
            _fruits = new GameObject[6];
            GetFruits();
        }
        else if(categ == 1)
        {
            cam.transform.position = new Vector3(3, 3, cam.transform.position.z);
            _fruits = new GameObject[8];
            GetFruits();
        }
        else if (categ == 2)
        {
            cam.transform.position = new Vector3(4.5f, 3f, cam.transform.position.z);
            _fruits = new GameObject[10];
            GetFruits();
        }
        else
        {
            Debug.LogError("Kategori belirlenemedi!");
        }

        int length1 = _fruits.Length;
        int length2 = _fruits.Length;
        if (categ == 0)
        {
            length1+=2;
        }
        else if(categ == 2)
        {
            length2 -= 2;
        }
        pm.Resume();
        clones = new int[_fruits.Length * 2];
        ScoreUpdate();



        for (int x = 0; x < length1; x += 2)
        {
            for (int y = 0; y < length2; y += 2)
            {
                Spawn(x, y);
            }
        }

        covers = GameObject.FindGameObjectsWithTag("Cover");
        Cover();
    }

    private void GetFruits()
    {
        for (int i = 0; i < _fruits.Length; i++)
        {
            _fruits[i] = fruits[i];
        }
    }
    private void Cover()
    {
        for (int i = 0; i < covers.Length; i++)
        {
            covers[i].SetActive(false);
        }
    }
    public void UnCover()
    {
        for (int i = 0; i < covers.Length; i++)
        {
            covers[i].SetActive(true);
        }
    }



    private void Spawn(int x, int y)
    {
        GameObject newFruit = GameObject.Instantiate(RandomFruit(), new Vector2(x, y + 10), Quaternion.identity);

        Fruit frt = newFruit.GetComponent<Fruit>();
        frt.NewLocation(x, y);
    }
    private GameObject RandomFruit()
    {
        int rnd;
        do
        {
            rnd = Random.Range(0, _fruits.Length);

        } while (Search(rnd));
        clones[cloneCounter] = rnd;
        cloneCounter++;
        return _fruits[rnd];
    }
    private bool Search(int _clone)
    {
        int counter = 0;
        for (int i = 0; i < cloneCounter; i++)
        {
            if (clones[i] == _clone)
            {
                counter++;
                if (counter == 2)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void Click(GameObject obj)
    {
        if (clickable)
        {
            if (first)
            {
                firstName = obj.name;
                tempObj = obj;
                tempObj.SetActive(false);
                first = false;
            }
            else
            {
                obj.SetActive(false);
                if (firstName == obj.name)
                {
                    _score += inc;
                    inc = 100;
                    StartCoroutine(Boom(obj, tempObj));
                    ScoreUpdate();
                }

                else
                {
                    if (inc > 50)
                        inc -= 10;
                    clickable = false;
                    
                    StartCoroutine(Check(obj));

                }
                first = true;
            }
        }
    }

    private void ScoreUpdate()
    {
        //score.text = _score.ToString();
        //lastScore.text = score.text;
        counter++;
        if (counter == _fruits.Length + 1)
        {
            FindObjectOfType<AudioManager>().Play("Success");
            StartCoroutine(LastVisible());
        }


    }

    public void InfoDown()
    {
        info.texture = info2;        
    }
    public void InfoUp()
    {
        info.texture = info1;
    }

    IEnumerator Boom(GameObject obj1, GameObject obj2)
    {
        yield return new WaitForSeconds(.5f);
        Transform anim = obj1.GetComponentInParent<Transform>().GetChild(2);
        Transform anim0 = obj1.GetComponentInParent<Transform>().GetChild(0);
        anim.gameObject.SetActive(true);
        anim0.gameObject.SetActive(false);
        Transform tempAnim = obj2.GetComponentInParent<Transform>().GetChild(2);
        Transform tempAnim0 = obj2.GetComponentInParent<Transform>().GetChild(0);
        tempAnim.gameObject.SetActive(true);
        tempAnim0.gameObject.SetActive(false);
        if (counter < _fruits.Length + 1)
            FindObjectOfType<AudioManager>().Play("Zing");
    }
    IEnumerator Check(GameObject obj)
    {
        FindObjectOfType<AudioManager>().Play("WrongMove");
        yield return new WaitForSeconds(1f);
        obj.SetActive(true);
        tempObj.SetActive(true);
        clickable = true;
        
    }

    IEnumerator LastVisible()
    {
        yield return new WaitForSeconds(1.4f);
        panel.gameObject.SetActive(true);

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
