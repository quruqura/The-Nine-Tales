using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct SomeStruct
{
    public int iValue;
    public bool bValue;
}

public struct SomeStruct2
{
    public int iValue;
    public bool bValue;
}

public class T_CharacterController : MonoBehaviour
{
    public SomeStruct StructField;

    public List<SomeStruct> StructList;

    public Dictionary<int, SomeStruct> StructDict;

    [SerializeField]
    public SomeStruct2 Struct2Field;

    int rec(int x, int y)
    {
        if (y == 0)
            return x;
        else
            return rec(y, x % y);
    }

    private void Start()
    {
        print(rec(10, 5));
        print(rec(6, 4));
        print(rec(15, 12));
    }
}

//public class T_CharacterController : MonoBehaviour
//{
//    public float speed;
//    public float jumpForce;

//    public GameObject jump_vfx;
//    public GameObject doubleJump_vfx;
//    public GameObject landing_vfx;
//    public GameObject dash_vfx;

//    public string oldString;
//    public char oldChar;
//    public char newChar;

//    bool onGround;
//    bool canDoubleJump = false;

//    Rigidbody2D rd;

   


//    void Start()
//    {
//        rd = GetComponent<Rigidbody2D>();
//    }

//    private void Update()
//    {
//        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), 0);
//        transform.Translate(direction * speed * Time.deltaTime);
//        if (Input.GetButtonDown("Jump"))
//        {
//            //rd.AddForce(Vector2.up * jumpForce * 0.8f, ForceMode2D.Impulse);
//            //canDoubleJump = false;
//            //StartCoroutine(launchVFX(doubleJump_vfx));

//            print(Replace(oldString, oldChar, newChar));
//        }

//    }

//    private void FixedUpdate()
//    {
//        if (Input.GetButtonDown("Jump") && onGround)
//        {
//            rd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
//            canDoubleJump = true;
//            onGround = false;
//            StartCoroutine(launchVFX(jump_vfx));
//        }
//        else if (Input.GetButtonDown("Jump") && !onGround && canDoubleJump)
//        {
//            //rd.AddForce(Vector2.up * jumpForce * 0.8f, ForceMode2D.Impulse);
//            //canDoubleJump = false;
//            //StartCoroutine(launchVFX(doubleJump_vfx));
//            Replace(oldString, oldChar, newChar);
//        }

//        if (Input.GetKeyDown(KeyCode.J) && onGround)
//        {
//            rd.AddForce(Vector2.right * jumpForce, ForceMode2D.Impulse);
//            StartCoroutine(launchVFX(dash_vfx));
//        }
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.layer == 6)
//        {
//            onGround = true;
//            StartCoroutine(launchVFX(landing_vfx));
//        }

//    }

//    IEnumerator launchVFX(GameObject _obj)
//    {
//        _obj.SetActive(true);
//        yield return new WaitForSeconds(1);
//        _obj.SetActive(false);
//    }

//    public static string Replace(string oldString, char oldChar, char newChar)
//    {
//        string newString = "";

//        foreach (var c in oldString)
//        {
//            newString += (c == oldChar) ? newChar : c;
//        }

//        return newString;
//    }

//}

