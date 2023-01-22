# 06/1 - Work with Azure DevOps

In this walkthrough, we will create a DevOps project, then we will work with Azure Boards, Azure Repos, and Azure Pipelines to create and deploy our application to Azure App Services with an Scrum way of working.

# Task 1: Create a Azure DevOps Organization

In this task, we will create a new Azure DevOps organization and Project. 

1. **Sign in to Azure DevOps** at [https://azure.microsoft.com/en-us/services/devops/](https://azure.microsoft.com/en-us/services/devops/), and follow the prompts
   
2. From the main portal menu click on the **+ New project** on the top right corner and fill the form.

    | Setting           | Value                 |
    | ----------------- | --------------------- |
    | Project name      | **AzureFundamentals** |
    | Description       | **Leave  empty**      |
    | Visibility        | **private**           |
    | Version control   | **Git**               |
    | Work item process | **Scrum**             |

    ![azure-devops-create-new-project](/assets/azure-devops-create-new-project.PNG)


# Task 2: Work with Azure Boards - Create Tasks

In this task, we will manage our tasks in Azure Boards.

1. On the left pane go to **Azure Boards** and move to **Work Items** tab. Here you will create your task for the rest of the demos.
   
2. Click on **+ New Work Item** and select the **Epic**, fill in the following values

    | Setting             | Value                                                                                                                                                 |
    | ------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------- |
    | Title               | **Business growth**                                                                                                                                   |
    | Description         | **Our business needs to grow. We need a solution that will provide us to a higher level. We need to deliver a new product to meet this requirement.** |
    | Acceptance Criteria | **15 % growth in the next year**                                                                                                                      |
    | Start date          | **Today**                                                                                                                                             |
    | Target Date         | **Today + 1 year**                                                                                                                                    |
    | Priority            | **4**                                                                                                                                                 |
    | Value area          | **Business**                                                                                                                                          |

    ![devops-epic](/assets/devops-epic.PNG)


3. Save Changes and click **<- Back to Work Items**.
4. Click on **+ New Work Item** and select the **Feature**, fill in the following values



    | Setting             | Value                                                                                          |
    | ------------------- | ---------------------------------------------------------------------------------------------- |
    | Title               | **E-commerce application**                                                                     |
    | Description         | **To meet the business requirement for growth, we need to deliver an E-commerce application.** |
    | Acceptance Criteria | **Application needs to have: cart, categories catalog, products catalog, others..**              |
    | Start date          | **Today**                                                                                      |
    | Target Date         | **Today + 0.5 year** (16th December)                                                           |
    | Priority            | **4**                                                                                          |
    | Value area          | **Business**                                                                                   |
    
    ![devops-feature](/assets/devops-feature.PNG)
  
5. Add **Related Work** on the right side of the Work Item form, click **Add an existing work item** as parent

    | Setting            | Value                                                    |
    | ------------------ | -------------------------------------------------------- |
    | Link type          | **Parent**                                               |
    | Work items to link | **Select your Epic type  Work Item for Business growth** |


    ![devops-link-with-parent](/assets/devops-link-with-parent.PNG)

6. Save Changes and click **<- Back to Work Items**. 

7. Click on **+ New Work Item** and select the **Product Backlog Item**, fill in the following values.
    
    | Setting             | Value                                                        |
    | ------------------- | ------------------------------------------------------------ |
    | Title               | **Basic Web App**                                            |
    | Description         | **Create basic .net core application on the azure**          |
    | Acceptance Criteria | **.net core web app deployed onto Azure App Service**        |
    | Value area          | **Architectural**                                            |
    | Related Work        | **Add link to parent- previously created Feature Work Item** |

    ![devops-product-backlog-item](/assets/devops-product-backlog-item.PNG)

8. Save Changes and click **<- Back to Work Items**. 
9. Add four more Work Items of Type Task
   1.  Create Azure Repo for e-commerce application
        - **Description**: Create a repo with a name `ecommerce.webapp`
        - Link with parent **Basic Web App**
   2.  Create .net core web app
        - **Description**: Create the basic .net core web application from a template in VS Code
        - Link with parent **Basic Web App**
   3.  Create Azure Build pipeline
        - **Description**: Create the basic Build Pipeline for .net core web application
        - Link with parent **Basic Web App**
   4.  Create Azure Release pipeline
        - **Description**: Create the Release Pipeline for .net core web application
        - Link with parent **Basic Web App**


   
    It should look similar to this
    ![devops-workitems-view](/assets/devops-workitems-view.PNG)


# Task 3: Work with Azure Boards - Manage your tasks in Backlog

1. Add two more `Product backlog items`
   1. with title **Login with AAD** link it to Feature as parent
   2. with title **Documentation** link it to Feature as parent
2. Go to **Backlog** and manage the priority of your tasks by drag and drop them
   1. Most important for now is creating a Basic App, so it should got at the top of **Backlog**, make sure it is at the top.

# Task 4: Work with Azure Boards - Work in Sprints, implement Scrum
Now you will plan your `Sprint`

1. Go to **Backlog**
   - Move your **Basic Web App** Work Item to **Sprint 1 `current`**
   - Move your **Login with AAD** Work Item to **Sprint 1 `current`**
   - Move your **Documentation** Work Item to **Sprint 2**
   
   ![devops-plan-sprint](/assets/devops-plan-sprint.PNG)

# Task 5: Work with Azure Boards - Start your work in Sprint


1. Go to `Sprints` select your `AzureFundamentals` team, and switch from **Backlog** to **Taskboard**, next drag adn drop your first task (Create Azure Repo for e-commerce application) to `In Progress` column

    ![devops-start-work](/assets/devops-start-work.PNG)

# Task 6: Work with Azure Repos - Create Code Repository

1. Go to Azure **Repos**, on the top, expand the AzureFundametnals and select **+ New repository**, name it as it was described in your first task `ecommerce.webapp`, and add `gitignore` **VisualStudio**, click **Create**
2. You can go back to your Sprint Task board, and move your task to **Done** column, you have complete your work item task.

# Task 7: Work with Azure Repos - Clone Code Repository

1. Start your next work item on sprints **Create .net core web app** by moving it to the `In-progress` column
2. Expand options, and click **New branch...**
   
   ![devops-new-branch](/assets/devops-new-branch.PNG)
3. Name your branch with the following convention: `feature/<task-id>-name-of-the-task`
   
   ![devops-new-branch2.PNG](/assets/devops-new-branch2.PNG)
4. Go to your **Repository**, and click on **Clone** 
   
    ![devops-clone1](/assets/devops-clone1.PNG)
5. Copy the url 
   
    ![devops-clone2](/assets/devops-clone2.PNG)
6. On your local machine, create a folder, name it like you wish, next open it command line, and type `git clone <paste your url>` and hit enter. Your repository should be cloned.
7. Move to the cloned folder by typing `cd ecommerce.webapp` in terminal
8. Create new dotnet web app by typing `dotnet new webapp` in terminal
9. Open it in VS Code
10. TODO

# Task 8: Create WebApp
In this task, you will create an Azure App Service Web App. 
You can use the web app created in previous demo. If you don't have one or want to create a new one, follow the instructions in **Task 1** in this manual: [App-services](https://github.com/piotrek1555/Azure-Fundamentals-Workshops/blob/main/Instructions/02-App-services/1-Deploy-custom-web-app-to-app-services-in-vs-code.md).


# Task 9: Build Pipeline
1. Go to Azure **Pipelines**, on the top right, click **New pipeline**, click **Use the classic editor** at the bottom
![image](https://user-images.githubusercontent.com/51710476/211810580-c42e3543-0c53-401c-b358-c1c7b8e387a1.png)

2. Select **Azure Repos Git**, select your project, repository and selet **main** branch from the **Default branch for manual and scheduled builds**. Click **Continue**.
![image](https://user-images.githubusercontent.com/51710476/211836520-03c4e59d-f69b-4b2a-8dd3-e01d8411dd1a.png)

3. Click
![image](https://user-images.githubusercontent.com/51710476/211836395-678e763e-5eeb-4a0e-8d30-cff9e0e5847a.png)

4. Set name as **ecommerce.webapp-CI** and select **windows-latest** in the Agent Specification dropdown
![image](https://user-images.githubusercontent.com/51710476/211893687-26646d19-c194-4833-8acc-59cce5bf7a4b.png)

5. Switch to **Triggers** tab, check **Enable continuous integration** checkbox. In **Branch filters**, make sure `Inlude` is selected in the **Type** dropdow menu and `main` is selected in the **Branch specification** dropdown menu
![image](https://user-images.githubusercontent.com/51710476/211894156-f26dcbb6-51a1-4308-91b5-7bcabab48485.png)

6. Click **Save & queue**, select **Save** from dropdown menu, and click **Save** in the new window that appears

7. Go to pipelines to view your newly created pipeline
![image](https://user-images.githubusercontent.com/51710476/211896490-e1b3c1df-4640-4113-bc4a-05bdb9d34e23.png)

# Task 10: Relese Pipeline
1. Go to Azure **Pipelines** -> **Releases**, click **+ New** and select **New release pipeline** from the dropdown menu
![image](https://user-images.githubusercontent.com/51710476/211897227-7dcb55c9-94ec-46e0-8fc8-b3b28b291d74.png)
2. ...Select template
![image](https://user-images.githubusercontent.com/51710476/211898868-14ec54c2-ac53-4606-8beb-6ba8cce91b15.png)

3.Fill in fields
![image](https://user-images.githubusercontent.com/51710476/211900377-4bd78aa8-9c84-4eb3-b893-a708385d8135.png)

4. Go to Pipeline tab, clcik **Add an artifact**
![image](https://user-images.githubusercontent.com/51710476/211900612-4e6d0fb3-eefd-4b2a-b42a-611633b8d8be.png)

5. select Build, Project, Source, select Latest, click **Add**
![image](https://user-images.githubusercontent.com/51710476/211900910-a6904262-43fd-4db8-be7b-980fff1bf325.png)

6. Click thunderbolt icon
![image](https://user-images.githubusercontent.com/51710476/211901073-cbb3b406-4785-4a8b-82ee-0db60e150de4.png)

7.Check checkbox, click Save and then click **Save** in the new window that appears
![image](https://user-images.githubusercontent.com/51710476/211901546-34dcdec5-07c9-4cd0-a43f-db1582d803ea.png)


**Congratulations!** You have created azure CI/CD pipeline.

>**Note**: To avoid additional costs, you can remove this resource group. Search for resource groups, click your resource group, and then click **Delete resource group**. Verify the name of the resource group and then click **Delete**. Monitor the **Notifications** to see how the delete is proceeding.