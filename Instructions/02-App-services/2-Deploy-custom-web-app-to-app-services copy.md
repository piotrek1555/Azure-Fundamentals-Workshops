
# 02/2 - Deploy custom web app to App Services

In this walkthrough, you will create and deploy a custom .net core web app on Windows App Service Plan. Let's dive in!

>**Note** You will need Visual Studio to follow alone this demo.

# Task 1: Create a Web App

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

In this task you will create custom .net core web app in Visual Studio.

1. Open up visual studio 2019, and hit `Create a new project`
    ![Create-new-project-vs](/assets/Create-new-project-vs.PNG)


2. Search for `asp.net core web app` in the search bar, and select the project template for creating an asp.net core application with razor content.
    ![razer-content-webapp](/assets/razer-content-webapp.PNG)

3. Give it a name for example `WebApplication`, and select the desired folder for your app, click `Next`

4. Leave `Additional information` page as default, and hit `Create`
    | Setting                          | Value                                 | Comments                                           |
    | -------------------------------- | ------------------------------------- | -------------------------------------------------- |
    | Target Framework                 | **.NET Core 3.1 (Long-term support)** |                                                    |
    | Authentication Type              | **None**                              | Create a new one                                   |
    | Configure for HTTPS              | **checked**                           | Name must be unique across all Azure subscriptions |
    | Enable Docker                    | **unchecked**                         |                                                    |
    | Enable Razor runtime compilation | **unchecked**                         |                                                    |

5. Run your application locally, and see if it is working, it should display, the basic web page for selected project template
    ![basic-web-page](/assets/basic-web-page.PNG)


# Task 3: Create deployment files

In this task you will deploy your application to App Services

1. In `Solution Explorer` right click on your app, and select `Publish`
    ![publisg-from-vs](/assets/publisg-from-vs.PNG)

2. Select `Folder` and hit `Next`
    ![publish-from-folder](/assets/publish-from-folder.PNG)

3. Browse for a folder where you want to place your web app files. You can create a new one, for example `publishfiles` on your Desktop, and hit `Finish` button.
    ![publish-files-destination](/assets/publish-files-destination.PNG)

4. Click on `Publish` button, and wait for application Build and `Successfully published on` message appear.
    ![publish](/assets/publish.PNG)

5. Navigate to your folder `publishfiles` and zip all the files. You can name it like you wish, for example `deploymentfiles`
    ![zip-your-files](/assets/zip-your-files.PNG)


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
