using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    private GameObject[] trashObjectsPool;// 오브젝트를 담을 리스트
    public GameObject trashFactory;//생성될 프리팹
    public int poolSize = 10;//생성될 갯수
    public float delayTime = 3f;
    private GameObject t_rash;//생성될 쓰레기
    public Vector3[] spwnPostion;
    private bool isWating = false;
    private Rigidbody _rd;
    // Start is called before the first frame update
    void Start()
    {
       
        trashObjectsPool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            GameObject trash = Instantiate(trashFactory);
            trash.SetActive(false);
            trashObjectsPool[i] = trash;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWating)
        {
            StartCoroutine(spwn());
        }
    }
    IEnumerator spwn()
    {
        for (int j = 0; j < spwnPostion.Length; j++)
        {
            for (int i = 0; i < poolSize; i++)
            {
                t_rash = trashObjectsPool[i];
                if (!t_rash.activeSelf)
                {
                    t_rash.transform.position = spwnPostion[j];
                    _rd = t_rash.GetComponent<Rigidbody>(); // 각 오브젝트의 Rigidbody를 가져옴
                    if (_rd != null)
                    {
                        _rd.velocity = Vector3.zero; // 속도 초기화
                    }
                    t_rash.SetActive(true);
                    isWating = true;
                    break;
                }
            }

            yield return new WaitForSeconds(delayTime);
            isWating = false;
        }

    }
}