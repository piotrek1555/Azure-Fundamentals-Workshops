
# 02/1 - Deploy custom web app to App Services

In this walkthrough, you will create and deploy a custom .net core web app on Windows App Service Plan. Let's dive in!

## Perquisite:
- Make sure, that you  have installed [.NET Core SDK](https://dotnet.microsoft.com/download). The SDK also includes the Runtime.
![net-core-sdk](/assets/net-core-sdk.PNG)
- The [C# extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) from the VS Code Marketplace.

>**Note** You will need Visual Studio Code to follow alone this demo.

# Task 1: Create a Web App in Azure Portal

In this task, you will create an Azure App Service Web App. 

1. Sign-in to the [Azure portal](http://portal.azure.com/). 

2. From the **All services** blade, search for and select **App Services**, and click **+ Create**

3. On the **Basics** tab of the **Create Web App** blade, specify the following settings (replace **xxxx** in the name of the web app with letters and digits such that the name is globally unique). Leave the defaults for everything else. 

    | Setting          | Value                      | Comments                                                  |
    | ---------------- | -------------------------- | --------------------------------------------------------- |
    | Subscription     | **Use default supplied**   |                                                           |
    | Resource Group   | **az-fun-web-rg**          | Create a new one                                          |
    | Name             | **az-fun-custom-web-xxxx** | Name must be unique across all Azure subscriptions        |
    | Publish          | **Code**                   |                                                           |
    | Runtime stack    | **.Net Core 3.1 (LTS)**    |                                                           |
    | Operating System | **Windows**                |                                                           |
    | Region           | **West Europe**            |                                                           |
    | Linux Plan       | **az-fun-win-asp**         | Create new plan, name must be unique in your subscription |
    | Sku and size     | **Standard S1**            |                                                           |
    
    >**Note** - Remember to change the **xxxx** so that your Web App name is unique.
   
4. Click **Review + create**, and then click **Create**. 

5. Navigate to your website by opening it in a new browser Window and pasting url from the `Overview` page.


# Task 2: Create custom .net application

In this task you will create custom .net core web app in Visual Studio Code.
    
1. Create a new folder on your local machine, open it, and type in the file explorer url `cmd` and then hit the enter
    ![cmd-in-file-explorer](/assets/cmd-in-file-explorer.PNG)

2. In the terminal window type command `dotnet new webapp -o CustomWebApplication` and hit enter. It should create for you the .net core web application with default template
    ![net-core-new-webapp](/assets/net-core-new-webapp.PNG)
3. Look into the folder, your application should be there, open it in Visual Studio Code, you might have option for this, like in the following image
    ![opein-in-vs-code](/assets/opein-in-vs-code.PNG)

4. When the project folder is first opened in VS Code:

    - A `Required assets to build and debug are missing. Add them?` notification appears at the bottom right of the window.
    - Select Yes.
    ![vs-code-first-open](/assets/vs-code-first-open.PNG)

5.  Run your application locally by entering the `dotnet run` command in **Terminal** window, and see if it is working by navigating to the url the command will return. 
    ![dotnet-run-command](/assets/dotnet-run-command.PNG)
    - It should display, the basic web page
    ![basic-web-page](/assets/basic-web-page.PNG)


# Task 3: Create deployment files

In this task you will create deployment files that will be needed in order to deploy your application to App Services

1. In `Terminal` window run the `dotnet publish -c Release` command, it will create a publish files in the `bin` folder under the `publish` directory.
    ![dotnet-publish-to-folder](/assets/dotnet-publish-to-folder.PNG)

2. Navigate to your  `bin/Release/net5.0/publish` folder and compress to zip folder all the files. You can name it like you wish, for example `deploymentfiles`
    ![dotnet-publish-zip-your-files.PNG](/assets/dotnet-publish-zip-your-files.PNG)


# Task 3: Deploy Custom .net application to App Services

In this task you will deploy your application to App Services

1. Navigate to your App Service that you created earlier in `Task 1` in the Azure Portal

2. Scroll down to `Development Tools` section, click on `Advanced Tools` and then click on `Go ->` link
   ![advanced-tools](/assets/advanced-tools.PNG)
    This is KUDU Tools, that helps you manage your application.
3. Click on `Tools` and select from the dropdown list `Zip Push Deploy`
    ![zip-push-deploy](/assets/zip-push-deploy.PNG)

4. Drag and drop your zip file in the `/wwwroot` window and wait for deployment ends. At the end, you should see that new files appear
    ![deployment-end](/assets/deployment-end.PNG)

5. Navigate to your previously (at the end of `Task 1`) opened browser window with your web app, and hit refresh, or just browse your application again, you should see that it is successfully deployed, and now there is visible new page from your custom application.
    ![webapp-deployed](/assets/webapp-deployed.PNG)

**Congratulations!** You have create custom application and deploy it to Azure App Service!

>**Note**: To avoid additional costs, you can remove this resource group. Search for resource groups, click your resource group, and then click **Delete resource group**. Verify the name of the resource group and then click **Delete**. Monitor the **Notifications** to see how the delete is proceeding.
