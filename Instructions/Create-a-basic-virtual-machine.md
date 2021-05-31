# 01 - Create a virtual machine in the portal

In this walkthrough, we will create a virtual machine in the Azure portal and then connect to it via RDP

# Task 1: Create the virtual machine

1. Sign-in to the Azure portal: https://portal.azure.com

2. From the All services blade in the Portal Menu, search for and select Virtual machines, and then click `+Add`, and choose `+Virtual machine` from the drop down.

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
    | Virtual machine name | **demo-win-vm**          |
    | Region               | **(Europe) West Europe** |

    ###### Availability options
    The next and optional, you can specify any `availability options`, so things like `availability zones` or `availability sets` can be chosen here. Leave it as default for now - `No infrastructure redundancy required`.

    ###### Virtual Machine Image
    Then you'll select a `virtual machine image` from the list of images available in the selected region. We are going to pick a `Windows Server 2019 Datacenter - Gen1` image for this demo purpose.

    | Settings              | Values                                    |
    | --------------------- | ----------------------------------------- |
    | Virtual machine image | **Windows Server 2019 Datacenter - Gen1** |

    ###### Azure Spot instance
    Leave `Azure Spot instance` unchecked. That's a setting that allows Azure to stop and deallocate a virtual machine if Azure needs that compute capacity back for whatever reason.

    ###### Size
    And lastly in this section, for `size` pick a smaller virtual machine size from the list of VM sizes available for selected region, since you don't need a ton of capacity for this demo purpose.
    **You can use the following values:**
    | Settings             | Values                   |
    | -------------------- | ------------------------ |
    | Virtual machine name | **demo-win-vm**          |
    | Region               | **(Europe) West Europe** |

    the next section that you will define is `administrator account` 

    ##### Administrator account
    ![administrator-account](/assets/administrator-account.PNG)

    Here you will define required information for administrative access to the virtual machine. For Windows, this is a `username` and `password`, and on Linux it can be a suername or password or also an SSH public key. We are going to focus on Windows for this demo.

    **You can use the following values:**
    | Settings                       | Values           |
    | ------------------------------ | ---------------- |
    | Administrator account username | **azureuser**    |
    | Administrator account password | **Pa$$w0rd1234** |

    >remember your account information, because you will need it later to log in via RDP.

    The next section to cover is `inbound-port-rule`

    ##### Inbound port rules
    ![inbound-port-rule](/assets/inbound-port-rule.PNG)

    You will need to define some `inbound port rules` for accessing this virtual machine. 

    In default configuration, this virtual machine will get a `public IP address` for accessing this VM over the internet, but by default access from outside the virtual network or the internet is not permitted. Adding inbound port rules here is an easy way for us to permit network access into this virtual machine by specifying which inbound ports we want to open up. Selecting an inbound port here will add a rule to the `network security group`, permitting access from any IP address on the specified port. 

    Since this is a Windows virtual machine and we want to access it remotely, we will open up RDP on port 3389. This will allow RDP access into this virtual machine on that port from any IP address.
  

4. Leave the remaining values on the defaults and then click the Review + create button at the bottom of the page.

5. Once Validation is passed click the Create button. It can take anywhere from five to seven minutes to deploy the virtual machine.

6. You will receive updates on the deployment page and via the Notifications area (the bell icon in the top menu bar).