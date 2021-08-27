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

![2021-08-18 (1)](https://user-images.githubusercontent.com/60646787/129770683-7c7f2ec4-7596-4a79-b577-521640c96640.png)  
1. New Pull requestからプルリクエストを新規に作成.  
2. 矢印を生やしている方の`compare:`を選択し、自分の作業したブランチ(`fix_0_XXXXXX`)を指定.  
![2021-08-18 (3)](https://user-images.githubusercontent.com/60646787/129771016-2acf68e7-7d7e-4923-b2f8-fbdefc3ed17f.png)  
3. Write欄に`fix #0`と書く.`0`には紐づけたいissue番号が入る. ([参考](https://docs.github.com/ja/issues/tracking-your-work-with-issues/creating-issues/linking-a-pull-request-to-an-issue))  
  - プルリクがマージされると、ここでリンクさせたissueもクローズされます  
4. `Reviewers`に任意のレビュアーを指定(今回は指定しなくてOKです。)  
5. 上記の設定でプルリクを作成  
  
### プルリクエストをマージするまで  
1. レビュアーは`Files changed`から変更点を確認する![2021-08-18 (12)](https://user-images.githubusercontent.com/60646787/129828810-1d19e7f2-19ab-45da-977c-c1b6489dad68.png)    
(Unityは構造上ここのファイルが多くなるので全部に目を通すのは大変そう.Scriptsなど目視で確認可能なところに目を通してみるとよさそう)  
(あるいは手元でブランチをpullしてきて動作確認をする)  
2. 右上の緑のボタン(`Review change`)を選択し、問題があればコメントorなければ`approve`(プルリクを承認)する.  
3. 最後に`approve`した人がマージしましょう. ここでconflictを起こしていたら、無理にマージせずメンバーに相談しましょう.  
  - コードレビューのコメントに対しては修正後にその旨を返信し、レビュアーは問題が解決したらコメントをcloseする.  
4. マージができたら用が済んだissueをcloseし、`git checkout main`→`git pull origin main`で手元のmainブランチを最新の状態にするのを忘れずに.  
