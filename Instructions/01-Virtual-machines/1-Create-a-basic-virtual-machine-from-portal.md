# 01/1 - Create a virtual machine in the portal

In this walkthrough, we will create a virtual machine in the Azure portal connect to it via Remote Desktop Protocol (RDP), install the web server role and test.

# Task 1: Create the virtual machine

1. Sign-in to the Azure portal: https://portal.azure.com

2. From the Top search bar in the Portal Menu, search for and select Virtual machines, and then click `+Create`, and choose `+Azure virtual machine` from the drop down.

3. On the `Basics` tab, fill in the following information (leave the defaults for everything else):
  
    ##### Project details
    ![project-details](/assets/projectdetails.PNG)
    
    On this first section, you will assign your virtual machine to a `subscription` and to a `resource group`. If the resource group doesn't exist, you can create one.
    
    **You can use the following values:**
    | Settings            | Values                       |
    | ------------------- | ---------------------------- |
    | Subscription        | **select your subscription** |
    | Resource group name | **az-fun-vm-rg**             |

    > At the top of the page, you can see that there are additional sections for `Disk`, `Networking`, `Management` and so on. These sections gives you the ability to create more custom configurations, such as adding additional disks or adding the virtual machine to an existing virtual network, and so on.

    > But in this demo we're going to focus on the elements to create a basic virtual machine

    The next section that we will define is `Instance details` 

    ##### Instance details 
    ![instance-details](/assets/instance-details.PNG)
    
    Here you will give the virtual machine a `name` and pick a `region` that you want to deploy the virtual machine in.

    **You can use the following values:**
    | Settings             | Values                   |
    | -------------------- | ------------------------ |
    | Virtual machine name | **win-portal-vm**        |
    | Region               | **(Europe) West Europe** |

    ###### Availability options
    The next and optional, you can specify any `availability options`, so things like `availability zones` or `availability sets` can be chosen here. Leave it as default for now - `No infrastructure redundancy required`.

    ###### Virtual Machine Image
    Then you'll select a `virtual machine image` from the list of images available in the selected region. We are going to pick a `Windows Server 2019 Datacenter - Gen1` image for this demo purpose.

    | Settings              | Values                                    |
    | --------------------- | ----------------------------------------- |
    | Virtual machine image | **Windows Server 2019 Datacenter - Gen1** |

    ###### Azure Spot instance
    Leave `Run with Azure Spot discount` unchecked. That's a setting that allows Azure to stop and deallocate a virtual machine if Azure needs that compute capacity back for whatever reason.

    ###### Size
    And lastly in this section, for `size` pick a smaller virtual machine size from the list of VM sizes available for selected region, since you don't need a ton of capacity for this demo purpose.
    **You can use the following values:**
    | Settings | Values           |
    | -------- | ---------------- |
    | Size     | **Standard_B1ms** |

    the next section that you will define is `administrator account` 

    ##### Administrator account
    ![administrator-account](/assets/administrator-account.PNG)

    Here you will define required information for administrative access to the virtual machine. For Windows, this is a `username` and `password`, and on Linux it can be a suername or password or also an SSH public key. We are going to focus on Windows for this demo.

    **You can use the following values:**
    | Settings                       | Values           |
    | ------------------------------ | ---------------- |
    | Administrator account username | **azureuser**    |
    | Administrator account password | **Password%1234** |

    >remember your account information, because you will need it later to log in via RDP.

    The next section to cover is `Inbound port rules`

    ##### Inbound port rules
   
    ![inbound-port-rule](/assets/inbound-port-rule.PNG)

    You will need to define some `inbound port rules` for accessing this virtual machine. 

    In default configuration, this virtual machine will get a `public IP address` for accessing this VM over the internet, but by default access from outside the virtual network or the internet is not permitted. Adding inbound port rules here is an easy way for us to permit network access into this virtual machine by specifying which inbound ports we want to open up. Selecting an inbound port here will add a rule to the `network security group`, permitting access from any IP address on the specified port. 

    Since this is a Windows virtual machine and we want to access it remotely, we will open up RDP on port 3389. This will allow RDP access into this virtual machine on that port from any IP address, and also we will open port 80 for HTTP, it will allow us to browse from browser by our IP Address.
  

4. Leave the remaining values on the defaults and then click the Review + create button at the bottom of the page.

5. Once Validation is passed click the Create button. It can take anywhere from five to seven minutes to deploy the virtual machine.

6. You will receive updates on the deployment page and via the Notifications area (the bell icon in the top menu bar).


# Task 2: Connect to the virtual machine
In this task, we will connect to our new virtual machine using RDP (Remote Desktop Protocol).

1. Search for `win-portal-vm` (or other name that you used during the creation of vm) and select your newly created virtual machine.

>You could also use the `Go to resource` link on the deployment page or the link to the resource in the `Notifications` area.

2. On the virtual machine Overview blade, click `Connect` button and choose `RDP` from the drop down.
![vm-connect](/assets/vm-connect.jpeg)

3. On the `Connect to virtual machine` page, keep the default options to connect with the public IP address over port 3389 and click `Download RDP File`.

4. `Open` the downloaded RDP file (located on the bottom left of your lab machine) and click `Connect` when prompted.
![rdp-prompt](/assets/rdp-prompt.PNG)

5. On the `Windows Security` window select `More choices`, then select `Use a different account`
 and sign in using the Admin Credentials you used when creating your VM `azureuser` and the password `Pa$$w0rd1234`.
 ![enter-your-credential-prompt](/assets/enter-your-credential-prompt.PNG)

**Congratulations!** You have deployed and connected to a Virtual Machine running Windows Server.


# Task 3: Install the web server role and test

In this task, install the Web Server role on the server on the Virtual Machine you just created and ensure the default IIS welcome page will be displayed.

1. In the virtual machine, launch PowerShell by searching **PowerShell** in the search bar, when found right click **Windows PowerShell** to **Run as administrator**.

 ![powershell](/assets/powershell.png)

 2. In PowerShell, install the **Web-Server** feature on the virtual machine by running the following command. 

    ```PowerShell
    Install-WindowsFeature -name Web-Server -IncludeManagementTools
    ```
  
3. When completed, a prompt will state **Success** with a value **True**. You do not need to restart the virtual machine to complete the installation. Close the RDP connection to the VM by clicking the **x** on the blue bar at the top center of your virtual machine. 

    ![install-windows-feature](/assets/install-windows-feature.png)

4. Back in the portal, navigate back to the **Overview** blade of `win-portal-vm` and, use the **Click to clipboard** button to copy the public IP address of `win-portal-vm`, then open a new browser tab, paste the public IP address into the URL text box, and press the **Enter** key to browse to it.

    ![copy-ip-address](/assets/copy-ip-address.PNG)

5. The default IIS Web Server welcome page will be displayed.

    ![default-iis-webpage](/assets/default-iis-webpage.PNG)

**Congratulations!** You have created a new VM running a web server that is accessible via its public IP address. If you had a web application to host, you could deploy application files to the virtual machine and host them for public access on the deployed virtual machine.


**Note**: To avoid additional costs, you can remove this resource group. Search for resource groups, click your resource group, and then click **Delete resource group**. Verify the name of the resource group and then click **Delete**. Monitor the **Notifications** to see verify that the deletion completed successfully. 
