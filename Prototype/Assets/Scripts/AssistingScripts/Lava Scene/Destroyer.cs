using UnityEngine;

public class Destroyer : MonoBehaviour
{

    public GameObject RockScenery;
    public GameObject BillBoardParent;
	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DestroyRockScenery()
    {
        Destroy(RockScenery);
    }

    public void DestroyBillBoards()
    {
        Destroy(BillBoardParent);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("car"))
        {
            DestroyRockScenery();
            DestroyBillBoards();
        }
    }
}
