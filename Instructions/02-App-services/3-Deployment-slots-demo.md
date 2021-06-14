
# 02/3 - Deploy custom web app to App Services

In this walkthrough, you will extend previous exercise (02/2) where you have created and deployed custom web app, with deploying into deployment slots.

>**Note** You will need Visual Studio to follow alone this demo.

# Task 1: Add settings to your application

In this task, you will add some changes to the application. 

1. Open your solution, navigate to the `appsettings.json` file, and  change existing code with the following:

    ```json
    {
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft": "Warning",
          "Microsoft.Hosting.Lifetime": "Information"
        }
      },
      "EnvName": "LocalDev",

      "Level1": {
        "Level2": "Dev setting"
      },

      "EnvironmentVariable": "Set in DEV",

      "ConnectionStrings": {
        "MyDBConnection":
            "Server=tcp:testdbnm.database.windows.net,1433;Initial Catalog=TESTING;Persist Security Info=False; User ID=uname;Password=pword; MultipleActiveResultSets=False;Encrypt=True; TrustServerCertificate=False;Connection Timeout=30;"
      },

      "AllowedHosts": "*"
    }
    ```

2. Navigate to the `Index.cshtml.cs` file, by expanding the `Index.cshtml` under the `Pages` directory, and replace the existing code with following:

    ```cs
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Configuration;

    namespace CustomWebApplication.Pages
    {
        public class IndexModel : PageModel
        {
            private readonly IConfiguration _configuration;

            public IndexModel(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public void OnGet()
            {
                ViewData["EnvName"] = _configuration["EnvName"];
                ViewData["Level2Setting"] = _configuration["Level1:Level2"];
                ViewData["EnvironmentVariable"] = _configuration   ["EnvironmentVariable"];
                ViewData["ConnectionString"] = _configuration.  GetConnectionString("MyDBConnection");
            }
        }
    }

    ```

3. Navigate to `Index.cshtml` file, and paste the following code at the end.

    ```html
    <div class="row">
    	<div class="col-md-12">
    		<h2>Application Settings</h2>
    		<ul>
    			<li><h3>Environment Name:</h3><h4>@ViewData["EnvName"]</h4></   li>
    			<li><h3>Level 2 Setting:</h3><h4>@ViewData["Level2Setting"]</   h4></li>
    			<li><h3>Environment specific variable Setting:</    h3><h4>@ViewData["EnvironmentVariable"]</h4></li>
    		</ul>
    	</div>
    </div>
    <div class="row">
    	<div class="col-md-12">
    		<h2>Connection Strings</h2>
    		<ul>
    			<li><h3>Connection String:</h3><h4>@ViewData["ConnectionString"]</h4></li>
    		</ul>
    	</div>
    </div>

    ```

4. Hit **F5** to run your application locally, and see if it is working, you should see the settings from the `appsettings.json` file are displayed 
   ![app-service-deployment-slots-local-version](/assets/app-service-deployment-slots-local-version.PNG)
    
   >**Note** the values are set to DEV

# Task 2: Configure production deployment slot

In this task you will configure settings for the production slot

1. Go to portal, and navigate to your **App Service** that you have created in the previous exercise.

2. On the **App Service** blade on the left pane in the **Settings** sections select **Configuration**, and add new application settings and Connection strings as follows:

    | Application Setting     | Value       | Comments                                                                     |
    | ----------------------- | ----------- | ---------------------------------------------------------------------------- |
    | Name                    | EnvName     |                                                                              |
    | Value                   | Production  | We want this setting to be production specific value                         |
    | Deployment slot setting | **checked** | We want this setting to not be overridden when we swap with the staging slot |

    | Application Setting     | Value          | Comments                                                                           |
    | ----------------------- | -------------- | ---------------------------------------------------------------------------------- |
    | Name                    | Level1__Level2 | Nested settings needs to follow name convention, and we use 2x `_` for this reason |
    | Value                   | Prod setting   | We want this setting to be production specific value                               |
    | Deployment slot setting | **checked**    | We want this setting to not be overridden when we swap with the staging slot       |

    | Application Setting     | Value               | Comments                                                              |
    | ----------------------- | ------------------- | --------------------------------------------------------------------- |
    | Name                    | EnvironmentVariable |                                                                       |
    | Value                   | Set in Prod         |                                                                       |
    | Deployment slot setting | **unchecked**       | We want this setting be overridden when we swap with the staging slot |
   
    Now let's add **Connection string** setting

    | Connection string Setting | Value                                                                                                                                                                                                                                | Comments                                              |
    | ------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | ----------------------------------------------------- |
    | Name                      | MyDBConnection                                                                                                                                                                                                                    | We will not use Database it is just for demo purpose  |                                                       |
    | Value                     | Server=tcp:testdbnm.database.windows.net,1433;Initial Catalog=PRODUCTION;Persist Security Info=False; User ID=uname;Password=pword; MultipleActiveResultSets=False;Encrypt=True; TrustServerCertificate=False;Connection Timeout=30; |                                                       |
    | Type                      | SQLAzure                                                                                                                                                                                                                             |                                                       |
    | Deployment slot setting   | **checked**                                                                                                                                                                                                                          | We want this setting to stay with the slot after swap |

3. Check the settings and **Save**
   ![app-service-deployment-slots-lconfiguration-prod](/assets/app-service-deployment-slots-lconfiguration-prod.PNG)
   

# Task 3: Create and configure staging deployment slot

In this task you will create and configure settings for the staging slot

1. On the **App Service** blade, navigate to **Deployment slots** under the **Deployment** section and click **Add Slot**

    | Slot Setting        | Value                 | Comments                                                                 |
    | ------------------- | --------------------- | ------------------------------------------------------------------------ |
    | Name                | staging               |                                                                          |
    | Clone settings from | **az-fun-custom-web** | We want to copy the settings and we will configure them in the next step |

2. Navigate to your new site, by selecting it from the list in **Deployment Slots**
   ![app-service-deployment-slots-staging-slot](/assets/app-service-deployment-slots-staging-slot.PNG)
   
3. On the **App Service** blade on the left pane in the **Settings** sections select **Configuration**, and change application settings and Connection strings as follows:

    | Application Setting     | Value       | Comments                                                                     |
    | ----------------------- | ----------- | ---------------------------------------------------------------------------- |
    | Name                    | EnvName     |                                                                              |
    | Value                   | Staging     | We want this setting to be staging specific value                         |
    | Deployment slot setting | **checked** | We want this setting to not be overridden when we swap with the staging slot |

    | Application Setting     | Value           | Comments                                                                           |
    | ----------------------- | --------------- | ---------------------------------------------------------------------------------- |
    | Name                    | Level1__Level2  | Nested settings needs to follow name convention, and we use 2x `_` for this reason |
    | Value                   | Staging setting | We want this setting to be staging specific value                               |
    | Deployment slot setting | **checked**     | We want this setting to not be overridden when we swap with the staging slot       |

    | Application Setting     | Value               | Comments                                                              |
    | ----------------------- | ------------------- | --------------------------------------------------------------------- |
    | Name                    | EnvironmentVariable |                                                                       |
    | Value                   | Set in Staging      |                                                                       |
    | Deployment slot setting | **unchecked**       | We want this setting be overridden when we swap with the staging slot |
   
    Now let's add **Connection string** setting

    | Connection string Setting | Value                                                                                                                                                                                                                             | Comments                                              |
    | ------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------- |
    | Name                      | MyDBConnection                                                                                                                                                                                                                    | We will not use Database it is just for demo purpose  |
    | Value                     | Server=tcp:testdbnm.database.windows.net,1433;Initial Catalog=STAGING;Persist Security Info=False; User ID=uname;Password=pword; MultipleActiveResultSets=False;Encrypt=True; TrustServerCertificate=False;Connection Timeout=30; |                                                       |
    | Type                      | SQLAzure                                                                                                                                                                                                                          |                                                       |
    | Deployment slot setting   | **checked**                                                                                                                                                                                                                       | We want this setting to stay with the slot after swap |

4. Check the settings and **Save**
   ![app-service-deployment-slots-configuration-staging](/assets/app-service-deployment-slots-configuration-staging.PNG)
   

# Task 3: Deploy your app to the staging slot

In this task you will deploy your application to App Services

1. In `Solution Explorer` right click on your app, and select `Publish`
    ![publisg-from-vs](/assets/publisg-from-vs.PNG)

2. Select `Azure` and hit `Next`
    ![publish-to-azure-option](/assets/publish-to-azure-option.PNG)

3. Pick the Azure App Service (Windows) target and hit `Next`
4. It is possible that you will need to login into your subscription. So do it, and next expand your resource group where you have your desired App Service, select the `staging` slot, and click **Finish**
   ![publish-to-azure-finish](/assets/publish-to-azure-finish.PNG)

5. Click on `Publish` button, and wait for application Build and `Successfully published on` message appear.
    ![publish-to-azure](/assets/publish-to-azure.PNG)

6. Browser window should opened up for you, and you should see that your local settings were overridden with `staging` settings, that you have configured in Azure Portal.
    ![publish-to-azure-staging-slot-result](/assets/publish-to-azure-staging-slot-result.PNG)


# Task 3: Swap slots

In this task you will swap slots between the `staging` and the `production` slot.

1. Navigate to your `App Service` **Production** **slot** that you created earlier.
2. Open up your production slot website in new browser tab it should display the previous version of the app
3. Switch back to the `App Service` and navigate to the **Deployment slots**
4. Click on **Swap** and wait until the swapping finish the process.
    ![app-service-deployment-slots-swap.PNG](/assets/app-service-deployment-slots-swap.PNG)

5. Switch back to your browser tab with application, and refresh the page. It should be similar to this: 
   ![app-service-deployment-slots-swap-result.PNG](/assets/app-service-deployment-slots-swap-result.PNG)
   
    >**Note** The EnvironmentVariable didn't change, that means, if you don't check the deployment slot setting in the Configuration settings, then the variable will be overridden only once, during the deployment, so it get the value from the deployment slot configuration, and if you swap slots, then it won't change. 


**Congratulations!** You know how to create and manage deployment slots in App Service!

>**Note**: To avoid additional costs, you can remove this resource group. Search for resource groups, click your resource group, and then click **Delete resource group**. Verify the name of the resource group and then click **Delete**. Monitor the **Notifications** to see how the delete is proceeding.
