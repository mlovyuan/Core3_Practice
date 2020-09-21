# Core3_Practice

### 01   ASP.NET Core入門設定
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


### 02   ASP.NET Core MVC練習
---
- 過去多數的Html Helpers => Core的Tag Helpers，Views/_ViewImports_ 添加Tag Helpers。
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

<br>
<br>


### 03   ASP.NET Core Razor Page練習
---
- Razor Page 與 MVC 最大的差別在於前者可以將資料、Html，商業邏輯全部寫在同個頁面上，而後者將各項細節拆開編寫，增加了複雜性。
- Razor Page一般會將其資料存放於**Pages_資料夾**內，而網址列上路由的呼叫方式也與MVC相似，變化不大。
- 新增項目的Razor Page和Razor View不同之處在於前者有內建`PageModel`可以使用，可藉由`@page`、`@model`來呼叫。
- Razor Page的Tag Helpers使用方式會與MVC有部分差異。

<br>
<br>


### WebAPI+Vue_OnlineShop 
---
- 欲行駛前後端分離架構，需先確認前後端傳輸與接收的資料格式。
- 在前端Vue.js框架下，靜態資源一般會存入到static資料夾內，而src資料夾內則放置撰寫前端頁面的檔案，若要使用某些套件於全局，可於main.js中，採`protype`的方式套用。
- Vue.js的`<script>`中，同樣要注意`this`的調用，`<style scoped>`代表該css設計是專門給定當下頁面Vue的DOM所使用的。
- 若要跳轉到其他頁面，HTML可使用`<router-link :to="要跳轉的Vue頁面和網址形式">...</router-link>`的tag，`<script>`可使用`this.$router.push("要跳轉的Vue頁面");`。
- v-model可搭配watch監聽變量，而watch中會將欲監聽的變量其function也需同名才可監聽的到。
- `this.$route.query.id`取得上個頁面網址上的參數(ex: ?id=2)。
- 因前後端分離，port不同，傳輸資料會有跨域問題，此時可在後段的startup.cs註冊跨域服務，controller中也要加入中也要加入`[EnableCors("註冊的名字")]`才行。
- 後端controller內的action想獲取前端傳入api的參數，其名稱需一致，像api參數為?productid=10，後端action的形參也要命名為productid才可接收到。

<br>
<br>


### WebAPI+Vue_OnlineShop02
---
- 此次練習，後端採用code first方式開發，頁面以手機畫面做設計呈現。
- 實作商品搜尋與排序的功能。
- 實作商品頁與購物車以tab方式呈現。
- code first除了Entities要自己輸入外，`Startup.cs`也需要加入對應的服務。
- 理論上方法可以多載，但當參數進入路由後，因多載的關係會導致無法判斷前端傳遞過來的參數（ex：型別不同）應該交由哪個方法執行，因此建議在多載方法上方重新定義路由位置，可參考`ProductsController.cs`的`GetProducts`方法Attribute，而單個方法想於同個controller內能因不同路由呼叫方式被執行，也可參考`GetProducts`方法上方的Attribute。
- 注意！WebAPI傳往前端的資料經過axios其內各屬性首字母會被轉換為小寫。

<br>
<br>


### WebAPI+Vue_RecruitmentPage(未完成)
---
- 本次練習採Db first，指令為`Scaffold-DbContext "Data Source=(localdb)\MSSQLLocalDB;database=XXX;" Microsoft.EntityFrameworkCore.SqlServer -O Entities`。
- 使用Swagger套件 _API文件產生器_ 進行文件撰寫，其中`AddSwaggerGen`用作取得API規格並產生Swagger Document物件，`UseSwagger`和`UseSwaggerUI`分別為加入至Middleware後，可從URL查看Swagger Document，以及UI介面上的美化。
- 初步了解DB適合的設計模式。
  - Singleton(單例模式)：單例模式就是保證在整個應用程序的生命週期中，任何時刻該類只有一個實體。(適用於過去的EF，CallContext)(code待補)
  - Scoped(線程內唯一)：每個請求(Request)產生後都會重新new一個新的實體。(適用於.NET Core，原因在於開方時若前端同時呼叫後端多個方法時才不會因為Db不是各自獨立運行而卡住出錯)
  - Transient：每次注入時，都重新new一個新的實體。(目前所學不在DB考慮)
