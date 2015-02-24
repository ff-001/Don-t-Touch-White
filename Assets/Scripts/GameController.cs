using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    public static int score = 0;

    public GameObject startUI;
    public GameObject gameUI;
    public GameObject scoreUI;
	public GameObject resultUI;
	public GameObject blockUI;

	public GameObject KTplayBtn;

    public GameObject container;
    public GameObject[] prefabs;
    int prefabsIndex;
    public GameObject tapParticle;
    Vector3 tapPosition;
    public ArrayList blocks;

	void Update(){
		if(Input.GetKey(KeyCode.Escape)){
			Application.Quit();
		}
	}

    public void EnterGameUI()
    {
        startUI.SetActive(false);
        gameUI.SetActive(true);
        scoreUI.SetActive(true);

        StartGame();
    }
	public void RestartGameUI(){
		startUI.SetActive(false);
		resultUI.SetActive(false);
		scoreUI.SetActive(true);
		gameUI.SetActive(true);
		blockUI.SetActive(true);
		Clean();
		StartGame();
	}
    //回到主选单
    public void ReturnStartUI()
    {
        startUI.SetActive(true);
        gameUI.SetActive(false);
        scoreUI.SetActive(false);

        Clean();
    }

    //开始游戏
    void StartGame()
    {
        //创建块链表
        blocks = new ArrayList();
        //遍历创建块
        for (int rowIndex = 0; rowIndex < 6; rowIndex++)
        {
            AddBlock(rowIndex);
        }
    }

    //添加块
    void AddBlock(int rowIndex)
    {
        //随机可走的块出现的列位置
        int columnIndex = Random.Range(0, 4);
        for (int i = 0; i < 4; i++)
        {
            if (i == columnIndex)
            {
                //随机取得其他色块种类索引
                prefabsIndex = Random.Range(1, 6);
            }
            else
            {
                //白块
                prefabsIndex = 0;
            }
            //生成块               
            GameObject o = Instantiate(prefabs[prefabsIndex]) as GameObject;
            o.transform.parent = container.transform;

            //通过block确定块的位置
            Block b = o.GetComponent<Block>();
            //设置块自身的行列索引
            b.columnIndex = i;
            b.rowIndex = rowIndex;
            b.transform.position = b.GetPosition();
            //添加至blocks数组
            blocks.Add(b);
        }

    }

    //点选块事件
    public void Select(Block block)
    {
        //如果不是白块 播放声音和粒子
        if (block.score > 0)
        {
            //播放声音
            block.audio.Play();
            //获取粒子生成位置
            tapPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject p=Instantiate(tapParticle, new Vector3(tapPosition.x, tapPosition.y, 0), Quaternion.identity)as GameObject;
            p.transform.parent = container.transform;
            p.GetComponent<ParticleSystem>().startColor = block.GetComponent<SpriteRenderer>().color;

		}else{
			ReturnButton._instance.ReadyToRestart();
			UI._instance.ShowResult();
			scoreUI.SetActive(false);
			resultUI.SetActive(true);
			blockUI.SetActive(false);
		}
        //加减分
        score = score + block.score;
        //移动块
        for (int i = 0; i < blocks.Count; i++)
        {
            Block b = (Block)blocks[i];
            b.rowIndex--;
            b.targetPos = b.GetPosition();
            b.isMove = true;
            b.timer = 0;
            //出屏幕后删除
            if (b.rowIndex == -2)
            {
                blocks.RemoveAt(i);
                Destroy(b.gameObject);
                i--;
            }
        }
        //上方增加新块
        AddBlock(5);
    }

    //清空块
    public void Clean()
    {
        for (int i = 0; i < blocks.Count; i++)
        {
            Block b = (Block)blocks[i];
            blocks.RemoveAt(i);
            Destroy(b.gameObject);
            i--;
        }
        score = 0;
    }
}
