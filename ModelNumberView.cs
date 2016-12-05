   GUILayout.Label(" 总面数：" + trianglesCount);
        if (GUILayout.Button("重新统计当前总面数"))
        {
            trianglesCount = 0;
            TransformReset tr = new TransformReset(tranDog);
            foreach (TransformInfo item in tr.TranInfoList)
            {
                if (item.transform.gameObject.activeInHierarchy)
                {
                    MeshFilter mf = item.transform.gameObject.GetComponent<MeshFilter>();
                    if (mf != null)
                    {
                        //计算模型面数


                        int count = mf.mesh.triangles.Length / 3;
                        trianglesCount += count;
                    }
                }

            }
            Debug.Log(" 总面数：" + trianglesCount);
        }
