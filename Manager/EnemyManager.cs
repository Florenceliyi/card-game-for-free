using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /// <summary>
    /// ���˹�����
    /// </summary>
public class EnemyManager 
{ 
    public static EnemyManager Instance = new EnemyManager();

    private List<Enemy> enemyList; //�洢ս���еĵ���

    /// <summary>
    /// ���ص�����Դ
    /// </summary>
    /// <param name="id">�ܿ�id</param>
    public void LoadRes(string id)
    {
        /*Id Name    EnemyIds PosId �ؿ�����    ����Id������ ���й����λ��
        10001   1   10001   0,0,0
        10002   2   10001 = 10001 0,0,0 = 0,0,1
        10003   3   10001 = 10002 = 10003   3,0,1 = 0,0,1 = -3,0,1*/

        enemyList = new List<Enemy>();

        //��ȡ�ؿ���
        Dictionary<string, string> levelData = GameConfigManager.Instance.GetLevelById(id);

        Debug.Log(levelData);

        //����id��Ϣ
        string[] enemyIds = levelData["EnemyIds"].Split('=');

        string[] enemyPos = levelData["Pos"].Split('=');

        for(int i = 0; i< enemyIds.Length; i++)
        {
            string enemyId = enemyIds[i];
            string[] posArr = enemyPos[i].Split(',');

            //����λ��
            float x = float.Parse(posArr[0]);
            float y = float.Parse(posArr[1]);
            float z = float.Parse(posArr[2]);

            //���ݵ���id��õ���������Ϣ
            Dictionary<string, string> enemyData = GameConfigManager.Instance.GetEnemyById(enemyId);

            GameObject obj = Object.Instantiate(Resources.Load(enemyData["Model"])) as GameObject; //����Դ·�����ض�Ӧ�ĵ���ģ��

            Enemy enemy = obj.AddComponent<Enemy>();//��ӵ��˽ű�

            enemy.Init(enemyData);//�洢������Ϣ

            //�洢������
            enemyList.Add(enemy);

            obj.transform.position = new Vector3(x, y, z);
        }
    }
}
