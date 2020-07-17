using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class Draw : MonoBehaviour
{
    //lineWidth용 싱글톤
    public static Draw Instance;
    private void Awake()
    {
        Instance = this;
    }

    [Header("Collider")] // Collider 항목 생성
    public Vector3 offset = new Vector3(0, -0.05f, 0.03f);
    public float radius = 0.025f;

    [Header("Controller")] //Controller 항목 생성
    //오른손, trigger 버튼 클릭 여부, 컨트롤러 위치
    public SteamVR_Input_Sources rightHand = SteamVR_Input_Sources.RightHand;
    public SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI;
    public SteamVR_Action_Pose pose = SteamVR_Actions.default_Pose;
    public SteamVR_Action_Boolean grip = SteamVR_Input.GetBooleanAction("GrabGrip");

    [Header("Line")] //Line 항목 생성
    //라인 두께
    public float lineWidth = 0.01f;
    //색상
    public Color lineColor = new Color(1, 1, 1, 0.5f);
    public Material lineMaterial;

    LineRenderer line;
    SphereCollider lineCol;

    public GameObject smokeFactory;
    public GameObject bubbleFactory;


    //bool isColor = false;

    void Start()
    {
        //Rigidbody와 Collider 컴포넌트 추가 및 설정
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.isKinematic = true;

        SphereCollider coll = gameObject.AddComponent<SphereCollider>();
        coll.isTrigger = true;
        coll.center = offset;
        coll.radius = radius;
    }

    void Update()
    {
        //오른쪽 컨트롤러의 트리거 버튼을 클릭했을 때 CreateLineObject 함수를 호출
        //if (trigger.GetStateDown(rightHand))
        //{
        //    CreateLineObject();
        //}

            DrawLine();
        
        

    }

    void CreateLineObject()
    {
        //"Line"이라는 게임오브젝트를 생성하여 LineRenderer컴포넌트를 추가한다. 
        GameObject lineObject = new GameObject("Line");
        line = lineObject.AddComponent<LineRenderer>();
        lineCol = lineObject.AddComponent<SphereCollider>();


        //번개효과 머티리얼 테스트중(박동건)///////////////////////////
        //Material newMat = GetComponent<LineRenderer>().material;
        //newMat.SetFloat("_StartSeed", Random.value * 1000);
        //GetComponent<LineRenderer>().material = newMat;
        ///////////////////////////////////////////////////////////////

        //라인렌더러에 연결할 머티리얼 생성
        Material mt = new Material(Shader.Find("Unlit/Color"));
        mt.color = lineColor;

        line.material = mt;
        line.useWorldSpace = false;

        //라인의 끝부분을 부드럽게 하기위한 버텍스 갯수 설정
        line.numCapVertices = 20;

        //라인렌더러의 폭 설정
        line.widthMultiplier = 0.1f;
        line.startWidth = lineWidth;
        line.endWidth = lineWidth;

        //라인렌더러의 노드 갯수를 1로 설정
        line.positionCount = 1;

        //첫 번째 노드의 위치를 컨트롤러의 위치로 설정
        Vector3 position = pose.GetLocalPosition(rightHand);
        line.SetPosition(0, position);
    }


    void OnTriggerEnter(Collider coll)
    {
        //erasers
        if (grip.GetState(rightHand))
        {
            //print(" 누르고는 있니");
            if (coll != null)
            {
                if(coll.gameObject.layer != 10)
                {
                    Destroy(coll.gameObject);

                //    GameObject smoke = Instantiate(smokeFactory);
                //    smoke.transform.position = transform.position;
                //    smoke.transform.rotation = Camera.main.transform.rotation;

                //    Destroy(smoke, 1);
                }
                

            }
        }

        //if (isColor == true)
        //{
        //    Material newMat = coll.gameObject.GetComponent<Material>();
        //    Shader sha = coll.gameObject.GetComponent < Shader > ();

        //    newMat.SetColor("Main Color", Color.red);

        //    print("linecolor는 " + lineColor);
        //    print("newMat는 " + newMat);
        //}
        Menu(coll);


    }

    private void Menu(Collider coll)
    {
        //GameObject bubble = Instantiate(bubbleFactory);
        //bubble.transform.position = transform.position;
        //bubble.transform.rotation = Camera.main.transform.rotation;
        //Destroy(bubble, 1);

        switch (coll.tag)
        {
            case "LIGHTNING":
                //line.material = lightning;
                break;
            case "RED":
                lineColor = Color.red;
                break;

            case "BLACK":
                lineColor = Color.black;
                break;

            case "YELLOW":
                lineColor = Color.yellow;
                break;

            case "GREEN":
                lineColor = Color.green;
                break;

            case "BLUE":
                lineColor = Color.blue;
                break;

            case "MAGENTA":
                lineColor = Color.magenta;
                break;

            case "GRAY":
                lineColor = Color.gray;
                break;

            case "WHITE":
                lineColor = Color.white;
                break;
            //case "NewColor":
                
            //    if (isColor == false)
            //    {
            //        print("색깔 변경 온");
            //        isColor = true;
            //    }
            //    else
            //    {
            //        print("색깔 변경 오프");
            //        isColor = false;
            //    }
            //    break;
        }
    }

    private void DrawLine(){

        //트리거 버튼을 계속 클릭하고 있을 때 라인렌더러의 노드를 추가
        if (trigger.GetState(rightHand))
        {
            CreateLineObject();
            //컨트롤러의 현재 위치값을 추출
            Vector3 position = pose.GetLocalPosition(rightHand);
            //라인렌더러의 노드 갯수를 증가
            ++line.positionCount;
            //새로 만든 노드의 위치값을 설정
            line.SetPosition(line.positionCount - 1, position);

            lineCol.center = position;
            lineCol.radius = radius;
        }

        if (trigger.GetStateUp(rightHand))
        {
            line = null;
        }
    }
}

