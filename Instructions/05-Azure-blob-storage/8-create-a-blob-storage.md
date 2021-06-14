# 05/1 - Create blob storage

In this walkthrough, we will create a storage account, then work with blob storage files.

# Task 1: Create a storage account

In this task, we will create a new storage account. 

1. Sign in to the Azure portal at [https://portal.azure.com](https://portal.azure.com)

2. From the **All services** blade, search for and select **Storage accounts**, and then click **+ Create**. 

3. On the **Basics** tab of the **Create storage account** blade, fill in the following information (replace **XX** in the name of the storage account with letters and digits such that the name is globally unique). Leave the defaults for everything else.

    | Setting              | Value                               |
    | -------------------- | ----------------------------------- |
    | Subscription         | **Leave provided default**          |
    | Resource group       | **az-fun-rg**                       |
    | Storage account name | **azfunsaXX**                       |
    | Location             | **(Europe) West Europe**            |
    | Performance          | **Standard**                        |
    | Replication          | **Locally redundant storage (LRS)** |
    

    **Note** - Remember to change the **XX** so that it makes a unique **Storage account name**

4. Click **Review + Create** to review your storage account settings and allow Azure to validate the configuration. 

5. Once validated, click **Create**. Wait for the notification that the account was successfully created. 

6. From the Home page, search for and select **Storage accounts** and ensure your new storage account is listed.

    ![storage-account-list](/assets/storage-account-list.PNG)

# Task 2: Work with blob storage

In this task, we will create a Blob container and upload a blob file. 

1. Click the name of the new storage account, scroll to the **Blob service** section in the left menu, and then click **Containers**.

2. Click **+ Container** and complete the information. Use the Information icons to learn more. When done click **OK**.


    | Setting             | Value                             |
    | ------------------- | --------------------------------- |
    | Name                | **images**                        |
    | Public access level | **Private (no anonymous access)** |
  

    ![storage-account-images-container.PNG](/assets/storage-account-images-container.PNG)

3. Inside folder with this instruction you can find a `logo.png` file, or search for whatever image you want. 

4. Click on **images** container, and then select **Upload**.

5. Browse for the image file on your local computer. Select it and then select upload.
   
6. Add another image, this time with virtual path. Click on **Upload** button on the **images** container blade, and select from folder for this instruction a file with `new-azure-logo.png` or any other file you want to upload.

7. Click the **Advanced** arrow, search for option to specify `Upload to folder` and pass the virtual folder name, for  example `design` (you can even add a more complex path like for example `design/logo` and so on) leave the default values for the rest of the options, and click **Upload**.

    >**Note**: You can upload as many blobs as you like in this way. New blobs will be listed within the container.

    ![storage-account-image-with-virtual-dir.PNG](/assets/storage-account-image-with-virtual-dir.PNG)
8. Once the files are uploaded, right-click on the each file and notice the options including View/edit, Download, Properties, and Delete. 

9.  Click on the last uploaded image, notice its name, it is the full path, including the virtual directory, click on **Copy URL** icon.
    ![storage-account-image-with-virtual-dir-copy-url.PNG](/assets/storage-account-image-with-virtual-dir-copy-url.PNG)

10. Open new browser tab, and past the URL. You should see the message with info `ResourceNotFound` error. This is because by default public read access to the blob is not enabled.

    ![storage-account-image-resource-not-found](/assets/storage-account-image-resource-not-found.PNG)

# Task 3: Authorize request to blob storage with SAS token

1. Go to your `images` containers in **Storage Account** that you have created earlier, and click on the image, to open its **Properties** blade. Then click on **Generate SAS** button, and then at the bottom of new opened blade click on **Generate SAS token and URL** and copy the generated **Blob SAS token**

    >**Notice** the different options you can choose, things like for example `Permissions`, `start`, and `expiry` date, and even you can specify `Allowed IP addresses` list.

    ![storage-account-image-generate-sas-token](/assets/storage-account-image-generate-sas-token.PNG)

2. Switch to your browser tab with previously encountered error window, add a question mark ".blob.core.windows.net/images/design/new-azure-logo.png`?`" to the end of the URL and then paste the copied **Blob SAS token** after it.
   ![storage-account-image-access-with-sas-token](/assets/storage-account-image-access-with-sas-token.PNG)

3. Remove the token from the url, and check if the error still exist.


# Task 4: Monitor the storage account

1. Return to the storage account blade and click **Diagnose and solve problems**. 

2. Explore some of the most common storage problems. Notice there are multiple troubleshooters here.

3. On the storage account blade, scroll down to the **Monitoring** section and click **Insights**. Notice there is information on Failures, Performance, Availability, and Capacity. Your information will be different.

    ![storage-account-insights-blade.PNG](/assets/storage-account-insights-blade.PNG)


**Congratulations!** You have created a storage account, then worked with storage blobs.

**Note**: To avoid additional costs, you can remove this resource group. Search for resource groups, click your resource group, and then click **Delete resource group**. Verify the name of the resource group and then click **Delete**. Monitor the **Notifications** to see how the delete is proceeding.