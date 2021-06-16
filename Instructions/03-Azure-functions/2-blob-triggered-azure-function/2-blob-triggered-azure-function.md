# 03/2 - Create Blob triggered Azure Function

In this walkthrough, we will create a Blob triggered Function App to resize the image into different sizes - `extra small`, `small`, and `medium`.

# Task 1: Create a Function app

In this task, we will create a Function app service, if you already have one, you can skip this step and move to **Task 2**.

1. Sign in to the [Azure portal](https://portal.azure.com).

2. In the **Search bar** at the top of the portal, search for and select **Function App** and then, from the **Function App** blade, click **+ Create**.

3. On the **Basic** tab of the **Function App** blade, specify the following settings (replace **xxxx** in the name of the function with letters and digits such that the name is globally unique and leave all other settings with their default values): 

    | Settings          | Value                     |
    | ----------------- | ------------------------- |
    | Subscription      | **Keep default supplied** |
    | Resource group    | **az-fun-func-rg**        |
    | Function App name | **az-fun-func-xxxx**      |
    | Publish           | **Code**                  |
    | Runtime stack     | **.NET**                  |
    | Version           | **3.1**                   |
    | Region            | **West Europe**           |

    >**Note** - Remember to change the **xxxx** so that it makes a unique **Function App name**

4. Click **Review + Create** and, after successful validation, click **Create** to begin provisioning and deploying your new Azure Function App.

5. Wait for the notification that the resource has been created.

6. When the deployment has completed, click Go to resource from the deployment blade. Alternatively, navigate back to the **Function App** blade, click **Refresh** and verify that the newly created function app has the **Running** status. 

    ![function-apps-blade](/assets/function-apps-blade.PNG)

# Task 2: Create a Blob triggered function and test

In this task, we will create the Blob Triggered function to see the name of uploaded file in blob storage.

1. On the **Function App** blade, click the newly created function app. 

2. On the function app blade, in the **Functions** section, click **Functions** and then click **+ Add**.

    ![function-app-add](/assets/function-app-add.PNG)

3. An **Add function** pop-up window will appear on the right. In the **Select a template** section search for and select **Azure Blob Storage trigger**, change Function name to `ImageResize`, and the **Path** to `uploaded/{name}`. Click **Add** 

    ![function-app-add-blobtriggered](/assets/function-app-add-blobtriggered.PNG)

4. On the **ImageResize** blade, in the **Developer** section, click **Code + Test**. 

5. On the **Code + Test** blade, review the auto-generated code and note that the code is designed to run an Blob triggered request and log information. Also, notice the function returns a message with a uploaded file name.

    ![function-app-blobtriggered-code](/assets/function-app-blobtriggered-code.PNG)

6. Expand the **Logs**
    ![function-app-expand-the-logs](/assets/function-app-expand-the-logs.PNG)

7. Open a new browser tab and navigate to Azure Portal. Find your **Function Apps** **resource group** and open the storage account service associated with it.

    ![function-app-resourcegroup-storageaccount](/assets/function-app-resourcegroup-storageaccount.PNG)

8. On the left pane, select the **Containers**, click on **+ Container** give it a name `uploaded`, and hit **Create**

    ![function-app-create-uploaded-container](/assets/function-app-create-uploaded-container.PNG)

9. Open newly created **Container** hit the **Upload** button at the top, **check** the **overwrite checkbox** and **upload** an image, you can use the one provided with this instruction.


    ![function-app-upload-image-with-overwrite](/assets/function-app-upload-image-with-overwrite.PNG)

10.  When you hit **upload**, your function will be triggered by uploaded file. Switch to your browser tab with Function and look into logs, it should display log info that the new file was processed.
    ![function-app-blobtriggered](/assets/function-app-blobtriggered.PNG)


# Task 3: Implement resize functionality

In this task, we will implement the resize functionality, we will add 3 **outputs** for 3 different sizes - `extra-small`, `small`, and `medium`

1. On the **ImageResize** blade, in the **Developer** section, click **Integration**, and click on **+ Add output** on the `Outputs` box with the values below, and then hit **OK**
    
    | Settings                   | Value                      |
    | -------------------------- | -------------------------- |
    | Binding Type               | **Azure Blob Storage**     |
    | Blob parameter name        | **imageExtraSmall**        |
    | Path                       | **extra-small/esm-{name}** |
    | Storage account connection | **AzureWebJobsStorage**    |

    ![function-app-add-output](/assets/function-app-add-output.PNG)

    Repeat this step two more times with following values:
    - Output 2:

    | Settings                   | Value                   |
    | -------------------------- | ----------------------- |
    | Binding Type               | **Azure Blob Storage**  |
    | Blob parameter name        | **imageSmall**          |
    | Path                       | **small/sm-{name}**     |
    | Storage account connection | **AzureWebJobsStorage** |

    - Output 3:

    | Settings                   | Value                   |
    | -------------------------- | ----------------------- |
    | Binding Type               | **Azure Blob Storage**  |
    | Blob parameter name        | **imageMedium**         |
    | Path                       | **medium/md-{name}**    |
    | Storage account connection | **AzureWebJobsStorage** |

2. To make it possible to resize images, we need to use external library, for example the `SixLabors.ImageResize`, you can add it by uploading the `function.proj` file to the Function. Navigate to **Code + test** tab, hit upload button, and search in instruction for this exercise file `function.proj`
    ![function-app-upload-function-proj-file](/assets/function-app-upload-function-proj-file.PNG)

3. Switch to `function.proj` file, by expanding the dropdown list in the bradcrumbs 
   ![function-app-navigate-to-function-proj-file](/assets/function-app-navigate-to-function-proj-file.PNG)
4. Paste the following code, and hit **Save**
   ```xml
    <Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
        <TargetFramework>netstandard2.0</TargetFramework>
    </PropertyGroup>

    <ItemGroup>
            <PackageReference Include="SixLabors.ImageSharp" Version="1.0.3" />
    </ItemGroup>
    </Project>
   ```
   
   ![function-app-pastes-proj-code](/assets/function-app-pastes-proj-code.PNG)

   You should see in **Logs**, that the function respond to the changes, and restore the necessary packages for your application
   ![function-app-saved-proj](/assets/function-app-saved-proj.PNG)

5. Switch to `run.csx` file, add resize functionality by pasting the following code into function editor, and hit **Save**.

    ```cs
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.Azure.WebJobs;
    using SixLabors.ImageSharp;
    using SixLabors.ImageSharp.Formats;
    using SixLabors.ImageSharp.PixelFormats;
    using SixLabors.ImageSharp.Processing;

    public static void Run(Stream myBlob, string name, Stream imageExtraSmall, Stream imageSmall, Stream imageMedium, ILogger log)
    {
        log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");

        IImageFormat format;

        using (Image<Rgba32> input = Image.Load<Rgba32>(myBlob, out format))
        {
            ResizeImage(input, imageSmall, ImageSize.Small, format);
        }

        myBlob.Position = 0;
        using (Image<Rgba32> input = Image.Load<Rgba32>(myBlob, out format))
        {
            ResizeImage(input, imageMedium, ImageSize.Medium, format);
        }

        myBlob.Position = 0;
        using (Image<Rgba32> input = Image.Load<Rgba32>(myBlob, out format))
        {
            ResizeImage(input, imageExtraSmall, ImageSize.ExtraSmall, format);
        }
    }

    public static void ResizeImage(Image<Rgba32> input, Stream output, ImageSize size, IImageFormat format)
    {
        var dimensions = imageDimensionsTable[size];
        input.Mutate(x => x.Resize(dimensions.Item1, dimensions.Item2));
        input.Save(output, format);
    }

    public enum ImageSize { ExtraSmall, Small, Medium }

    private static Dictionary<ImageSize, (int, int)> imageDimensionsTable = new Dictionary<ImageSize, (int, int)>() {
        { ImageSize.ExtraSmall, (320, 200) },
        { ImageSize.Small,      (640, 400) },
        { ImageSize.Medium,     (800, 600) }
    };

    ```
    
    You should see in **Logs**, that the function respond to the changes, and successfully compile your code.

    ![function-app-custome-code](/assets/function-app-custome-code.PNG)

6. Upload image to your `uploaded` container, and check the **Logs** of your function, after it successfully run, navigate to your storage account, and see additional containers were added `extra-small`, `small`, and `medium`, each has its resized image with prefix.
    ![function-app-result](/assets/function-app-result.PNG)

**Congratulations!** You have created a Function App that respond for uploaded images with the resize functionality.  

**Note**: To avoid additional costs, you can remove this resource group. Search for resource groups, click your resource group, and then click **Delete resource group**. Verify the name of the resource group and then click **Delete**. Monitor the **Notifications** to see how the delete is proceeding.
