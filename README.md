# ピンボール

![ゲームシーン](https://raw.github.com/caorol/PinBall/master/gamescene.png)


---
## Unity 起動時に真っ黒になる問題
![画面](https://raw.github.com/caorol/PinBall/master/unityblack.png)

長時間画面が真っ黒になったままになり、数分かかり白転して画面表示も徐々に表示されていく、というような現象です。


### 確認内容
- ネット回線速度
- アンインストールして古いバージョンを入れてみる

### クリーンインストールする
前項「確認内容」で問題が解消しなかった場合は残念ながらクリーンインストールになります。
以下 Unity 関連ファイルを削除して、最新をインストールし直してください。
- Unity.app のパッケージコンテンツ
- /Library/Application Support/Unity
- ~/Library/Logs/Unity


---
## Main Camera の HDR を有効にする
Main Camera の `Allow HDR` にチェック
### アンチエイリアスを切らないといけません
HDR を有効にするとアンチエイリアスを切らないといけませんワーニングが出るのでよしなにします。  
`Edit - Project Settings - Quality` を開いて `High` 以下を選択すればOK

※ アンチエイリアスが切れるので物凄い拡大したら角がギザギザに見えるはず
