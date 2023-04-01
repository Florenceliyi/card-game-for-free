using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /// <summary>
    /// 敌人管理器
    /// </summary>
public class EnemyManager 
{ 
    public static EnemyManager Instance = new EnemyManager();

    private List<Enemy> enemyList; //存储战斗中的敌人

    /// <summary>
    /// 加载敌人资源
    /// </summary>
    /// <param name="id">管卡id</param>
    public void LoadRes(string id)
    {
        /*Id Name    EnemyIds PosId 关卡名称    敌人Id的数组 所有怪物的位置
        10001   1   10001   0,0,0
        10002   2   10001 = 10001 0,0,0 = 0,0,1
        10003   3   10001 = 10002 = 10003   3,0,1 = 0,0,1 = -3,0,1*/

        enemyList = new List<Enemy>();

        //读取关卡表
        Dictionary<string, string> levelData = GameConfigManager.Instance.GetLevelById(id);

        Debug.Log(levelData);

        //敌人id信息
        string[] enemyIds = levelData["EnemyIds"].Split('=');

        string[] enemyPos = levelData["Pos"].Split('=');

        for(int i = 0; i< enemyIds.Length; i++)
        {
            string enemyId = enemyIds[i];
            string[] posArr = enemyPos[i].Split(',');

            //敌人位置
            float x = float.Parse(posArr[0]);
            float y = float.Parse(posArr[1]);
            float z = float.Parse(posArr[2]);

            //根据敌人id获得单个的人信息
            Dictionary<string, string> enemyData = GameConfigManager.Instance.GetEnemyById(enemyId);

            GameObject obj = Object.Instantiate(Resources.Load(enemyData["Model"])) as GameObject; //从资源路径加载对应的敌人模型

            Enemy enemy = obj.AddComponent<Enemy>();//添加敌人脚本

            enemy.Init(enemyData);//存储敌人信息

            //存储到集合
            enemyList.Add(enemy);

            obj.transform.position = new Vector3(x, y, z);
        }
    }
}
