# Core3_Practice

### 01
---
- startup.cs是設定**註冊服務**的地方，其中ConfigureServices function可用來**添加DI(相依性注入)服務**，Configure function是pipeline對其內部middleware的設定處，且各middleware的順序有其意義。
- wwwroot放置靜態資源。
- 若要載入前端的外部程式庫，可以使用「用戶端程式庫」來新增(也可自己新增npm的json檔案來安裝)，後端的外部程式庫則是使用NuGet。(使用VS2019)
- 想要將靜態資源bundle在一起，可藉由NuGet安裝BuildBundlerMinifier套件，並自己新增**bundleConfig.json**來處理。

```
{
    // outputFileName是bubdle後的檔案路徑+名稱
    "outputFileName": "wwwroot/css/all.min.css",
    // inputFiles是要bundle的檔案
    "inputFiles": [
      "wwwroot/css/site.css",
      "wwwroot/lib/bootstrap/dist/css/bootstrap.min.css"
    ],
    // 是否要進行壓縮
    "minify": { "enabled": true }
}
```
<br>
<br>


### 02
---
- 過去多數的Html Helpers => Core的Tag Helpers，Views/_ViewImports添加Tag Helpers。
- asp-route傳遞的value 和 method(action)要承接的參數名要一樣。
