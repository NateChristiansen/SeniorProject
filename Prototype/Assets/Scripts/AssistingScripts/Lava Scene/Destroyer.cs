using UnityEngine;

public class Destroyer : MonoBehaviour
{

    public GameObject RockScenery;
    public GameObject BillBoardParent;
    public GameObject Anim1Parent;
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

    private void DestroyAnim1()
    {
        Destroy(Anim1Parent);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("car"))
        {
            DestroyRockScenery();
            DestroyBillBoards();
            DestroyAnim1();
        }
    }
}
