# 2 - Create a VM with the CLI

In this walk-through, we will configure the Cloud Shell, use Azure CLI to create a resource group, virtual machine, and we will run some commands to manage the vm, after all you will connect to remote desktop.

# Task 1: Configure the Cloud Shell

In this task, we will configure Cloud Shell, then use Azure CLI to create a resource group and a virtual machine.  

1. Sign in to the [Azure portal](https://portal.azure.com).

2. From the Azure portal, open the **Azure Cloud Shell** by clicking on the icon in the top right of the Azure Portal.

    ![cloud-shell](/assets/cloud-shell.PNG)
   
3. In the Welcome to Azure Cloud Shell dialog, when prompted to select either **Bash** or **PowerShell**, select **Bash**. 

4. A new window will open stating **You have no storage mounted**. Select **advanced settings**.

5. In the advanced settings screen, fill in the following fields, then click Create Storage:
    - Resource Group: **Create new resource group**
    - Storage Account: Create a new account a use a globally unique name (ex: cloudshellstoragemystorage)
    - File Share: Create a new one and name it cloudshellfileshare


# Task 2: Use CLI to create a virtual machine

In Cloud Shell enter the command below and make sure that each line, except for the last one, is followed by the backslash (`\`) character. If you type the whole command on the same line, do not use any backslash characters. 

```sh
# Create a resource group if needed.
az group create \
    --name "az-fun-vm-rg" \
    --location "westeurope"
```

```sh
#Creating a Windows Virtual Machine
az vm create \
    --resource-group "az-fun-vm-rg" \
    --name "win-cli-vm" \
    --image "win2019datacenter" \
    --admin-username "azureuser" \
    --admin-password "Pa$$w0rd1234" 
```

**Note**: The command will take 2 to 3 minutes to complete. The command will create a virtual machine and various resources associated with it such as storage, networking and security resources. Do not continue to the next step until the virtual machine deployment is complete. 

```sh
#Open RDP for remote access, it may already be open
az vm open-port \
    --resource-group "az-fun-vm-rg" \
    --name "win-cli-vm" \
    --port "3389"
```

5. When the command finishes running, in the browser window, close the Cloud Shell pane.

6. In the Azure portal, search for **Virtual machines** and verify that **win-cli-vm** is running.

    ![vm-status](/assets/vm-status.PNG)


# Task 3: Execute commmands in the Cloud Shell

In this task, we will practice executing CLI commands from the Cloud Shell. 

1. From the Azure portal, open the **Azure Cloud Shell** by clicking on the icon in the top right of the Azure Portal.

2. Ensure **Bash** is selected in the upper-left drop-down menu of the Cloud Shell pane.

3. Retrieve information about the virtual machine you provisioned, including name, resource group, location, and status. Notice the PowerState is **running**.

    ```sh
    # Retrieve information about the virtual machine
    az vm show \
        --resource-group "az-fun-vm-rg" \
        --name "win-cli-vm" \
        --show-details \
        --output "table" 
    ```

4. Stop the virtual machine. Notice the message that billing continues until the virtual machine is deallocated. 

    ```sh
    # Stop the virtual machine
    az vm stop \
        --resource-group "az-fun-vm-rg" \
        --name "win-cli-vm"
    ```

5. Verify your virtual machine status. The PowerState should now be **stopped**.

    ```sh
    # Retrieve information about the virtual machine
    az vm show \
        --resource-group "az-fun-vm-rg" \
        --name "win-cli-vm" \
        --show-details \
        --output "table" 
    ```

6. To start your machine type following command
   
    ```sh
    az vm stop \
        --resource-group "az-fun-vm-rg" \
        --name "win-cli-vm"
    ```

7. Open the RDP port
    
    ```sh
    #Open RDP for remote access, it may already be open
    az vm open-port \
        --resource-group "az-fun-vm-rg" \
        --name "win-cli-vm" \
        --port "3389"
    ```

# Task 4: Connect to the virtual machine
In this task, we will connect to our new virtual machine using RDP (Remote Desktop Protocol).


1. Search for `win-cli-vm` (or other name that you used during the creation of vm) and select your newly created virtual machine.

>You could also use the `Go to resource` link on the deployment page or the link to the resource in the `Notifications` area.

2. On the virtual machine Overview blade, click `Connect` button and choose `RDP` from the drop down.
![vm-connect](/assets/vm-connect.jpeg)

3. On the `Connect to virtual machine` page, keep the default options to connect with the public IP address over port 3389 and click `Download RDP File`.

4. `Open` the downloaded RDP file (located on the bottom left of your lab machine) and click `Connect` when prompted.
![rdp-prompt](/assets/rdp-prompt.PNG)

5. On the `Windows Security` window select `More choices`, then select `Use a different account`
 and sign in using the Admin Credentials you used when creating your VM `azureuser` and the password `Pa$$w0rd1234`.
 ![enter-your-credential-prompt](/assets/enter-your-credential-prompt.PNG)

**Congratulations!** You have configured Cloud Shell, created a virtual machine using Azure CLI, practiced with Azure CLI commands, and connected to a Virtual Machine running Windows Server.

>**Note**: To avoid additional costs, you can remove this resource group. Search for resource groups, click your resource group, and then click Delete resource group. Verify the name of the resource group and then click Delete. Monitor the Notifications to see how the delete is proceeding. You can do it also with cli `az group delete --name "az-fun-vm-rg"`


