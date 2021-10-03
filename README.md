# unity-circle-project

バージョン
**2019.4.29f1(3D)**

### 作業手順

#### プロジェクトをクローンする
以下のコマンドをファイルを作成したい場所で入力する。　　※この後もこの場所は覚えておく必要があります！

`git clone https://github.com/KazukiOtomo/unity-circle-project.git`  
  
 #### ブランチを切る
**※先に自分の名前のIssueをGithubで作りましょう！**

クローンしたリポジトリに移動して、 
  
`git branch`  
で自分が今いるブランチを確認する.  （最初はmainにいるはず）

`git checkout -b fix_0_大友`  
0にはissue番号、`大友`には任意の名前を記述.  
でissueに対応するブランチを作成し移動した状態になる.  
(ここでもう一度`git branch`をすると移動していることを確認できます.  
例:  
```
$ git branch  
  fix_6_get_coordinates_on_player  
* fix_7_camera_follows_player // 現在地  
  main  
```  
)

#### 自分のブランチで行った変更をcommit&pushする

作業が終わったら**Unityプロジェクトを一度閉じてから**、コミットしてプッシュしましょう.  
以下のコマンドを順次実行する  
  
`git pull origin main`

`git add .`  

`git commit -m "XXXの機能を実装した"`  

`git push origin fix_0_XXXXXX`  
  
### プルリクエストを作る 
  
### プルリクエストをマージする

