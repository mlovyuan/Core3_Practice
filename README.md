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
- appSettings.json(組態設定檔) 裡的設定值可透過`IConfiguration`讀取，一般會到 startup.cs 使用DI機制從建構式取得 IConfiguration 並保存供後續使用。又或是到`ConfigureServices()`採`IOptions<>`方式取得並應用，詳見DepartmentController 或 DepartmentController.cshtml。

```C#
private readonly IConfiguration _configuration;

// 取得 appSettings.json(組態設定檔) 裡的設定值
public Startup(IConfiguration configuration)
{
    _configuration = configuration;

    // 取得 ThisProjectTest 底下 BoldDepartmentEmployeeCount 的值
    // 可與43行對照觀察，此處會是回傳string
    string thisProjectTest = _configuration["ThisProjectTest:BoldDepartmentEmployeeCount"];
}

public void ConfigureServices(IServiceCollection services)
{
    // 透過相依性注入的方式取得 appSettings.json(組態設定檔) 裡"ThisProjectTest"的設定值
    // 可在Controller那邊用IOptions來注入使用
    // 在Razor page使用則為 @inject IOptions<ThisProjectTestOptions> + 變數名稱
    services.Configure<ThisProjectTestOptions>(_configuration.GetSection(key: "ThisProjectTest"));
}
```

- Program.cs可以自訂自己的 appsetings.json file
- View Component的使用牽扯到了它的繼承關係和`@Component.InvokeAsync`的運用，令人驚豔的是它也能藉由Tag Helpers像幾個前端框架一般自訂Tag。View Component比起Partial View的部分更適合撰寫邏輯運算，且生命週期也較Child Controller短。
