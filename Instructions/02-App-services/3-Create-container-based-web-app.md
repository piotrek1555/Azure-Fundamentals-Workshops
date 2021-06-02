
# 3 - Create a Web App

In this walkthrough, we will create a web app that runs a Docker container. The Docker container contains a Welcome message.

Azure App Service are actually a collection of four services, all of which are built to help you host and run web applications. The four services (Web Apps, Mobile Apps, API Apps, and Logic Apps) look different, but in the end they all operate in very similar ways. Web Apps are the most commonly used of the four services, and this is the service that we will be using in this lab.

# Task 1: Create a Web App

In this task, you will create an Azure App Service Web App. 

1. Sign-in to the [Azure portal](http://portal.azure.com/). 

2. From the **All services** blade, search for and select **App Services**, and click **+ Create**

3. On the **Basics** tab of the **Create Web App** blade, specify the following settings (replace **xxxx** in the name of the web app with letters and digits such that the name is globally unique). Leave the defaults for everything else. 

    | Setting          | Value                    | Comments                                                    |
    | ---------------- | ------------------------ | ----------------------------------------------------------- |
    | Subscription     | **Use default supplied** |                                                             |
    | Resource Group   | **az-fun-web-rg**        | Create a new one                                            |
    | Name             | **az-fun-docker-web-xxxx**   | Name must be unique across all Azure subscriptions          |
    | Publish          | **Docker Container**     |                                                             |
    | Operating System | **Linux**                | We will deploy docker image for Linux OS based app          |
    | Region           | **West Europe**          |                                                             |
    | Linux Plan       | **az-fun-linux-asp**     | Create new plan, name must be unique in your subscription   |
    | Sku and size     | **Free**                 | Later on we will scale up our plan to give it more features |
    
    >**Note** - Remember to change the **xxxx** so that your Web App name is unique.

4. Click **Next > Docker** and configure the container information.  

    | Setting       | Value                        |
    | ------------- | ---------------------------- |
    | Options       | **Single container**         |
    | Image Source  | **Docker Hub**               |
    | Access Type   | **Public**                   |
    | Image and tag | **microsoft/aci-helloworld** |
    
 >**Note** The startup command is optional and not needed in this exercise.

5. Click **Review + create**, and then click **Create**. 

# Task 2: Test the Web App

In this task, we will test the web app.

1. Wait for the Web App to deploy.

2. From **Notifications** click **Go to resource**. 

3. On the **Overview** blade, locate the **URL**. Copy the URL to the clipboard.

    ![docker-webapp-overview](/assets/docker-webapp-overview.PNG)

4. In a new browser window, paste the URl and press enter. The Welcome to Azure Container Instances! welcome message will be displayed.

    ![browse-the-docker-webapp](/assets/browse-the-docker-webapp.PNG)

5. Repeat step 4 a few times, and switch back to the **Overview** blade of your web app and scroll down. You will notice several charts tracking Data In/Out and Requests. You should be able to see corresponding telemetry being displayed in these charts. This includes number of requests and average response time.


>**Note**: To avoid additional costs, you can remove this resource group. Search for resource groups, click your resource group, and then click **Delete resource group**. Verify the name of the resource group and then click **Delete**. Monitor the **Notifications** to see how the delete is proceeding.

Congratultions you successfully created an Azure Container Instance.