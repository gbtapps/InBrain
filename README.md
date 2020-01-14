# InBrain（Unity）のソース管理 

## ローカルにクローンする方法

(Sourcetreeをインストールする手順で、Gitインストール、Attlasiaアカウント（Bitbucket）作成も含まれるようなので下記不要）  
~~1. Gitをインストールする  
   [(Git download & install 右側の画面っぽいところのボタンから)](https://git-scm.com/)    
1. Bitbucketにアカウントを作成する  
　  ** 要注意！ ** Googleの認証機能は使わない！Gmailでも、アドレスとパスワードを手入力して登録すること。  
   [(Bitbucket)](https://bitbucket.org/) ~~  

1. Sourcetreeをインストールする  
~~(インストール時にBitbucketのアカウントが必要）~~  
[(Sourcetreeのページ)](https://www.sourcetreeapp.com/)  
[(インストール手順は、このページがわかりやすそう)](https://tracpath.com/bootcamp/learning_git_sourcetree.html)    
SSHキーの読み込みについては、ソースの修正に必須なので、別途共有します。  
[(ここ)](https://tracpath.com/bootcamp/learning_git_sourcetree.html#id4)まで来たら、別手順に。  
Bitbacketからソースをクローンして、ローカルPCにソースのコピーを作ります。
Sourcetreeのタブを追加して、Remoteを押して、InBrainが表示されたらCloneを押す。
このコピーがUnityのプロジェクトの実態です。ここに修正を加えていきます。  
加えられた修正は、Sourcetreeが把握します。開発者はSourcetreeを使って、修正内容を、Bitbacketのソースに反映させます。

